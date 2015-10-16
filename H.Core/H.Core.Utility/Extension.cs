using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H.Core.Utility
{
    public static class Extension
    {
        /// <summary>
        /// Convert.ToInt32
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static int ToInt32(this string val)
        {
            return Convert.ToInt32(val);
        }
        public static int ToInt32(this decimal val)
        {
            return Convert.ToInt32(val);
        }
        public static int ToInt32(this double val)
        {
            return Convert.ToInt32(val);
        }
        public static int ToInt32(this float val)
        {
            return Convert.ToInt32(val);
        }
        public static int ToInt32(this object val)
        {
            return Convert.ToInt32(val);
        }


        /// <summary>
        /// Convert.ToDateTime(val).ToString(framt);
        /// </summary>
        /// <param name="val"></param>
        /// <param name="framt"></param>
        /// <returns></returns>
        public static string ToDateTime(this string val,string framt)
        {
            return Convert.ToDateTime(val).ToString(framt);
        }

        public static bool IsEqual(this string val, string val2)
        {
            return val == val2;
        }

        /// <summary>
        /// 检测是否含有危险字符（防止Sql注入）
        /// </summary>
        /// <param name="contents">预检测的内容</param>
        /// <returns>返回True或false</returns>
        public static bool HasDangerousContents(this string contents)
        {
            bool bReturnValue = true;
            if (string.IsNullOrEmpty(contents))
                return bReturnValue;
            if (contents.Length > 0)
            {
                //convert to lower
                string sLowerStr = contents.ToLower();
                //RegularExpressions
                string sRxStr = @"(\sand\s)|(\sand\s)|(\slike\s)|(select\s)|(insert\s)|
(delete\s)|(update\s[\s\S].*\sset)|(create\s)|(\stable)|(<[iframe|/iframe|script|/script])|
(')|(\sexec)|(\sdeclare)|(\struncate)|(\smaster)|(\sbackup)|(\smid)|(\scount)";
                //Match
                bool bIsMatch = true;
                System.Text.RegularExpressions.Regex sRx = new
                System.Text.RegularExpressions.Regex(sRxStr);
                bIsMatch = sRx.IsMatch(sLowerStr, 0);
                if (bIsMatch)
                {
                    bReturnValue = false;
                }
            }
            return bReturnValue;
        }

        /// <summary>
        /// 移除HTML标签[正则]
        /// </summary>
        /// <param name="HTMLStr">HTMLStr</param>
        public static string NoHtml(this string HTMLStr)
        {
            //<[^(b|>)]*>
            return System.Text.RegularExpressions.Regex.Replace(HTMLStr, "<[^(>)]*>", "");
        }

        /// <summary>
        /// 字符串截取
        /// </summary>
        /// <param name="obj">预截取对象</param>
        /// <param name="len">预截取长度</param>
        /// <returns>截取后的字符串</returns>
        public static string SubString(this object obj, int len)
        {
            return SubString(obj.ToString(), len, "...");
        }
        /// <summary>
        /// 字符串截取
        /// </summary>
        /// <param name="str">预截取字符串</param>
        /// <param name="len">预截取长度</param>
        /// <param name="suffix">截取后字符串后缀</param>
        /// <returns>截取后的字符串</returns> 
        public static string SubString(object obj, int len, string suffix)
        {
            return SubString(obj.ToString(), len, suffix);
        }
        /// <summary>
        /// 字符串截取
        /// </summary>
        /// <param name="str">预截取字符串</param>
        /// <param name="len">预截取长度</param>    
        /// <returns>截取后的字符串</returns> 
        public static string SubString(string str, int len)
        {
            return SubString(str, len, "...");
        }
        /// <summary>
        /// 字符串截取
        /// </summary>
        /// <param name="str">预截取字符串</param>
        /// <param name="len">预截取长度</param>
        /// <param name="suffix">截取后字符串后缀</param>
        /// <returns>截取后的字符串</returns> 
        public static string SubString(string str, int len, string suffix)
        {
            if (str == null || str.Length == 0 || len <= 0)
                return "";
            int iCount = System.Text.Encoding.GetEncoding("GBK").GetByteCount(str);
            if (iCount > len)
            {
                int iLength = 0;
                for (int i = 0; i < str.Length; i++)
                {
                    int iCharLength = System.Text.Encoding.GetEncoding("GBK").GetByteCount(new char[] { str[i] });
                    iLength += iCharLength;
                    if (iLength == len)
                    {
                        str = str.Substring(0, i + 1);
                        break;
                    }
                    else if (iLength > len)
                    {
                        str = str.Substring(0, i);
                        break;
                    }
                }
                str += suffix;
            }
            return str;
        }
    }
}
