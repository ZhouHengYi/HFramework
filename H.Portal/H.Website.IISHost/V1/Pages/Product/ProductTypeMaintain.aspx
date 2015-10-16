<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductTypeMaintain.aspx.cs" Inherits="H.Website.IISHost.Pages.Product.ProductTypeMaintain" %>

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
                        <div class="Tit"><b>商品分类信息</b><u class="icon3">&nbsp;</u></div>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="editBody">
                <tr>
                    <td style="width: 200px; text-align: right;">
                        <font>分类级别：</font>
                    </td>
                    <td style="width: 200px; text-align: right;">
                        <select class="ipt" name="ParentSysNo" id="ParentSysNo">
                            <option value="0">--顶级分类--</option>
                        </select>
                    </td>
                    <td>
                        <div class="Validform_checktip"></div>
                    </td>
                </tr>
                <tr>
                    <td style="width: 200px; text-align: right;">
                        <font>分类名：</font>
                    </td>
                    <td style="width: 200px; text-align: right;">
                        <input type="text" value="" name="ProductTypeName" id="ProductTypeName" class="ipt" datatype="*validateProductTypeName"/>
                    </td>
                    <td>
                        <div class="Validform_checktip"></div>
                    </td>
                </tr>
                <tr>
                    <td style="width: 200px; text-align: right;">
                        <font>排序：</font>
                    </td>
                    <td style="width: 200px; text-align: left;">
                        <input type="text" value="1" name="Order" id="Order" class="ipt" datatype="n1-88888" style="width:50px;" />
                        (越大越靠前Desc)
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
            var productTypeMaintain = {
                SysNo: 0,
                init: function () {
                    this.loadParent();
                    this.initEntity();
                    this.initValidate();
                },
                initEntity: function () {
                    this.SysNo = $.hFramework.querystring.get("sysNo");
                    if (this.SysNo && this.SysNo != 0) {
                        var result = Portal.ProductTypeMaintain.LoadEntity(this.SysNo);
                        if (result.error) {
                            document.write(result.error.Message);
                        } else {
                            $("#ProductTypeName").val(result.value.ProductTypeName);
                            $("#Order").val(result.value.Order);
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
                            "*validateProductTypeName": function (gets, obj, curform, regxp) {
                                var reg1 = /^[^\s]{1,50}$/;
                                if (!reg1.test(gets)) {
                                    return "请输入1-50位字符!";
                                }
                                var flag = _self.validateProductTypeName(gets);
                                if (flag) {
                                    return true;
                                }
                                else {
                                    $(obj).focus();
                                    return "分类名已存在,请重新输入!";
                                }
                            }
                        },
                        beforeSubmit: function (curform) {
                            var entity = {
                                SysNo: productTypeMaintain.SysNo == "" ? 0 : productTypeMaintain.SysNo,
                                ParentSysNo: $("#ParentSysNo").val(),
                                ProductTypeName: $("#ProductTypeName").val(),
                                Order: $("#Order").val()
                            };

                            var result = Portal.ProductTypeMaintain.Create(entity);
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
                validateProductTypeName: function (productTypeName) {
                    var value = Portal.ProductTypeMaintain.ByProductTypeNameGetInfo(productTypeName, this.SysNo).value;
                    if (value == 1)
                        return true;
                    else
                        return false;
                },
                loadParent: function () {
                    Portal.ProductTypeMaintain.LoadParent(function (result) {
                        if (result.error) {
                            document.write(result.error.Message);
                        } else {
                            if (result.value) {
                                var list = result.value;
                                for (var i = 0; i < list.length; i++) {
                                    if (productTypeMaintain.SysNo != list[i].SysNo) {
                                        $("#ParentSysNo").append("<option value=\"" + list[i].SysNo + "\">" + list[i].ProductTypeName + "</option>");
                                    }
                                }
                            }
                        }
                    });
                }
            };
            $(function () {
                productTypeMaintain.init();
            });
        </script>
    </form>
</body>
</html>
