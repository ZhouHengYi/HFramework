<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="H.Website.IISHost.Login" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <title>苏州君和诚信会计师事务所管理系统</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="WebResource/css/bootstrap.min.css" />
    <link rel="stylesheet" href="WebResource/css/bootstrap-responsive.min.css" />
    <link rel="stylesheet" href="WebResource/css/matrix-login.css" />
    <link href="WebResource/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:400,700,800' rel='stylesheet' type='text/css'>
</head>
<body>

    <div id="loginbox">

        <div class="control-group normal_text">
            <h3>
                <img src="WebResource/img/logo.png" alt="Logo" /></h3>
        </div>
        <form id="loginform" runat="server" class="form-vertical" tag="loginform">
            <div class="control-group">
                <div class="controls">
                    <div class="main_input_box">
                        <span class="add-on bg_lg"><i class="icon-user"></i></span>
                        <input type="text" placeholder="Username" runat="server" id="txt_LoginName" />
                    </div>
                </div>
            </div>
            <div class="control-group">
                <div class="controls">
                    <div class="main_input_box">
                        <span class="add-on bg_ly"><i class="icon-lock"></i></span>
                        <input type="password" placeholder="Password" runat="server" id="txt_LoginPwd" />
                    </div>
                </div>
            </div>
            <div class="form-actions">
                <span class="pull-left"><a href="javaScript:void(0);" class="flip-link btn btn-info" id="to-recover">新用户,请戳着试试看?</a></span>
                <span class="pull-right"><a type="submit" href="#" class="btn btn-success" id="btn_login">登 陆</a></span>
            </div>
        </form>
        <form id="recoverform" action="#" class="form-vertical">
            <p class="normal_text">请点击发送将您的机器登陆名发送至我们系统..</p>
            <div class="controls">
                <div class="main_input_box">
                    <span class="add-on bg_lg"><i class="icon-user"></i></span>
                    <input type="text" placeholder="Username" runat="server" id="txt_NewLoginName" class="NewLoginName" />
                </div>
                <div class="main_input_box">
                    <span class="add-on bg_lo"><i class="icon-envelope"></i></span>
                    <%--<input type="text" placeholder="Email Address" runat="server" id="txt_Email" class="txt_Email" style="width:56.7%;"/>
                    <span style="color:white">@hearst.com.cn</span>--%>
                    <input type="text" placeholder="Email Address" runat="server" id="txt_Email" class="txt_Email"/>
                    <%--<span style="color:white">@qq.com</span>--%>
                </div>
            </div>

            <div class="form-actions">
                <span class="pull-left"><a href="javaScript:void(0);" class="flip-link btn btn-success" id="to-login">&laquo; 返回</a></span>
                <span class="pull-right"><a class="btn btn-info" id="btn_Send">发送</a></span>
            </div>
        </form>
    </div>

    <script src="WebResource/js/jquery.min.js"></script>
    <script src="WebResource/CustomJs/common.js" type="text/javascript"></script>
    <script src="WebResource/CustomJs/Base.js" type="text/javascript"></script>
    <script src="WebResource/js/matrix.login.js" charset="gb2312"></script>
</body>

</html>

