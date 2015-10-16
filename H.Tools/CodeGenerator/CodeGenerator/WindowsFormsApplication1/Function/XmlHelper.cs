using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using WindowsFormsApplication1.Master;

namespace WindowsFormsApplication1.Function
{
    class XmlHelper
    {
        public static string GetXmlCode(string modelName) {
            XmlDocument xml = new XmlDocument();
            xml.Load(AppDomain.CurrentDomain.BaseDirectory + "Master//" + modelName + ".xml");
            return xml.DocumentElement.SelectNodes("//Content")[0].InnerText;
        }

        public static string Facade_Assembly()
        {
            return Resource1.Facade_Assembly;
        }

        public static string Facade()
        {
            return Resource1.Facadetxt;
        }

        public static string RestService()
        {
            return Resource1.RestServicetxt;
        }

        public static string Model() {
            return Resource1.Entitytxt;
        }

        public static string Xml()
        {
            return GetXmlCode("Xml");
        }

        public static string DbCommand()
        {
            return Resource1.DbCommandxml;
        }

        public static string Interface()
        {
            return Resource1.IDataAccesstxt;
        }

        public static string DA()
        {
            return Resource1.DataAccesstxt;
        }


        public static string DA_Assembly()
        {
            return Resource1.DataAccess_Assembly;
        }

        public static string PageAspx()
        {
            return Resource1.WebPageaspx;
        }
        public static string PageAspxCs()
        {
            return Resource1.WebPageaspxcs;
        }
        public static string PageDesign()
        {
            return Resource1.WebPageaspxdesignercs;
        }

        public static string PageAspx2()
        {
            return Resource1.Maintainaspx;
        }
        public static string PageAspxCs2()
        {
            return Resource1.Maintainaspxcs;
        }
        public static string PageDesign2()
        {
            return Resource1.Maintainaspxdesignercs;
        }
    }
}
