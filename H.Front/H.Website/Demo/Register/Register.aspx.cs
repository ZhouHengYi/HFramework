using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using H.Facade;

namespace H.Website.Demo.Register
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string languageScriptPath = LanguageHelper.GetLanguageScriptPath();
                HtmlGenericControl js = new HtmlGenericControl("script");
                js.Attributes.Add("type","text/javaScript");
                js.Attributes.Add("src", languageScriptPath);
                Page.Header.Controls.Add(js);
                btn_register.Text = LanguageHelper.GetMessage("Register_Button_Register");
            }
        }

        protected void btn_register_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('" + LanguageHelper.GetMessage("Register_Alt_Success") + "');", true);
        }
    }
}