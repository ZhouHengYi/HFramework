<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SystemLogin.aspx.cs" Inherits="H.Portal.IISHost.SystemLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>系统登陆</title>
    <link href="WebResource/css/css.css" rel="stylesheet" type="text/css" />
    <script src="WebResource/js/jquery.min-1.7.1.js" type="text/javascript"></script>
    <script src="WebResource/js/common.js" type="text/javascript"></script>
    <script src="WebResource/js/Base.js" type="text/javascript"></script>
</head>
<body style="background-color: #d1e5fd;">
    <form runat="server">
        <div class="loginbg">
            <div class="loginbox">
                <h4 class="login_logo">
                    <img src="WebResource/images/logo.jpg" width="82" height="45"/></h4>
                <div class="login_input">
                    <p>用户名：<input name="" type="text" class="iptsty" id="txt_UserName" runat="server"/></p>
                    <p>密&nbsp;&nbsp;&nbsp;码：<input name="" type="password" class="iptsty" style="margin-left: 2px;" id="txt_Pwd"/></p>
                    <p style="font-size:11px;" >
                       <input name="" type="checkbox" value="" class="chekboxsty" id="che_rem" runat="server"/><span style="cursor:pointer;" onclick="$('#che_rem').attr('checked',!$('#che_rem').attr('checked'))">记住我的信息</span>
                    </p>
                    <p>
                        <input name="" type="button" class="login_sub" id="btn_login" />
                    </p>
                </div>
            </div>
        </div>
    </form>
    <script type="text/ecmascript">
        $(function () {
            //回车事件,查询数据
            $(document).keyup(function (ev) {
                if (ev.keyCode == 13) {
                    $("#btn_login").click();
                    return false;
                }
            });
            $("#btn_login").click(function () {
                var returnUrl = $.hFramework.querystring.get("ReturnUrl");
                var userName = $("#<%=txt_UserName.ClientID%>").val();
                var pwd = $("#txt_Pwd").val();
                var rem = $("#<%=che_rem.ClientID%>").attr("checked");
                var reg1 = /^[^\s]{6,20}$/;
                if (!reg1.test(userName)) {
                    $.alert("请输入用户名6-20字符!");
                    return;
                }
                var reg2 = /^[^\s]{6,20}$/;
                if (!reg2.test(pwd)) {
                    $.alert("请输入密码6-20字符!");
                    return;
                }
                Portal.SystemLogin.Loging(returnUrl, userName, pwd, rem, function (ajaxResult) {
                    if (ajaxResult.error) {
                        $.alert(ajaxResult.error.Message);
                    } else {
                        var json = eval("(" + ajaxResult.value + ")");
                        if (json.Code == "OK") {
                            location.href = json.Return;
                        } else {
                            $.alert(json.Message);
                        }
                    }
                });
            });
        });
    </script>
</body>
</html>
