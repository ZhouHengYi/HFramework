<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SystemUserMaintain.aspx.cs" Inherits="H.Website.IISHost.Pages.SystemUser.SystemUserMaintain" %>
<%@ Register src="../../UserContorl/SystemUser/SystemUser_RoleMapping.ascx" tagname="SystemUser_RoleMapping" tagprefix="uc1" %>

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
                        <input type="text" value="" name="UserName" id="UserName" class="ipt" datatype="*register"/>
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
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="editHead">
                <tr>
                    <td width="5%">&nbsp;</td>
                    <td>
                        <div class="Tit"><b>角色信息</b><u class="icon3">&nbsp;</u></div>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="editBody">
                <tr>
                    <td align="center">
                        <uc1:SystemUser_RoleMapping ID="SystemUser_RoleMapping1" runat="server" />                        
                    </td>
                </tr>
            </table>
        </div>
        <div class="footer">
            <span class="padding10px">
                <a href="javaScript:void(0);" id="a_submit">
                    <img src="../../WebResource/images/footer_06.jpg" /></a>
            </span>
        </div>


        <script type="text/javascript">
            var systemUserMaintain = {
                init: function () {
                    this.initValidate();                    
                },
                initValidate:function(){
                    var _self = this;
                    $(".validateForm").Validform({
                        btnSubmit: "#a_submit",
                        tiptype: 2,
                        datatype: {
                            "*register": function (gets, obj, curform, regxp) {
                                var reg1 = /^[^\s]{6,20}$/;
                                if (!reg1.test(gets)) {
                                    return "请输入6-20位字符!";
                                }
                                var flag = _self.validateUserName(gets);
                                if (flag) {
                                    return true;
                                }
                                else {
                                    $(obj).focus();
                                    return "用户名已存在,请重新输入!";
                                }
                            }
                        },
                        beforeSubmit: function (curform) {
                            var entity = {
                                UserName: $("#UserName").val(),
                                Password: $("#Password").val(),
                                Role: systemUserMaintain.getRole()
                            };
                            var _self = this;
                            var result = Portal.SystemUserMaintain.Create(entity);
                            if (result.error) {
                                document.write(result.error.Message);
                            } else {
                                if (result.value != "0") {
                                    $.alert("添加成功!");
                                } else {
                                    $.alert("添加失败!");
                                }
                            }
                            return false;
                        }
                    });
                },
                validateUserName :function(userName) {
                    var value = Portal.SystemUserMaintain.ByUserNameGetInfo(userName).value;
                    if (value == 1)
                        return true;
                    else
                        return false;
                },
                getRole: function () {
                    var Role = new Array();
                    $("input:checkbox[name='che_role']:checked").each(function () {
                        var role = {
                            SysNo: $(this).val()
                        };
                        Role.push(role);
                    });
                    return Role;
                }
            };
            $(function () {
                systemUserMaintain.init();
            });
        </script>
    </form>
</body>
</html>
