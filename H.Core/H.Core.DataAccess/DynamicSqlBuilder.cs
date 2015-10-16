
namespace H.Core.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Text;

    /// <summary>
    /// This class can help you build a sql for dynamic query.
    /// When use this class, PLEASE BE SURE your dynamic query sql template is like this:
    /// 
    /// SELECT @TotalCount = COUNT(a.xxx) 
    /// FROM dbo.xxx a WITH(NOLOCK) 
    /// #StrWhere# 
    /// SELECT xxx
    /// FROM
    /// (
    ///     SELECT TOP (@EndNumber)
    ///         xxx,
    ///         (ROW_NUMBER() OVER(ORDER BY #SortColumnName#)) AS RowNumber 
    ///     FROM dbo.xxx a WITH(NOLOCK) 
    ///     #StrWhere#
    /// ) Result
    /// WHERE RowNumber > @StartNumber
    /// 
    /// MAKE SURE the sql parameter name of this template CAN NOT be change.
    /// </summary>
    public class DynamicSqlBuilder : IDisposable
    {
        private const int Default_PageSize = 1000;

        private ConditionConstructor m_conditionConstructor;
        private PagingInfo m_pagingInfo;
        private CustomDataCommand m_dataCommand;
        private string m_querySqlTemplate;
        private string m_defaultOrderBy;

        public DynamicSqlBuilder(CustomDataCommand dataCommand,
       PagingInfo pagingInfo, string defaultOrderBy)
            : this(dataCommand.CommandText, dataCommand, pagingInfo, defaultOrderBy)
        {
        }

        public DynamicSqlBuilder(
            string querySqlTemplate, CustomDataCommand dataCommand,
            PagingInfo pagingInfo, string defaultOrderBy)
        {
            m_pagingInfo = pagingInfo;
            m_dataCommand = dataCommand;
            m_querySqlTemplate = querySqlTemplate;
            m_defaultOrderBy = defaultOrderBy;
            m_conditionConstructor = new ConditionConstructor();
        }

        private string BuildOrderByString()
        {
            string orderByString = m_defaultOrderBy;
            if (m_pagingInfo != null &&
                m_pagingInfo.SortList != null && m_pagingInfo.SortList.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (SortItem item in m_pagingInfo.SortList)
                {
                    if (!ConditionConstructor.IsStringNullOrEmpty(item.SortFeild))
                    {
                        if (item.SortType == SortType.DESC)
                        {
                            sb.Append(item.SortFeild + " DESC,");
                        }
                        else
                        {
                            sb.Append(item.SortFeild + ",");
                        }
                    }
                }
                if (sb.Length > 0)
                {
                    sb = sb.Remove(sb.Length - 1, 1);
                    orderByString = sb.ToString();
                }
            }
            if (ConditionConstructor.IsStringNullOrEmpty(orderByString))
            {
                throw new ApplicationException("Daynamic query must have one OrderBy field at least.");
            }
            return orderByString;
        }

        private void SetPagingInformation()
        {
            int pageSize = Default_PageSize;
            int startIndex = 0;
            if (m_pagingInfo != null)
            {
                pageSize = m_pagingInfo.PageSize;
                startIndex = (m_pagingInfo.PageIndex - 1) * m_pagingInfo.PageSize;
            }
            m_dataCommand.AddInputParameter("@EndNumber", DbType.Int32, pageSize + startIndex);
            m_dataCommand.AddInputParameter("@StartNumber", DbType.Int32, startIndex);
            m_dataCommand.AddOutParameter("@TotalCount", DbType.Int32, 4);
        }

        public string BuildQuerySql()
        {
            // Build Query Condition
            ConditionCollectionContext buildContext = new ConditionCollectionContext(m_dataCommand);
            string result = m_querySqlTemplate.Replace("#StrWhere#", m_conditionConstructor.BuildQuerySqlConditionString(buildContext));
            // Build OrderBy String
            result = result.Replace("#SortColumnName#", BuildOrderByString());
            // Set Paging Information
            SetPagingInformation();
            return result;
        }

        public ConditionConstructor Conditions
        {
            get { return m_conditionConstructor; }
        }

        #region IDisposable Members

        public void Dispose()
        {
            try
            {
                if (m_pagingInfo != null)
                {
                    object totalCount = m_dataCommand.GetParameterValue("@TotalCount");
                    if (totalCount != null && totalCount != DBNull.Value)
                    {
                        m_pagingInfo.TotalCount = Convert.ToInt32(totalCount);
                    }
                }
            }
            catch
            {
            }
        }

        #endregion
    }

    #region Condition Handler Helper

    public class GroupCondition : IDisposable
    {
        private DynamicSqlBuilder m_builder;

        public GroupCondition(DynamicSqlBuilder builder, RelationType groupRelationType)
        {
            m_builder = builder;
            m_builder.Conditions.BeginGroupCondition(groupRelationType);
        }

        #region IDisposable Members

        public void Dispose()
        {
            m_builder.Conditions.EndGroupCondition();
        }

        #endregion
    }

    public class ConditionConstructor
    {
        private List<Condition> m_conditions;

        internal static bool IsStringNullOrEmpty(string value)
        {
            if (value == null || value.Trim() == string.Empty)
            {
                return true;
            }
            return false;
        }

        internal static bool DefaultParameterValueValidationCheck(object parameterValue)
        {
            // If parameter value is null, it's type is ReferenceType or Nullable<T> type.
            if (parameterValue == null)
            {
                return false;
            }
            Type parameterType = parameterValue.GetType();
            if (parameterType.Equals(typeof(string)) && IsStringNullOrEmpty(parameterValue.ToString()))
            {
                return false;
            }
            return true;
        }

        internal ConditionConstructor()
        {
            m_conditions = new List<Condition>();
        }

        internal ConditionConstructor(List<Condition> conditions)
        {
            m_conditions = conditions;
        }

        private void AddInOrNotInCondition(OperatorType operationType,
            RelationType conditionRelationType, string fieldName, DbType listValueDbType, List<Object> inValues)
        {
            if (operationType != OperatorType.In && operationType != OperatorType.NotIn)
            {
                throw new ArgumentException("Operation Type must be 'In' or 'NotIn'.");
            }
            AddCondition(conditionRelationType, fieldName, listValueDbType, null,
                operationType, inValues, value => { return inValues != null && inValues.Count > 0; });
        }

        private void AddInOrNotInCondition<TListValueType>(OperatorType operationType,
            RelationType conditionRelationType, string fieldName, DbType listValueDbType, List<TListValueType> inValues)
        {
            List<Object> convertedInValues = new List<object>();
            if (inValues != null)
            {
                foreach (TListValueType element in inValues)
                {
                    convertedInValues.Add(element);
                }
            }
            AddInOrNotInCondition(operationType, conditionRelationType, fieldName, listValueDbType, convertedInValues);
        }

        public void AddCondition(
            RelationType conditionRelationType,
            string fieldName, DbType parameterDbType, string parameterName, OperatorType conditionOperatorType,
            object parameterValue, ParameterValueValidateCheckDelegate parameterValueValidateCheckHandler)
        {
            if (parameterValueValidateCheckHandler == null)
            {
                parameterValueValidateCheckHandler = DefaultParameterValueValidationCheck;
            }
            if (parameterValueValidateCheckHandler(parameterValue))
            {
                m_conditions.Add(new SqlCondition
                {
                    ConditionRelationType = conditionRelationType,
                    ParameterDbType = parameterDbType,
                    FieldName = fieldName,
                    ParameterName = parameterName,
                    OperatorType = conditionOperatorType,
                    ParameterValue = parameterValue
                });
            }
        }

        public void BeginGroupCondition(RelationType groupRelationType)
        {
            m_conditions.Add(new LeftBracketCondition() { GroupConditionRelationType = groupRelationType });
        }

        public void EndGroupCondition()
        {
            m_conditions.Add(new RightBraketCondition());
        }

        /// <summary>
        /// 默认RelationType=AND
        /// parameterName=@+fieldName
        /// OperatorType=Equal
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="parameterDbType"></param>
        /// <param name="parameterValue"></param>
        public void AddCondition(string fieldName, DbType parameterDbType, object parameterValue)
        {
            AddCondition(RelationType.AND, fieldName, parameterDbType, "@" + fieldName,
                OperatorType.Equal, parameterValue, DefaultParameterValueValidationCheck);
        }

        /// <summary>
        /// 默认RelationType=AND
        /// OperatorType=Equal
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="parameterDbType"></param>
        /// <param name="parameterValue"></param>
        public void AddCondition(string fieldName, DbType parameterDbType, string parameterName, object parameterValue)
        {
            AddCondition(RelationType.AND, fieldName, parameterDbType, parameterName,
                OperatorType.Equal, parameterValue, DefaultParameterValueValidationCheck);
        }

        public void AddCondition(
            RelationType conditionRelationType,
            string fieldName, DbType parameterDbType, string parameterName, OperatorType conditionOperatorType,
            object parameterValue)
        {
            AddCondition(conditionRelationType, fieldName, parameterDbType, parameterName,
                conditionOperatorType, parameterValue, DefaultParameterValueValidationCheck);
        }

        public void AddBetweenCondition(
            RelationType conditionRelationType,
            string fieldName, DbType parameterDbType, string parameterName,
            OperatorType leftConditionOperatorType, OperatorType rightConditionOperatorType,
            object leftParameterValue, object rightParameterValue,
            ParameterValueValidateCheckDelegate parameterValueValidateCheckHandler)
        {
            BeginGroupCondition(conditionRelationType);
            AddCondition(RelationType.AND, fieldName, parameterDbType, parameterName + "_Left",
                leftConditionOperatorType, leftParameterValue, parameterValueValidateCheckHandler);
            AddCondition(RelationType.AND, fieldName, parameterDbType, parameterName + "_Right",
                rightConditionOperatorType, rightParameterValue, parameterValueValidateCheckHandler);
            EndGroupCondition();
        }

        public void AddBetweenCondition(
            RelationType conditionRelationType,
            string fieldName, DbType parameterDbType, string parameterName,
            OperatorType leftConditionOperatorType, OperatorType rightConditionOperatorType,
            object leftParameterValue, object rightParameterValue)
        {
            AddBetweenCondition(conditionRelationType, fieldName, parameterDbType, parameterName,
                leftConditionOperatorType, rightConditionOperatorType, leftParameterValue, rightParameterValue,
                DefaultParameterValueValidationCheck);
        }

        public void AddNullCheckCondition(
            RelationType conditionRelationType, string fieldName, OperatorType conditionOperatorType)
        {
            if (conditionOperatorType != OperatorType.IsNull
                && conditionOperatorType != OperatorType.IsNotNull)
            {
                throw new ArgumentException("Parameter conditionOperatorType must be IsNull or IsNotNull in this method.");
            }
            AddCondition(conditionRelationType, fieldName, DbType.Object, null,
                conditionOperatorType, null, value => { return true; });
        }

        public void AddInCondition(RelationType conditionRelationType,
            string fieldName, DbType listValueDbType, List<Object> inValues)
        {
            AddInOrNotInCondition(OperatorType.In, conditionRelationType, fieldName, listValueDbType, inValues);
        }

        public void AddNotInCondition(RelationType conditionRelationType,
            string fieldName, DbType listValueDbType, List<Object> inValues)
        {
            AddInOrNotInCondition(OperatorType.NotIn, conditionRelationType, fieldName, listValueDbType, inValues);
        }

        public void AddInCondition<TListValueType>(RelationType conditionRelationType,
            string fieldName, DbType listValueDbType, List<TListValueType> inValues)
        {
            AddInOrNotInCondition<TListValueType>(OperatorType.In, conditionRelationType, fieldName, listValueDbType, inValues);
        }

        public void AddNotInCondition<TListValueType>(RelationType conditionRelationType,
            string fieldName, DbType listValueDbType, List<TListValueType> inValues)
        {
            AddInOrNotInCondition<TListValueType>(OperatorType.NotIn, conditionRelationType, fieldName, listValueDbType, inValues);
        }

        public ConditionConstructor AddSubQueryCondition(RelationType conditionRelationType,
            string filedName, OperatorType conditionOperatorType, string subQuerySQLTemplate)
        {
            if (!IsStringNullOrEmpty(subQuerySQLTemplate))
            {
                SubQueryCondition condition = new SubQueryCondition()
                {
                    ConditionRelationType = conditionRelationType,
                    FieldName = filedName,
                    OperatorType = conditionOperatorType,
                    SubQuerySQLTemplate = subQuerySQLTemplate,
                    SubQueryConditions = new List<Condition>()
                };
                m_conditions.Add(condition);
                ConditionConstructor result = new ConditionConstructor(condition.SubQueryConditions);
                return result;
            }
            return null;
        }

        public void AddCustomCondition(RelationType conditionRelationType, string customQueryString)
        {
            m_conditions.Add(new CustomCondition()
            {
                ConditionRelationType = conditionRelationType,
                CustomQueryString = customQueryString
            });
        }

        internal static string BuildQuerySqlConditionString(List<Condition> conditions, ConditionCollectionContext buildContext)
        {
            if (conditions == null || conditions.Count == 0)
            {
                return string.Empty;
            }
            StringBuilder resultBuilder = new StringBuilder();
            resultBuilder.Append("WHERE ");
            foreach (Condition condition in conditions)
            {
                condition.BuildQueryString(resultBuilder, buildContext);
            }
            string result = resultBuilder.ToString().Trim();
            return result == "WHERE" ? string.Empty : result;
        }

        internal string BuildQuerySqlConditionString(ConditionCollectionContext buildContext)
        {
            return BuildQuerySqlConditionString(m_conditions, buildContext);
        }

        internal List<Condition> Conditions
        {
            get { return m_conditions; }
        }

        public int ValidateConditionCount
        {
            get { return m_conditions != null ? m_conditions.Count : 0; }
        }
    }

    #endregion Condition Handler Helper

    #region Condition Classes

    internal class ConditionCollectionContext
    {
        public bool IsFirstCondition { get; set; }

        public Stack<bool> FirstGroupConditionFlags { get; set; }

        public DataCommand DataCommand { get; set; }

        public List<string> AddedParameterNames { get; set; }

        public ConditionCollectionContext(DataCommand contextDataCommand)
        {
            IsFirstCondition = true;
            FirstGroupConditionFlags = new Stack<bool>();
            AddedParameterNames = new List<string>();
            DataCommand = contextDataCommand;
        }
    }

    internal abstract class Condition
    {
        internal virtual void BuildQueryString(StringBuilder queryStringBuilder, ConditionCollectionContext buildContext)
        {
            if (queryStringBuilder == null)
            {
                throw new ArgumentException("Input query string builder can not be null.");
            }
            if (buildContext == null)
            {
                throw new ArgumentException("Input build context can not be null.");
            }
        }

        protected string GetOperatorString(OperatorType operatorType)
        {
            switch (operatorType)
            {
                case OperatorType.Equal:
                    return "=";
                case OperatorType.LessThan:
                    return "<";
                case OperatorType.LessThanOrEqual:
                    return "<=";
                case OperatorType.MoreThan:
                    return ">";
                case OperatorType.MoreThanOrEqual:
                    return ">=";
                case OperatorType.NotEqual:
                    return "<>";
                case OperatorType.Like:
                case OperatorType.LeftLike:
                case OperatorType.RightLike:
                    return "LIKE";
                case OperatorType.IsNull:
                    return "IS NULL";
                case OperatorType.IsNotNull:
                    return "IS NOT NULL";
                case OperatorType.In:
                    return "IN";
                case OperatorType.NotIn:
                    return "NOT IN";
                case OperatorType.Exist:
                    return "EXISTS";
                case OperatorType.NotExist:
                    return "NOT EXISTS";
                default: return string.Empty;
            }
        }

        protected object TryConvertToLikeString(object value, OperatorType type)
        {
            if (value != null && value.GetType().Equals(typeof(string)) && !ConditionConstructor.IsStringNullOrEmpty(value.ToString()))
            {
                if (type == OperatorType.Like)
                {
                    return "%" + value.ToString() + "%";
                }
                else if (type == OperatorType.LeftLike)
                {
                    return value.ToString() + "%";
                }
                else if (type == OperatorType.RightLike)
                {
                    return "%" + value.ToString();
                }
            }
            return value;
        }
    }

    internal class SqlCondition : Condition
    {
        public string FieldName { get; set; }

        public string ParameterName { get; set; }

        public object ParameterValue { get; set; }

        public DbType ParameterDbType { get; set; }

        public OperatorType OperatorType { get; set; }

        public RelationType ConditionRelationType { get; set; }

        private string BuildSqlConditionString(ConditionCollectionContext buildContext)
        {
            string result = string.Empty;
            if (this.OperatorType == OperatorType.IsNull
                || this.OperatorType == OperatorType.IsNotNull)
            {
                result = string.Format(" {0} {1} {2}", buildContext.IsFirstCondition ? string.Empty : this.ConditionRelationType.ToString(),
                    this.FieldName, GetOperatorString(this.OperatorType));
            }
            else if (this.OperatorType == OperatorType.In
                || this.OperatorType == OperatorType.NotIn)
            {
                List<Object> parameterValues = this.ParameterValue as List<Object>;
                StringBuilder parameterNamesBuilder = new StringBuilder();
                for (int i = 0; i < parameterValues.Count; i++)
                {
                    string parameterName = string.Format("@{0}_Values{1}", this.FieldName.Replace(".", string.Empty), i);
                    parameterNamesBuilder.AppendFormat("{0},", parameterName);
                    buildContext.DataCommand.InnerAddInputParameter(parameterName, this.ParameterDbType, parameterValues[i]);
                }
                string parameterNames = parameterNamesBuilder.ToString();
                parameterNames = parameterNames.Substring(0, parameterNames.Length - 1);
                result = string.Format(" {0} {1} {2} ({3})", buildContext.IsFirstCondition ? string.Empty : this.ConditionRelationType.ToString(),
                    this.FieldName, GetOperatorString(this.OperatorType), parameterNames);
            }
            else
            {
                result = string.Format(" {0} {1} {2} {3}", buildContext.IsFirstCondition ? string.Empty : this.ConditionRelationType.ToString(),
                    this.FieldName, GetOperatorString(this.OperatorType), this.ParameterName);
                if (!buildContext.AddedParameterNames.Contains(this.ParameterName))
                {
                    buildContext.DataCommand.InnerAddInputParameter(this.ParameterName, this.ParameterDbType,
                        (this.OperatorType == OperatorType.Like || this.OperatorType == OperatorType.LeftLike || this.OperatorType == OperatorType.RightLike) ?
                            TryConvertToLikeString(this.ParameterValue, this.OperatorType) : this.ParameterValue);
                    buildContext.AddedParameterNames.Add(this.ParameterName);
                }
            }
            return result;
        }

        internal override void BuildQueryString(StringBuilder queryStringBuilder, ConditionCollectionContext buildContext)
        {
            base.BuildQueryString(queryStringBuilder, buildContext);
            queryStringBuilder.Append(BuildSqlConditionString(buildContext));
            buildContext.IsFirstCondition = false;
        }
    }

    internal class LeftBracketCondition : Condition
    {
        public RelationType GroupConditionRelationType { get; set; }

        internal override void BuildQueryString(StringBuilder queryStringBuilder, ConditionCollectionContext buildContext)
        {
            base.BuildQueryString(queryStringBuilder, buildContext);
            queryStringBuilder.Append(string.Format(" {0} (",
                buildContext.IsFirstCondition ? string.Empty : this.GroupConditionRelationType.ToString()));
            buildContext.FirstGroupConditionFlags.Push(buildContext.IsFirstCondition);
            buildContext.IsFirstCondition = true;
        }
    }

    internal class RightBraketCondition : Condition
    {
        internal override void BuildQueryString(StringBuilder queryStringBuilder, ConditionCollectionContext buildContext)
        {
            base.BuildQueryString(queryStringBuilder, buildContext);
            if (buildContext.FirstGroupConditionFlags.Count > 0)
            {
                bool isFirstGroupCondition = buildContext.FirstGroupConditionFlags.Pop();
                string currentQueryString = queryStringBuilder.ToString().Trim();
                if (currentQueryString.Substring(currentQueryString.Length - 1, 1) == "(")
                {
                    if (isFirstGroupCondition == true)
                    {
                        queryStringBuilder.Remove(queryStringBuilder.Length - 1, 1);
                    }
                    else
                    {
                        queryStringBuilder.Remove(queryStringBuilder.Length - 5, 5);
                        buildContext.IsFirstCondition = false;
                    }
                }
                else
                {
                    queryStringBuilder.Append(" )");
                    buildContext.IsFirstCondition = false;
                }
            }
        }
    }

    internal class SubQueryCondition : Condition
    {
        public RelationType ConditionRelationType { get; set; }

        public string FieldName { get; set; }

        public OperatorType OperatorType { get; set; }

        public string SubQuerySQLTemplate { get; set; }

        public List<Condition> SubQueryConditions { get; set; }

        internal override void BuildQueryString(StringBuilder queryStringBuilder, ConditionCollectionContext buildContext)
        {
            base.BuildQueryString(queryStringBuilder, buildContext);
            ConditionCollectionContext subQueryBuildCondition = new ConditionCollectionContext(buildContext.DataCommand);
            subQueryBuildCondition.AddedParameterNames = buildContext.AddedParameterNames;
            queryStringBuilder.Append(string.Format(" {0} {1} {2} ({3} {4})",
                buildContext.IsFirstCondition ? string.Empty : this.ConditionRelationType.ToString(),
                this.FieldName, GetOperatorString(this.OperatorType), this.SubQuerySQLTemplate,
                ConditionConstructor.BuildQuerySqlConditionString(this.SubQueryConditions, subQueryBuildCondition)));
            buildContext.IsFirstCondition = false;
        }
    }

    internal class CustomCondition : Condition
    {
        public RelationType ConditionRelationType { get; set; }

        public string CustomQueryString { get; set; }

        internal override void BuildQueryString(StringBuilder queryStringBuilder, ConditionCollectionContext buildContext)
        {
            base.BuildQueryString(queryStringBuilder, buildContext);
            queryStringBuilder.Append(string.Format(" {0} {1}",
                buildContext.IsFirstCondition ? string.Empty : this.ConditionRelationType.ToString(),
                this.CustomQueryString));
            buildContext.IsFirstCondition = false;
        }
    }

    #endregion Consition Classes

    public delegate bool ParameterValueValidateCheckDelegate(object value);

    public enum RelationType
    {
        AND,
        OR
    }

    public enum OperatorType
    {
        Equal,
        NotEqual,
        MoreThan,
        LessThan,
        MoreThanOrEqual,
        LessThanOrEqual,
        Like,
        IsNull,
        IsNotNull,
        In,
        NotIn,
        Exist,
        NotExist,
        LeftLike,
        RightLike
    }
}
