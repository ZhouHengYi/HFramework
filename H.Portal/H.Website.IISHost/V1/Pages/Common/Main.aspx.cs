using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using H.Website.Facade;
using H.Core.Utility.Resources;

namespace H.Website.IISHost.Pages.Common
{
    [AjaxPro.AjaxNamespace("Portal.Main")]
    public partial class Main : PageBase
    {
        /// <summary> 
        /// 不需要权限验证
        /// </summary>
        protected override bool RequirePermissionAuth
        {
            get { return false; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AjaxPro.Utility.RegisterTypeForAjax(typeof(Main));
                lit_UserName.Text = "<a href=\"javaScript:void(0);\" class=\"Asty\" style=\"color: #FFF;\" title=\"" + WebContext.LoginUser.UserName + "\">" + WebContext.LoginUser.UserName + "</a>";
                LoadSiteMap();
            }
        }
        /// <summary>
        /// Ajax 获取二级导航
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [AjaxPro.AjaxMethod()]
        public string AjaxLoadSiteMapToParent(string key) {
            if (SiteMapConfig.s_PageCache == null)
                LoadSiteMap();
            string html = string.Empty;
            SiteMapList.Node node = SiteMapConfig.s_PageCache.NodeList.Find(e => { return e.Key == Server.UrlDecode(key); });
            for (int i = 0; i < node.ParentList.Count; i++)
            {
                html += "<li><a href=\"javaScript:void(0);\"" + (i == 0 ? " class=\"selected\"" : "") + " key=\"" + Server.UrlEncode(node.ParentList[i].Key) + "\">" + node.ParentList[i].Key + "</a></li>"; ;
            }
            return html;
        }

        /// <summary>
        /// Ajax 获取三级导航
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [AjaxPro.AjaxMethod()]
        public string AjaxLoadSiteMapToChild(string key)
        {
            if (SiteMapConfig.s_PageCache == null)
                LoadSiteMap();
            string html = string.Empty;
            for (int i = 0; i < SiteMapConfig.s_PageCache.NodeList.Count; i++)
            {
                SiteMapList.Node.Parent node = SiteMapConfig.s_PageCache.NodeList[i].ParentList.Find(e => { return e.Key == Server.UrlDecode(key); });
                if (node != null)
                {
                    for (int j = 0; j < node.ChildList.Count; j++)
                    {
                        string path = PageConfig.GetPage(node.ChildList[j].PageAlice) == null ? "" : PageConfig.GetPage(node.ChildList[j].PageAlice).Path;
                        html += "<li><a href=\"javaScript:void(0);\" url=\"" + path.ToLower() + "\">" + node.ChildList[j].Key + "</a></li>";
                    }
                }
            }
            return html;
        }

        public void LoadSiteMap() {
            SiteMapList smc = SiteMapConfig.GetAllSiteMap();
            SiteMapList siteMap = new SiteMapList();
            if (WebContext.LoginUser.Privilege == null)
                return;
            //获取一级导航
            for (int i = 0; i < WebContext.LoginUser.Privilege.Count; i++)
            {
                for (int j = 0; j < smc.NodeList.Count; j++)
                {
                    if (ParentIsExists(smc.NodeList[j].ParentList, WebContext.LoginUser.Privilege[i].PageAlice))
                    {
                        if (siteMap.NodeList == null)
                            siteMap.NodeList = new List<SiteMapList.Node>();
                        if (siteMap.NodeList.Find(e => { return e.Key == smc.NodeList[j].Key; }) == null)
                            siteMap.NodeList.Add(smc.NodeList[j]);
                    }
                }
            }

            //过滤二级导航
            if (siteMap.NodeList != null)
            {
                for (int i = 0; i < siteMap.NodeList.Count; i++)
                {
                    for (int k = 0; k < siteMap.NodeList[i].ParentList.Count; k++)
                    {
                        bool flag = false;
                        for (int j = 0; j < WebContext.LoginUser.Privilege.Count; j++)
                        {
                            if (ChildIsExists(siteMap.NodeList[i].ParentList[k].ChildList, WebContext.LoginUser.Privilege[j].PageAlice))
                            {
                                flag = true;
                            }
                        }
                        if (!flag)
                            siteMap.NodeList[i].ParentList.Remove(siteMap.NodeList[i].ParentList[k]);
                    }
                }
                //过滤三级导航
                for (int i = 0; i < siteMap.NodeList.Count; i++)
                {
                    for (int k = 0; k < siteMap.NodeList[i].ParentList.Count; k++)
                    {
                        for (int j = 0; j < siteMap.NodeList[i].ParentList[k].ChildList.Count; j++)
                        {
                            if (WebContext.LoginUser.Privilege.Find(e => { return e.PageAlice == siteMap.NodeList[i].ParentList[k].ChildList[j].PageAlice; }) == null)
                            {
                                siteMap.NodeList[i].ParentList[k].ChildList.Remove(siteMap.NodeList[i].ParentList[k].ChildList[j]);
                            }
                        }
                    }
                }
                //构造导航
                if (siteMap.NodeList.Count > 0 && lit_SiteMap_Note != null)
                {
                    lit_SiteMap_Note.Text += "<ul class=\"list1 float_l\" id=\"ul_menu\">";
                    for (int i = 0; i < siteMap.NodeList.Count; i++)
                    {
                        lit_SiteMap_Note.Text += "<li><a href=\"javaScript:void(0);\"" + (i == 0 ? " class=\"selected\"" : "") + " key=\"" + Server.UrlEncode(siteMap.NodeList[i].Key) + "\">" + siteMap.NodeList[i].Key + "</a></li>";
                    }
                    lit_SiteMap_Note.Text += "</ul>";

                    //构造二级导航
                    lit_SiteMap_Parent.Text += "<ul class=\"list1 float_l\" id=\"ul_menu2\">";
                    for (int i = 0; i < siteMap.NodeList[0].ParentList.Count; i++)
                    {
                        lit_SiteMap_Parent.Text += "<li><a href=\"javaScript:void(0);\"" + (i == 0 ? " class=\"selected\"" : "") + " key=\"" + Server.UrlEncode(siteMap.NodeList[0].ParentList[i].Key) + "\">" + siteMap.NodeList[0].ParentList[i].Key + "</a></li>";
                    }
                    lit_SiteMap_Parent.Text += "</ul>";

                    //构造三级导航
                    lit_SiteMap_Child.Text += "<ul class=\"list2 float_l\" id=\"ul_menu3\">";
                    for (int i = 0; i < siteMap.NodeList[0].ParentList[0].ChildList.Count; i++)
                    {
                        string path = PageConfig.GetPage(siteMap.NodeList[0].ParentList[0].ChildList[i].PageAlice) == null ? "" : PageConfig.GetPage(siteMap.NodeList[0].ParentList[0].ChildList[i].PageAlice).Path;
                        lit_SiteMap_Child.Text += "<li><a href=\"javaScript:void(0);\" url=\"" + path.ToLower() + "\">" + siteMap.NodeList[0].ParentList[0].ChildList[i].Key + "</a></li>";
                    }
                    lit_SiteMap_Child.Text += "</ul>";
                }
            }
            SiteMapConfig.s_PageCache = siteMap;
        }

        public bool ParentIsExists(List<H.Core.Utility.Resources.SiteMapList.Node.Parent> ItemList,string pageAlice)
        {
            for (int i = 0; i < ItemList.Count; i++)
            {
                if (ChildIsExists(ItemList[i].ChildList, pageAlice))
                {
                    return true;
                }
            }
            return false;
        }

        public bool ChildIsExists(List<H.Core.Utility.Resources.SiteMapList.Node.Parent.Child> ItemList, string pageAlice)
        {
            for (int i = 0; i < ItemList.Count; i++)
            {
                if (ItemList[i].PageAlice == pageAlice)
                    return true;
            }
            return false;
        }


        /// <summary>
        /// 退出登录
        /// </summary>
        [AjaxPro.AjaxMethod()]
        public string LoginOut()
        {
            WebContext.SignOut();
            string retHtml = "{\"Code\": \"OK\"," + "\"Return\": \"" + UrlHelper.BuildUrl(PageAlias.SystemLogin) + "\"}";
            return retHtml;
        }
    }
}