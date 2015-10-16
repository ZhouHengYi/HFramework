using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace H.Core.Utility
{
    /// <summary>
    /// 实例
    /// </summary>
    public class ObjectInstance
    {
        public static object CreateInstance(Type type, string[] args)
        {
            ConstructorInfo[] infoArray = type.GetConstructors();
            List<ParameterInfo[]> matched = new List<ParameterInfo[]>(infoArray.Length);
            foreach (var con in infoArray)
            {
                ParameterInfo[] pArray = con.GetParameters();
                if (pArray.Length == args.Length)
                {
                    matched.Add(pArray);
                }
            }
            if (matched.Count <= 0)
            {
                throw new ApplicationException("Can't find the constructor with " + args.Length + " parameter(s) of type '" + type.AssemblyQualifiedName + "'");
            }
            StringBuilder sb = new StringBuilder();
            int j = 1;
            foreach (var paramArray in matched)
            {
                try
                {
                    object[] realArgs = new object[paramArray.Length];
                    for (int i = 0; i < paramArray.Length; i++)
                    {
                        realArgs[i] = DataConvertor.GetValueByType(paramArray[i].ParameterType, args[i], null, null);
                    }
                    return Activator.CreateInstance(type, realArgs);
                }
                catch (Exception ex)
                {
                    sb.AppendLine(j + ". " + ex.Message);
                }
                j++;
            }
            throw new ApplicationException("There are " + matched.Count + " matched constructor(s), but all failed to construct instance for type '" + type.AssemblyQualifiedName + "', detail error message: \r\n" + sb);
        }


    }
}
