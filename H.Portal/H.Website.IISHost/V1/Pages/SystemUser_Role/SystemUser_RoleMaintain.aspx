<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SystemUser_RoleMaintain.aspx.cs" Inherits="H.Website.IISHost.Pages.SystemUser_Role.SystemUser_RoleMaintain" %>

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
                        <div class="Tit"><b>角色信息</b><u class="icon3">&nbsp;</u></div>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="editBody">
                <tr>
                    <td style="width: 200px; text-align: right;">
                        <font>角色名：</font>
                    </td>
                    <td style="width: 200px; text-align: right;">
                        <input type="text" value="" name="RoleName" id="RoleName" class="ipt" datatype="*validateRoleName"/>
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
                        <div class="Tit"><b>权限信息</b><u class="icon3">&nbsp;</u></div>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="editBody">
                <tr>
                    <td align="center">
                        <div style="width:90%; border:0px solid red; height:200px;">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <asp:Repeater ID="rp_parentPrivilege" runat="server" OnItemDataBound="rp_parentPrivilege_ItemDataBound">
                                    <ItemTemplate>
                                        <tr>
                                            <td style="width:100px; text-align:right; padding-right:10px; font-size:12px; font-weight:bold;">
                                                <%#Eval("PrivilegeName") %>：
                                                <asp:HiddenField ID="hideSysNo" runat="server" Value='<%#Eval("SysNo") %>'/>
                                            </td>
                                            <td>
                                                <asp:Repeater ID="rp_childPrivilege" runat="server">
                                                    <ItemTemplate>
                                                        <input type="checkbox" value="<%#Eval("SysNo") %>" name="che_privilege"/><span style="cursor:pointer;" onclick="$(this).prev().attr('checked',!$(this).prev().attr('checked'))"><%#Eval("PrivilegeName") %></span>
                                                        &nbsp;&nbsp;
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                                
                            </table>
                        </div>
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
            var systemUser_RoleMaintain = {
                SysNo: 0,
                init: function () {
                    this.initEntity();
                    this.initValidate();
                },
                initEntity: function () {
                    this.SysNo = $.hFramework.querystring.get("sysNo");
                    if (this.SysNo && this.SysNo != 0) {
                        var result = Portal.SystemUser_RoleMaintain.LoadEntity(this.SysNo);
                        if (result.error) {
                            document.write(result.error.Message);
                        } else {
                            $("#RoleName").val(result.value.RoleName);
                            this.setPrivilege(result.value.PrivilegeList);
                        }
                    }
                },
                initValidate: function () {
                    var _self = this;
                    $(".validateForm").Validform({
                        btnSubmit: "#a_submit",
                        tiptype: 2,
                        datatype: {
                            "*validateRoleName": function (gets, obj, curform, regxp) {
                                var reg1 = /^[^\s]{2,50}$/;
                                if (!reg1.test(gets)) {
                                    return "请输入2-50位字符!";
                                }
                                var flag = _self.validateRoleName(gets);
                                if (flag) {
                                    return true;
                                }
                                else {
                                    $(obj).focus();
                                    return "角色名已存在,请重新输入!";
                                }
                            }                            
                        },
                        beforeSubmit: function (curform) {
                            var entity = {
                                SysNo: systemUser_RoleMaintain.SysNo == "" ? 0 : systemUser_RoleMaintain.SysNo,
                                RoleName: $("#RoleName").val(),
                                PrivilegeList : systemUser_RoleMaintain.getPrivilege()
                            };
                            var result = Portal.SystemUser_RoleMaintain.Create(entity);
                            if (result.error) {
                                document.write(result.error.Message);
                            } else {
                                if (result.value != "0") {
                                    $.alert("提交成功!");
                                } else {
                                    $.alert("提交失败!");
                                }
                            }
                            return false;
                        }
                    });
                },
                validateRoleName: function (roleName) {
                    var value = Portal.SystemUser_RoleMaintain.ByRoleNameGetInfo(roleName, this.SysNo).value;
                    if (value == 1)
                        return true;
                    else
                        return false;
                },
                setPrivilege: function (privilegeList) {
                    for (var i = 0; i < privilegeList.length; i++) {
                        $("input:checkbox[name='che_privilege'][value='" + privilegeList[i].SysNo + "']").attr("checked", "true");
                    }
                },
                getPrivilege: function () {
                    var PrivilegeList = new Array();
                    $("input:checkbox[name='che_privilege']:checked").each(function () {
                        var privilege = {
                            SysNo: $(this).val()
                        };
                        PrivilegeList.push(privilege);
                    });
                    return PrivilegeList;
                }
            };
            $(function () {
                systemUser_RoleMaintain.init();
            });
        </script>
    </form>
</body>
</html>