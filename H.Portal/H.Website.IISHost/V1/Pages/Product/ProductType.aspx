﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductType.aspx.cs" Inherits="H.Website.IISHost.Pages.Product.ProductType" %>

<%@ Register Src="../../UserContorl/Common/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../WebResource/css/css.css" rel="stylesheet" type="text/css" />
    <script src="../../WebResource/js/jquery.min-1.7.1.js" type="text/javascript"></script>
    <script src="../../WebResource/js/common.js" type="text/javascript"></script>
    <script src="../../WebResource/js/bindHelper.js" type="text/javascript" charset="gb2312"></script>
</head>
<body>
    <form id="Form1" runat="server">
        <div class="roud">
            <h4>控制面板 &gt; 商品分类管理</h4>
        </div>
        <div class="main">
            <span class="padding20px">
                <div class="Tit"><b>查询条件</b><u class="icon3">&nbsp;</u></div>
                <span class="blank10"></span>
                <div class="Consearch fl">
                    <div class="SHtab">
                        <ul id="taba">
                            <li onclick="taba_dturn(this,0)" class="onclick">基本信息</li>
                        </ul>
                    </div>
                    <div id="taba_0">
                        <div class="SHtabxial">
                            <div class="newpro">
                                <p>
                                    <span class="padleft">分类名：</span>
                                    <input type="text" class="ipt" data-name="ProductTypeName" />
                                    <span class="padleft">分类级别：</span>
                                    <select class="ipt" data-name="DropParentSysNo">
                                        <option value="-1">--请选择--</option>
                                        <option value="0">顶级分类</option>
                                        <asp:Literal ID="lit_parentSysNo" runat="server"></asp:Literal>
                                    </select>
                                </p>
                            </div>
                        </div>
                        <div class="tipsInfo_top" id="span_cmdTip">
                        </div>
                    </div>
                </div>
                <div class="Consearch_sub fr">
                    <span class="blank20" style="height: 37px;"></span>
                    <a id="btn_search">
                        <div class="sub">查询</div>
                    </a>
                    <span class="blank20"></span>
                    <a id="btn_clear">
                        <div class="sub">重置</div>
                    </a>
                </div>
                <div class="clr"></div>
                <div class="Tit"><b>查询结果</b><u class="icon3">&nbsp;</u></div>
                <span class="blank10"></span>
                <div class="divtab">
                    <table width="100%" border="0" cellspacing="1" cellpadding="0" style="text-align: center;" id="tbl_List">
                        <tr style="background-color: #dedede">
                            <td width="5%">
                                <input name="" type="checkbox" value="" onclick="bindHelper.selectElement(this)"/></td>
                            <td width="5%">编辑</td>
                            <td width="5%">系统编号</td>
                            <td width="40%">分类名</td>
                            <td width="15%">分类级别</td>
                            <td width="10%">创建人</td>
                            <td width="20%">创建日期</td>
                        </tr>
                        <tr>
                            <td bind="$.SysNo">
                                <input type="checkbox" value="$.Value" name="selectElement"/></td>
                            <td bind="$.SysNo">
                                <a href="javaScript:productType.maintain($.Value)">编辑</a>
                            </td>
                            <td bind="$.SysNo"></td>
                            <td bind="$.ProductTypeName"></td>
                            <td bind="$.ParentName" style="font-weight:bold;"></td>
                            <td bind="$.InUser"></td>
                            <td bind="$.InDateStr"></td>
                        </tr>
                    </table>
                </div>
                <script type="text/javascript">
                    $(function () {
                        bindHelper.AjaxProObject = Portal.ProductType;
                        bindHelper.init();
                    });

                    var productType = {
                        maintain: function (sysNo) {
                            $.showWindow('商品分类信息维护', 'ProductTypeMaintain.aspx?sysNo=' + sysNo + '&timer=' + new Date().getDate(), 700, 200);
                        },
                        deleteSel: function () {
                            var ids = bindHelper.getSelectElementSysNo();
                            $.confirm("确定删除已选中数据吗？<br>系统编号为：" + ids, function () {
                                var result = Portal.ProductType.Delete(ids);
                                if (result.error) {
                                    document.write(result.error.Message);
                                } else {
                                    var value = result.value;
                                    $.Tip("本次已成功删除：" + value + "条数据！");
                                    bindHelper.search();
                                }
                            });
                        }
                    };
                </script>
            </span>
        </div>
        <div class="footer2">
            <uc1:Footer ID="Footer1" runat="server" />
        </div>
        <div class="footer">
            <span class="padding10px">
                <a href="#">
                    <img src="../../WebResource/images/footer_09.jpg" style="float: right;" /></a>
                <h4>
                    <p class="sub2" onclick="$.showWindow('创建商品分类','ProductTypeMaintain.aspx',700,200);"><a href="javaScript:void(0);">添加</a></p>
                    <p class="sub2" onclick="productType.deleteSel();"><a href="javaScript:void(0);">删除</a></p>
                </h4>
            </span>
        </div>
    </form>
</body>
</html>
