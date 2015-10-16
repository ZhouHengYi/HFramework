using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace H.Core.Utility
{
    public class AutorunManager
    {
        private static readonly string s_XmlPath = GetAutorunXmlPath();

        private static string GetAutorunXmlPath()
        {
            string path = WebConfig.AutorunConfigPath;
            if (path == null || path.Trim().Length <= 0)
            {
                return Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "Configuration/Autorun.config");
            }
            string p = Path.GetPathRoot(path);
            if (p == null || p.Trim().Length <= 0) // 说明是相对路径
            {
                path = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, path);
            }
            return path;
        }

        public static void Startup(Action<Exception> errorHandler)
        {
            List<IStartup> list = GetModule<IStartup>(@"//autorun/startup", errorHandler);
            foreach (var m in list)
            {
                try
                {
                    m.Start();
                }
                catch (Exception ex)
                {
                    if (errorHandler != null)
                    {
                        errorHandler(ex);
                    }
                }
            }
        }

        private static List<T> GetModule<T>(string xpath, Action<Exception> errorHandler)
        {
            if (!File.Exists(s_XmlPath))
            {
                return new List<T>(0);
            }

            XmlDocument x = new XmlDocument();
            x.Load(s_XmlPath);
            XmlNode node = x.SelectSingleNode(xpath);
            if (node == null || node.ChildNodes == null || node.ChildNodes.Count <= 0)
            {
                return new List<T>(0);
            }
            XmlNode[] mList = XmlHelper.GetChildrenNodes(node, "module");
            if (mList == null || mList.Length <= 0)
            {
                return new List<T>(0);
            }
            List<T> rstList = new List<T>(mList.Length);
            foreach (var n in mList)
            {
                try
                {
                    string typeName = XmlHelper.GetNodeAttribute(n, "type");
                    if (typeName == null || typeName.Trim().Length <= 0)
                    {
                        continue;
                    }
                    string[] argments;
                    XmlNodeList args = n.SelectNodes("constructor/arg");
                    if (args == null || args.Count <= 0)
                    {
                        argments = new string[0];
                    }
                    else
                    {
                        argments = new string[args.Count];
                        for (int i = 0; i < args.Count; i++)
                        {
                            string t = args[i].InnerText;
                            argments[i] = t == null ? null : t.Trim();
                        }
                    }
                    Type type = Type.GetType(typeName, true);
                    rstList.Add((T)ObjectInstance.CreateInstance(type, argments));
                }
                catch (Exception ex)
                {
                    if (errorHandler != null)
                    {
                        errorHandler(ex);
                    }
                }
            }
            return rstList;
        }
    }

    public interface IStartup
    {
        void Start();
    }

    public interface IShutdown
    {
        void Shut();
    }
}

