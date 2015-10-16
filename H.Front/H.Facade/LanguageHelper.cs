using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using H.Core.Utility;

namespace H.Facade
{
    public class LanguageHelper
    {
        private static string GetLanguageType() {
            string language = CookieManager.GetValue("WebsiteLanguage");
            return language;
        }

        public static string GetMessage(string code) {
            string fileUrl = string.Empty;
            switch (GetLanguageType())
            {
                case "en":
                    fileUrl = "Configuration/Language/EN/language_cn.config";
                    break;
                case "jp":
                    fileUrl = "Configuration/Language/JP/language_cn.config";
                    break;                    
                default:
                    fileUrl = "Configuration/Language/CN/language_cn.config";
                    break;
            }
            fileUrl = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, fileUrl);
            XmlDocument doc = new XmlDocument();
            doc.Load(fileUrl);
            XmlNodeList nodes = doc.SelectNodes("/messageConfig/message[@code='"+code+"']");
            string message = string.Empty;
            foreach (XmlNode item in nodes)
            {
                message = item.InnerText;
            }
            return message;
        }

        public static string GetLanguageScriptPath() {
            string fileUrl = string.Empty;
            switch (GetLanguageType())
            {
                case "en":
                    fileUrl = "/Configuration/Language/EN/language_cn.js";
                    break;
                case "jp":
                    fileUrl = "/Configuration/Language/JP/language_cn.js";
                    break;
                default:
                    fileUrl = "/Configuration/Language/CN/language_cn.js";
                    break;
            }

            return fileUrl;
        }

    }
}
