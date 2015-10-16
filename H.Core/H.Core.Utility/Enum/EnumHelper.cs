using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace H.Core.Utility
{
    public class EnumHelper
    {
        private static Dictionary<string, EnumItemCollection> _enumDic = new Dictionary<string, EnumItemCollection>();
        private static readonly object _objLock = new object();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumField"></param>
        /// <returns></returns>
        public static string GetEnumDescription(Enum enumField)
        {
            return GetEnumItem(enumField).Description;
        }

        public static T GetEnumObject<T>(string text)
        {
            return (T)Enum.Parse(typeof(T), text);
        }

        /// <summary>
        /// get the enum's all list
        /// </summary>
        /// <param name="enumType">the type of the enum</param>
        /// <param name="withAll">identicate whether the returned list should contain the all item</param>
        /// <returns></returns>
        public static EnumItemCollection GetEnumItems(Type enumType)
        {
            if (enumType.IsEnum != true)
            {
                throw new InvalidOperationException();
            }

            string key = enumType.FullName;

            EnumItemCollection emumItems;
            _enumDic.TryGetValue(key, out emumItems);

            if (emumItems == null)
            {
                lock (_objLock)
                {
                    _enumDic.TryGetValue(key, out emumItems);
                    if (emumItems == null)
                    {
                        emumItems = GetEnumItems4Cache(enumType);
                        _enumDic.Add(key, emumItems);
                    }
                }
            }
            return emumItems;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetEnumByKey<T>(string key)
        {
            return GetEnumByKey<T>(key, default(T));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T GetEnumByKey<T>(string key, T defaultValue)
        {
            T item = defaultValue;
            try
            {
                item = GetEnumObject<T>(key);
            }
            catch
            {
                item = defaultValue;
            }
            return item;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T GetEnumByValue<T>(int value)
        {
            return GetEnumByValue<T>(value, default(T));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T GetEnumByValue<T>(int value, T defaultValue)
        {
            return GetEnumByValue<T>(value.ToString(), default(T));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T GetEnumByValue<T>(string value)
        {
            return GetEnumByValue<T>(value, default(T));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T GetEnumByValue<T>(string value, T defaultValue)
        {
            T item = defaultValue;
            try
            {
                item = GetEnumObject<T>(value);
            }
            catch
            {
                item = defaultValue;
            }
            return item;
        }

        /// <summary>
        /// get the Enum value according to the its decription
        /// </summary>
        /// <typeparam name="T">the type of the enum</typeparam>
        /// <param name="description">the description of the EnumValue</param>
        /// <returns></returns>
        public static T GetEnumByDescription<T>(string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                return default(T);
            }

            Type enumType = typeof(T);
            EnumItemCollection list = GetEnumItems(enumType);
            foreach (EnumItem item in list)
            {
                if (item.Description == description.Trim())
                {
                    return (T)Enum.ToObject(typeof(T), item.Value);
                }
            }
            return default(T);
        }

        #region [ Helper ]

        private static EnumItemCollection GetEnumItems4Cache(Type enumType)
        {
            EnumItemCollection emumItems = new EnumItemCollection();

            Type typeDescription = typeof(DescriptionAttribute);
            FieldInfo[] fields = enumType.GetFields();
            Array values = Enum.GetValues(enumType);

            string description;
            FieldInfo field;
            //第一个field用来存储类型信息
            for (int i = 1; i < fields.Length; i++)
            {
                field = fields[i];
                object[] arr = field.GetCustomAttributes(typeDescription, true);
                description = arr.Length > 0 ? ((DescriptionAttribute)arr[0]).Description : field.Name;

                int value = (int)values.GetValue(i - 1);
                emumItems.Add(new EnumItem(field.Name, value, description));
            }
            return emumItems;
        }

        private static EnumItem GetEnumItem(Enum enumField)
        {
            EnumItem enumItem = null;
            Type enumType = enumField.GetType();

            EnumItemCollection enumItems = GetEnumItems(enumType);
            string key = Enum.GetName(enumType, enumField);
            enumItems.TryGet(key, out enumItem);

            if (enumItem == null)
            {
                int value = (int)Enum.Parse(enumType, key);
                enumItem = new EnumItem(key, value);
            }
            return enumItem;
        }

        #endregion
    }

    /// <summary>
    /// RelationShip between Key and Value
    /// </summary>
    public class EnumItem
    {
        private string _key;
        private int _value;
        private string _description;


        /// <summary>
        /// Enum Key
        /// </summary>
        public string Key
        {
            get { return _key; }
        }

        /// <summary>
        /// Enum Value
        /// </summary>
        public int Value
        {
            get { return _value; }
        }

        /// <summary>
        /// Enum Description
        /// </summary>
        public string Description
        {
            get { return _description; }
        }

        /// <summary>
        /// Custructor
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public EnumItem(string key, int value)
            : this(key, value, key)
        {
        }

        /// <summary>
        /// Custructor
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public EnumItem(string key, int value, string description)
        {
            _key = key;
            _value = value;
            _description = description;
        }
    }

    public class EnumItemCollection : KeyedCollection<string, EnumItem>
    {
        protected override string GetKeyForItem(EnumItem item)
        {
            return item.Key;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="enumItem"></param>
        /// <returns></returns>
        public bool TryGet(string key, out EnumItem enumItem)
        {
            enumItem = null;
            if (this.Contains(key))
            {
                enumItem = this[key];
                return true;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool IsKeyExist(string key)
        {
            bool isExists = false;
            foreach (EnumItem enumItem in this)
            {
                if (key == enumItem.Key)
                    isExists = true;
            }
            return isExists;
        }
    }
}
