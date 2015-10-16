<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="H.Website.Demo.Register.Register" %>
<%@ Import Namespace="H.Facade" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../WebResource/js/jquery.min-1.7.1.js"></script>
    <script src="../../WebResource/js/Base.js"></script>
    <script type="text/javascript">
        function changeLanguage(language) {
            if ($.hFramework.cookie.get("WebsiteLanguage") != "")
            {
                $.hFramework.cookie.clear("WebsiteLanguage", { topdomain: true, expires: 10 });
            }
            $.hFramework.cookie.set("WebsiteLanguage", language, { topdomain: true, expires: 10 });
            location.reload();
        }

        function register() {
            var name = $("#txt_name").val();
            var phone = $("#txt_phone").val();
            var age = $("#txt_age").val();
            if ($.hFramework.String.IsNullOrEmpty(name))
            {
                alert(language_cn.Register_Alt_InputName);
                return false;
            }
            if ($.hFramework.String.IsNullOrEmpty(phone)) {
                alert(language_cn.Register_Alt_InputPhone);
                return false;
            }
            if ($.hFramework.String.IsNullOrEmpty(age)) {
                alert(language_cn.Register_Alt_InputAge);
                return false;
            }
            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <a href="javaScript:changeLanguage('cn');">中文</a>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <a href="javaScript:changeLanguage('en')">English</a>

        <table>
            <tr>
                <td><%=LanguageHelper.GetMessage("Register_Tip_Name") %></td>
                <td>
                    <asp:TextBox ID="txt_name" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td><%=LanguageHelper.GetMessage("Register_Tip_Phone") %></td>
                <td>
                    <asp:TextBox ID="txt_phone" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td><%=LanguageHelper.GetMessage("Register_Tip_Age") %></td>
                <td>
                    <asp:TextBox ID="txt_age" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btn_register" runat="server" Text="注册" OnClientClick="return register();" OnClick="btn_register_Click"/>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
