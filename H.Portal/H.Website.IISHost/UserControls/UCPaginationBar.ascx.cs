using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace H.Website.IISHost.UserControls
{
    public partial class UCPaginationBar : System.Web.UI.UserControl
    {
        #region [ fields ]

        private long pPAGENUMDELTE = 1;
        private long nPAGENUMDELTE = 1;

        private int pageSize = 1;
        private long recordCount;
        private long currentPage;

        private string paginationUrlTemplate = null;
        private NameValueCollection pageQueryString = null;

        private List<string> validSortKeys = null;
        private string confirmUrl = "";
        private bool simpleStyle = false;
        private string anchor = string.Empty;
        private bool hideUserDefined = false;
        private bool ajax = false;
        private string ajax_ScriptMethod;
        #endregion

        #region [ input properties ]

        public long PPAGENUMDELTE
        {
            get { return this.pPAGENUMDELTE; }
            set { this.pPAGENUMDELTE = value; }
        }

        public long NPAGENUMDELTE
        {
            get { return this.nPAGENUMDELTE; }
            set { this.nPAGENUMDELTE = value; }
        }
        public bool HideUserDefined
        {
            get { return this.hideUserDefined; }
            set { this.hideUserDefined = value; }
        }
        /// <summary>
        /// 每页记录条数
        /// </summary>
        public int PageSize
        {
            set { this.pageSize = value == 0 ? 24 : value; }
        }

        /// <summary>
        /// 总的记录数
        /// </summary>
        public long RecordCount
        {
            set { this.recordCount = value; }
        }

        /// <summary>
        /// 当前页码
        /// </summary>
        public long CurrentPageNumber
        {
            set
            {
                this.currentPage = value;
            }

            protected get
            {
                if (this.currentPage <= 0)
                {
                    this.currentPage = 1;
                }

                if (this.currentPage > this.PageCount)
                {
                    this.currentPage = this.PageCount;
                }

                return this.currentPage;
            }
        }

        /// <summary>
        /// 总页数
        /// </summary>
        protected long PageCount
        {
            get
            {
                return Convert.ToInt64((this.recordCount - 1) / this.pageSize) + 1;
            }
        }

        /// <summary>
        /// 分页url模板，用于手工拼接url,赋值的模板要包含{0}参数
        /// </summary>
        public string PaginationUrlTemplate
        {
            get { return paginationUrlTemplate; }
            set { paginationUrlTemplate = value; }
        }

        /// <summary>
        /// 当前页面上下文的参数集合
        /// </summary>
        public NameValueCollection PageQueryString
        {
            get { return pageQueryString; }
            set { pageQueryString = value; }
        }

        /// <summary>
        /// 需要保证参数顺序的参数列表
        /// </summary>
        public List<string> ValidSortKeys
        {
            get { return validSortKeys; }
            set { validSortKeys = value; }
        }

        /// <summary>
        /// 点击确定按钮的url模板
        /// </summary>
        public string ConfirmUrl
        {
            get { return this.confirmUrl; }
            set { this.confirmUrl = value; }
        }

        /// <summary>
        /// 是否为Ajax分页
        /// </summary>
        public bool Ajax
        {
            get { return this.ajax; }
            set { this.ajax = value; }
        }

        /// <summary>
        /// Script 方法
        /// </summary>
        public string Ajax_ScriptMethod
        {
            get { return this.ajax_ScriptMethod; }
            set { this.ajax_ScriptMethod = value; }
        }

        /// <summary>
        /// 是否简化版
        /// </summary>
        public bool SimpleStyle
        {
            get { return this.simpleStyle; }
            set { this.simpleStyle = value; }
        }

        /// <summary>
        /// 链接锚点
        /// </summary>
        public string Anchor
        {
            get { return this.anchor; }
            set { this.anchor = value; }
        }

        #endregion

        #region [ OnPreRender ]

        /// <summary>
        /// 
        /// </summary>
        public static NameValueCollection QueryString
        {
            get { return HttpContext.Current.Request.QueryString; }
        }

        /// <summary>
        /// OnPreRender事件处理函数
        /// </summary>
        protected override void OnPreRender(EventArgs e)
        {
            NameValueCollection a = QueryString;
            if (this.recordCount <= 0)
            {
                this.Visible = false;
                base.OnPreRender(e);
                return;
            }
            if (PageCount <= 1)
            {
                this.plConfirm.Visible = false;
            }

            if (this.simpleStyle == true)
            {
                this.SetPreviousPageLink();
                this.SetNextPageLink();

                //this.ltOmitP.Text =  string.Format("<ins>{0}/{1}</ins>",this.CurrentPageNumber,this.PageCount);
                this.plConfirm.Visible = false;

            }
            else
            {
                this.SetPreviousPageLink();
                this.SetPaginationLink();
                this.SetNextPageLink();
                this.BuildConfirmUrl();
            }
            this.SetBeginPageLink();
            this.SetEndPageLink();
            if (hideUserDefined)
            {
                this.plConfirm.Visible = false;
            }
            base.OnPreRender(e);
        }

        #endregion

        #region [ UI Methods ]
        private void BuildConfirmUrl()
        {
            foreach (var item in QueryString)
            {
                if (item.ToString() != "paramPageNumber")
                {
                    if (this.confirmUrl.IndexOf('?') >= 0)
                        this.confirmUrl += "&" + item + "=" + QueryString[item.ToString()];
                    else
                        this.confirmUrl += "?" + item + "=" + QueryString[item.ToString()];
                }
            }
            if (confirmUrl != null)
            {
                if (this.confirmUrl.IndexOf('?') >= 0)
                    this.confirmUrl += "&paramPageNumber=" + this.anchor;
                else
                    this.confirmUrl += "?paramPageNumber=" + this.anchor;
            }
        }

        /// <summary>
        /// 根据当前传进来的参数来构造url，只会改写pageIndex参数
        /// </summary>
        /// <param name="pageNumber">页码</param>
        /// <returns>url</returns>
        private string BuildPaginationUrl(long pageNumber)
        {
            string number = pageNumber <= 1 ? string.Empty : pageNumber.ToString();

            string retStr = string.Empty;
            if (!Ajax)
                retStr = confirmUrl;
            else
                retStr = "javaScript:" + Ajax_ScriptMethod + "('";
            if (QueryString.Count > 0)
            {
                foreach (var item in QueryString)
                {
                    if (item.ToString() != "paramPageNumber")
                    {
                        if (retStr.IndexOf('?') >= 0)
                            retStr += "&" + item + "=" + QueryString[item.ToString()];
                        else
                            retStr += "?" + item + "=" + QueryString[item.ToString()];
                    }
                    else
                    {
                        if (retStr.IndexOf('?') >= 0)
                            retStr += "&" + item + "=" + pageNumber;
                        else
                            retStr += "?" + item + "=" + pageNumber;
                    }
                }
            }
            else
            {
                if (retStr.IndexOf('?') >= 0)
                    retStr += "&paramPageNumber=" + pageNumber;
                else
                    retStr += "?paramPageNumber=" + pageNumber;
            }
            if (Ajax)
            {
                retStr += "')";
            }
            return retStr;
        }

        private string BuildOmitElement()
        {
            return "<ins>...</ins>";
        }

        private string BuildPageElement(string pageNumber, string url, string cssClass)
        {
            string href = "href=\"" + url + "\"";
            string css = "class=\"" + cssClass + "\"";

            if (string.IsNullOrEmpty(url))
            {
                href = "href=\"javascript:void(0)\"";
            }

            if (string.IsNullOrEmpty(cssClass))
            {
                css = string.Empty;
            }

            string retHtml = string.Empty;

            if (this.SimpleStyle == true)
            {
                retHtml =  "<a " + css + href + ">" + pageNumber + "</a>";
            }
            else
            {
                retHtml =  "<a " + css + href + "><span>" + pageNumber + "</span></a>";
            }
            if (cssClass == "previous fg-button ui-button ui-state-default ui-state-disabled")
            {
                retHtml += "<span>";
            }
            else if (cssClass == "next fg-button ui-button ui-state-default")
            {
                retHtml += "</span>";
            }

            return retHtml;
        }


        /// <summary>
        /// 设置上一页按钮
        /// </summary>
        private void SetPreviousPageLink()
        {
            if (this.CurrentPageNumber - 1 <= 0)
            {
                if (this.simpleStyle == true)
                {
                    ltPrev.Text = this.BuildPageElement("<", null, "btn_prev preDisable inblock");
                }
                else
                {
                    ltPrev.Text = this.BuildPageElement("<span><s class='arrow'></s>上一页</span>", null, "previous fg-button ui-button ui-state-default ui-state-disabled");
                }
            }
            else
            {
                if (this.simpleStyle == true)
                {
                    ltPrev.Text = this.BuildPageElement("<", this.BuildPaginationUrl(this.CurrentPageNumber - 1), "btn_prev  inblock");
                }
                else
                {
                    ltPrev.Text = this.BuildPageElement("<span><s class='arrow'></s>上一页</span>", this.BuildPaginationUrl(this.CurrentPageNumber - 1), "pre");
                }
            }
        }

        /// <summary>
        /// 设置下一页按钮
        /// </summary>
        private void SetNextPageLink()
        {
            if ((this.CurrentPageNumber + 1) > this.PageCount)
            {
                if (this.simpleStyle == true)
                {
                    ltNext.Text = this.BuildPageElement("下一页", null, "btn_next nextDisable inblock ml10");
                }
                else
                {
                    ltNext.Text = this.BuildPageElement("<span>下一页<s class='arrow'></s></span>", null, "first ui-corner-tl ui-corner-bl fg-button ui-button ui-state-default ui-state-disabled");
                }
            }
            else
            {
                if (this.simpleStyle == true)
                {
                    ltNext.Text = this.BuildPageElement("下一页", this.BuildPaginationUrl(this.CurrentPageNumber + 1), "btn_next  inblock ml10");
                }
                else
                {
                    ltNext.Text = this.BuildPageElement("<span>下一页<s class='arrow'></s></span>", this.BuildPaginationUrl(this.CurrentPageNumber + 1), "next fg-button ui-button ui-state-default");
                }
            }

            ltEndPage.Text = this.BuildPageElement(this.PageCount.ToString(), this.BuildPaginationUrl(this.PageCount), "fg-button ui-button ui-state-default");
        }

        /// <summary>
        /// 设置尾页按钮
        /// </summary>
        private void SetEndPageLink()
        {
            if ((this.CurrentPageNumber + 1) > this.PageCount)
            {
                if (this.simpleStyle == true)
                {
                    ltEndPage.Text = this.BuildPageElement("尾页", null, "btn_next nextDisable inblock ml10");
                }
                else
                {
                    ltEndPage.Text = this.BuildPageElement("<span>尾页<s class='arrow'></s></span>", null, "first ui-corner-tl ui-corner-bl fg-button ui-button ui-state-default ui-state-disabled");
                }
            }
            else
            {
                if (this.simpleStyle == true)
                {
                    ltEndPage.Text = this.BuildPageElement("尾页", this.BuildPaginationUrl(this.PageCount), "btn_next  inblock ml10");
                }
                else
                {
                    ltEndPage.Text = this.BuildPageElement("<span>尾页<s class='arrow'></s></span>", this.BuildPaginationUrl(this.PageCount), "next fg-button ui-button ui-state-default");
                }
            }
        }

        /// <summary>
        /// 设置首页按钮
        /// </summary>
        private void SetBeginPageLink()
        {
            if (this.CurrentPageNumber - 1 <= 0)
            {
                if (this.simpleStyle == true)
                {
                    ltBeginPage.Text = this.BuildPageElement("首页", null, "btn_next nextDisable inblock ml10");
                }
                else
                {
                    ltBeginPage.Text = this.BuildPageElement("<span>首页<s class='arrow'></s></span>", null, "first ui-corner-tl ui-corner-bl fg-button ui-button ui-state-default ui-state-disabled");
                }
            }
            else
            {
                if (this.simpleStyle == true)
                {
                    ltBeginPage.Text = this.BuildPageElement("首页", this.BuildPaginationUrl(1), "btn_next  inblock ml10");
                }
                else
                {
                    ltBeginPage.Text = this.BuildPageElement("<span>首页<s class='arrow'></s></span>", this.BuildPaginationUrl(1), "next fg-button ui-button ui-state-default");
                }
            }
        }

        /// <summary>
        /// 设置中间的分页链接
        /// </summary>
        private void SetPaginationLink()
        {
            long i;
            bool showFirstPage = false;
            bool showLastPage = false;

            ////show the omit character
            ltOmitN.Text = ltOmitP.Text = this.BuildOmitElement();

            ////show the current page
            ltCurrentPage.Text = this.BuildPageElement(this.CurrentPageNumber.ToString(), null, "fg-button ui-button ui-state-default ui-state-disabled");

            if (this.CurrentPageNumber - this.pPAGENUMDELTE > 1)
            {
                for (i = this.CurrentPageNumber - this.pPAGENUMDELTE; i < this.CurrentPageNumber; ++i)
                {
                    ltPageInfoP.Text += this.BuildPageElement(i.ToString(), this.BuildPaginationUrl(i), "fg-button ui-button ui-state-default");
                }

                if (this.CurrentPageNumber <= this.pPAGENUMDELTE + 2)
                {
                    ltOmitP.Visible = false;
                }

                showFirstPage = true; //(this.CurrentPageNumber - this.pPAGENUMDELTE > 1);
            }
            else
            {
                for (i = 2; i < this.CurrentPageNumber; ++i)
                {
                    ltPageInfoP.Text += this.BuildPageElement(i.ToString(), this.BuildPaginationUrl(i), "fg-button ui-button ui-state-default");
                }

                ltOmitP.Visible = false;
                showFirstPage = (this.CurrentPageNumber == 1 ? false : true);
            }

            if (this.CurrentPageNumber + this.nPAGENUMDELTE <= this.PageCount - 2)
            {
                for (i = this.CurrentPageNumber + 1; i <= this.CurrentPageNumber + this.nPAGENUMDELTE; ++i)
                {
                    ltPageInfoN.Text += this.BuildPageElement(i.ToString(), this.BuildPaginationUrl(i), "fg-button ui-button ui-state-default");
                }

                if (this.CurrentPageNumber >= this.PageCount - (this.nPAGENUMDELTE + 1))
                {
                    ltOmitN.Visible = false;
                }

                showLastPage = true;// (this.CurrentPageNumber + this.nPAGENUMDELTE < this.PageCount);
            }
            else
            {
                for (i = this.CurrentPageNumber + 1; i <= this.PageCount - 1; ++i)
                {
                    ltPageInfoN.Text += this.BuildPageElement(i.ToString(), this.BuildPaginationUrl(i), "fg-button ui-button ui-state-default");
                }

                ltOmitN.Visible = false;
                showLastPage = (this.CurrentPageNumber == this.PageCount ? false : true);
            }

            ////show the first page
            if (showFirstPage)
            {
                ltFirstPage.Text = this.BuildPageElement("1", this.BuildPaginationUrl(1), "fg-button ui-button ui-state-default");
            }

            ////show the last page
            if (showLastPage)
            {
                ltLastPage.Text = this.BuildPageElement(this.PageCount.ToString(), this.BuildPaginationUrl(this.PageCount), "fg-button ui-button ui-state-default");


            }

        }

        #endregion
    }
}