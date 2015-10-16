<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdatePassword.aspx.cs" Inherits="H.Website.IISHost.Pages.SystemUser.UpdatePassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../WebResource/css/css.css" rel="stylesheet" type="text/css" />
    <script src="../../WebResource/js/jquery.min-1.7.1.js"></script>
    <script src="../../WebResource/js/Base.js"></script>
    <script src="../../WebResource/js/common.js"></script>
    <script src="../../WebResource/js/validate/Validform_v5.3.2_min.js"></script>
</head>
<body style="background-color:white;">
    <form id="Form1" runat="server" class="validateForm">
        <div>
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="editHead">
                <tr>
                    <td width="5%">&nbsp;</td>
                    <td>
                        <div class="Tit"><b>用户信息</b><u class="icon3">&nbsp;</u></div>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="editBody">
                <tr>
                    <td style="width: 200px; text-align: right;">
                        <font>用户名：</font>
                    </td>
                    <td style="width: 200px; text-align: right;">
                        <input type="text" value="" name="UserName" id="UserName" class="ipt" datatype="*6-20"/>
                    </td>
                    <td>
                        <div class="Validform_checktip"></div>
                    </td>
                </tr>
                <tr>
                    <td style="width: 200px; text-align: right;">
                        <font>原始密码：</font>
                    </td>
                    <td style="width: 200px; text-align: right;">
                        <input type="password" value="" name="OldPassword" id="OldPassword" class="ipt" datatype="*oldPassword" />
                    </td>
                    <td>
                        <div class="Validform_checktip"></div>
                    </td>
                </tr>
                <tr>
                    <td style="width: 200px; text-align: right;">
                        <font>密&nbsp;码：</font>
                    </td>
                    <td style="width: 200px; text-align: right;">
                        <input type="password" value="" name="Password" id="Password" class="ipt" datatype="*6-20" />
                    </td>
                    <td>
                        <div class="Validform_checktip"></div>
                    </td>
                </tr>
                <tr>
                    <td style="width: 200px; text-align: right;">
                        <font>确认密码：</font>
                    </td>
                    <td style="width: 200px; text-align: right;">
                        <input type="password" value="" name="Password2" class="ipt" datatype="*" recheck="Password" />
                    </td>
                    <td>
                        <div class="Validform_checktip"></div>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <br />
        <br />
        <div class="footer">
            <span class="padding10px">
                <a href="javaScript:void(0);" id="a_submit">
                    <img src="../../WebResource/images/footer_06.jpg" /></a>
            </span>
        </div>
        <script type="text/javascript">
            var updatePassword = {
                init: function () {
                    this.initEntity();
                    this.initValidate();
                },
                initEntity: function () {
                    var value = Portal.UpdatePassword.LoadEntity().value;
                    if (value) {
                        $("#UserName").val(value.UserName);
                        $("#UserName").attr("disabled", "disabled");
                    }
                },
                initValidate: function () {
                    var _self = this;
                    $(".validateForm").Validform({
                        btnSubmit: "#a_submit",
                        tiptype: 2,
                        datatype: {
                            "*oldPassword": function (gets, obj, curform, regxp) {
                                var reg1 = /^[^\s]{6,20}$/;
                                if (!reg1.test(gets)) {
                                    return "请输入6-20位字符!";
                                }
                                var flag = _self.validatePassword(gets);
                                if (flag) {
                                    return true;
                                }
                                else {
                                    $(obj).focus();
                                    return "原始密码输入错误!";
                                }
                            }
                        },
                        beforeSubmit: function (curform) {
                            var entity = {
                                UserName: $("#UserName").val(),
                                OldPassword: $("#OldPassword").val(),
                                Password: $("#Password").val()
                            };
                            var _self = this;
                            var flag = Portal.UpdatePassword.UpdatePasswordMethod(entity).value;
                            if (flag == "1") {
                                $.alert("修改成功!");
                            } else {
                                $.alert("修改失败!");
                            }
                            return false;
                        }
                    });
                },
                validatePassword: function (oldPassword) {
                    var value = Portal.UpdatePassword.ValidatePassword(oldPassword).value;
                    if (value == 1)
                        return true;
                    else
                        return false;
                }
            };
            $(function () {
                updatePassword.init();
            });
        </script>
    </form>
</body>
</html>
