<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SystemUser_PrivilegeMaintain.aspx.cs" Inherits="H.Website.IISHost.Pages.SystemUser_Privilege.SystemUser_PrivilegeMaintain" %>

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
                        <div class="Tit"><b>权限信息</b><u class="icon3">&nbsp;</u></div>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="editBody">
                <tr>
                    <td style="width: 200px; text-align: right;">
                        <font>权限级别：</font>
                    </td>
                    <td style="width: 200px; text-align: right;">
                        <select class="ipt" name="ParentSysNo" id="ParentSysNo">
                            <option value="0">--顶级权限--</option>
                        </select>
                    </td>
                    <td>
                        <div class="Validform_checktip"></div>
                    </td>
                </tr>
                <tr>
                    <td style="width: 200px; text-align: right;">
                        <font>权限名：</font>
                    </td>
                    <td style="width: 200px; text-align: right;">
                        <input type="text" value="" name="PrivilegeName" id="PrivilegeName" class="ipt" datatype="*validatePrivilegeName"/>
                    </td>
                    <td>
                        <div class="Validform_checktip"></div>
                    </td>
                </tr>
                <tr>
                    <td style="width: 200px; text-align: right;">
                        <font>页&nbsp;面(PageAlice)：</font>
                    </td>
                    <td style="width: 200px; text-align: right;">
                        <input type="text" value="" name="PageAlice" id="PageAlice" class="ipt" datatype="*validatePageAlice" />
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
            var systemUser_PrivilegeMaintain = {
                SysNo : 0,
                init: function () {
                    this.loadParent();
                    this.initEntity();
                    this.initValidate();
                },
                initEntity: function () {
                    this.SysNo = $.hFramework.querystring.get("sysNo");
                    if (this.SysNo && this.SysNo != 0) {
                        var result = Portal.SystemUser_PrivilegeMaintain.LoadEntity(this.SysNo);
                        if (result.error) {
                            document.write(result.error.Message);
                        } else {
                            $("#PrivilegeName").val(result.value.PrivilegeName);
                            $("#PageAlice").val(result.value.PageAlice);
                            $("#ParentSysNo").val(result.value.ParentSysNo);
                        }
                    }
                },
                initValidate: function () {
                    var _self = this;
                    $(".validateForm").Validform({
                        btnSubmit: "#a_submit",
                        tiptype: 2,
                        datatype: {
                            "*validatePrivilegeName": function (gets, obj, curform, regxp) {
                                var reg1 = /^[^\s]{2,50}$/;
                                if (!reg1.test(gets)) {
                                    return "请输入2-50位字符!";
                                }
                                var flag = _self.validatePrivilegeName(gets);
                                if (flag) {
                                    return true;
                                }
                                else {
                                    $(obj).focus();
                                    return "权限名已存在,请重新输入!";
                                }
                            },
                            "*validatePageAlice": function (gets, obj, curform, regxp) {
                                var reg1 = /^[^\s]{2,50}$/;
                                if (!reg1.test(gets)) {
                                    return "请输入2-50位字符!";
                                }
                                var flag = _self.validatePageAlice(gets);
                                if (flag) {
                                    return true;
                                }
                                else {
                                    $(obj).focus();
                                    return "PageAlice已存在,请重新输入!";
                                }
                            }
                        },
                        beforeSubmit: function (curform) {
                            var entity = {
                                SysNo: systemUser_PrivilegeMaintain.SysNo == "" ? 0 : systemUser_PrivilegeMaintain.SysNo,
                                ParentSysNo: $("#ParentSysNo").val(),
                                PrivilegeName: $("#PrivilegeName").val(),
                                PageAlice: $("#PageAlice").val()
                            };
                            
                            var result = Portal.SystemUser_PrivilegeMaintain.Create(entity);
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
                validatePrivilegeName: function (privilegeName) {
                    var value = Portal.SystemUser_PrivilegeMaintain.ByPrivilegeNameGetInfo(privilegeName,this.SysNo).value;
                    if (value == 1)
                        return true;
                    else
                        return false;
                },
                validatePageAlice: function (pageAlice) {
                    var value = Portal.SystemUser_PrivilegeMaintain.ByPageAliceGetInfo(pageAlice, this.SysNo).value;
                    if (value == 1)
                        return true;
                    else
                        return false;
                },
                loadParent: function () {
                    Portal.SystemUser_PrivilegeMaintain.LoadParent(function (result) {
                        if (result.error) {
                            document.write(result.error.Message);
                        } else {
                            if (result.value)
                            {
                                var list = result.value;
                                for (var i = 0; i < list.length; i++) {
                                    if (systemUser_PrivilegeMaintain.SysNo != list[i].SysNo)
                                    {
                                        $("#ParentSysNo").append("<option value=\"" + list[i].SysNo + "\">" + list[i].PrivilegeName + "</option>");
                                    }
                                }
                            }
                        }
                    });
                }
            };
            $(function () {
                systemUser_PrivilegeMaintain.init();
            });
        </script>
    </form>
</body>
</html>
