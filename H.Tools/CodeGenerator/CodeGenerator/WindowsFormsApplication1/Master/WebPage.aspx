<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Master.Master" AutoEventWireup="true" CodeBehind="$$$TableName$$$.aspx.cs" Inherits="H.Website.IISHost.Pages.$$$TableName$$$.$$$TableName$$$" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_Head" runat="server">

    <link rel="stylesheet" href="/WebResource/css/datepicker.css" />
    <link rel="stylesheet" href="/WebResource/css/select2.css" />
    <link href="../../WebResource/css/uniform.css" rel="stylesheet" />
    <link href="http://netdna.bootstrapcdn.com/font-awesome/4.0.3/css/font-awesome.min.css" rel="stylesheet">

    <style>
        #div_condition input {
            line-height: 0px;
        }

        #div_condition input {
            margin-top: 0px;
            margin-bottom: 0px;
            padding: 4px 6px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_Content" runat="server">
    <div id="content-header">
        <div id="breadcrumb"><a href="#" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a> <a href="#" class="current">$$$TableName$$$</a></div>
        <div id="div_condition" style="padding-left: 20px; padding-right: 20px; padding-top: 20px; display: block;" class="controls">
            <table style="width: 100%;">
                <tr>
                    <td width="40%">
                        <label style="padding-left: 2%;">
                            标题:
                                <input type="text" style="margin-left: 10px;" data-name="Title"></label></td>
                    <td width="50%">
                        <label>
                            创建日期:
                                <span class="add-on input-group-addon" style="padding: 0px 2px 0px 5px;">
                                    <i class="glyphicon glyphicon-calendar fa fa-calendar"></i></span>
                            <input type="text" style="width: 200px;" name="reservation" id="reservation2" class="form-control" value="03/18/2013 - 03/23/2013"  data-name="InDateCondition"/>
                        </label>
                    </td>
                    <td>
                        <button class="tip-bottom" type="button" data-original-title="Search" id="btn_search" style="margin-left: 5%;"><i class="icon-search icon-white"></i></button>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <form id="Form1" runat="server"></form>
    <div class="container-fluid">
        <div class="row-fluid">
            <div class="span12">
                <div class="widget-box">
                    <div class="widget-title">
                        <span class="icon"><i class="icon-th"></i></span>
                        <h5>DataList</h5>
                    </div>
                    <div class="widget-content nopadding">
                        <div role="grid" class="dataTables_wrapper" id="DataTables_Table_0_wrapper">
                            <table class="table table-bordered data-table dataTable" id="tbl_List">
                                <tr>
                                    <td width="3%">
                                        <input type="checkbox" name="title-table-checkbox" onclick="bindHelper.selectElement(this)" /></td>
                                    <td width="7%">系统编号</td>
                                    <td width="45%">标题</td>
                                    <td width="20%">创建人</td>
                                    <td width="20%">创建日期</td>
                                    <td style="text-align: center;">操作</td>
                                </tr>
                                <tr class="odd gradeX">
                                    <td width="3%" style="text-align: center;" bind="$.SysNo">
                                        <input type="checkbox" value="$.Value" name="selectElement" /></td>
                                    <td bind="$.SysNo" style="text-align: center;"></td>
                                    <td bind="$.Title"></td>
                                    <td bind="$.InUser"></td>
                                    <td bind="$.InDateStr"></td>
                                    <td bind="$.SysNo" width="5%" style="text-align: center;">
                                        <a href="javaScript:cg.maintain($.Value)">查看</a>
                                    </td>
                                </tr>
                            </table>
                            <div class="fg-toolbar ui-toolbar ui-widget-header ui-corner-bl ui-corner-br ui-helper-clearfix">
                                <div style="float: left; margin-top: 5px;">
                                    <button class="btn btn-info btn-large" style="font-size: 13.5px; padding: 5px 19px;" onclick="cg.add();">新增</button>
                                    <button class="btn btn-danger btn-large" style="font-size: 13.5px; padding: 5px 19px;" onclick="cg.deleteSel();">删除</button>
                                </div>
                                <div class="dataTables_paginate fg-buttonset ui-buttonset fg-buttonset-multi ui-buttonset-multi paging_full_numbers" style="float: right;" id="div_pager">

                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_Bottom" runat="server">
    <script src="/WebResource/js/jquery.uniform.js"></script>
    <script src="/WebResource/js/jquery.ui.custom.js"></script>
    <script src="/WebResource/js/bootstrap-datepicker.js"></script>
    <script src="/WebResource/js/select2.min.js"></script>
    <script src="/WebResource/CustomJs/bindHelper.js" charset="gbk"></script>

    <link href="/WebResource/js/bootstrap-daterangepicker/daterangepicker-bs3.css" rel="stylesheet" />
    <script src="/WebResource/js/bootstrap-daterangepicker/moment.js"></script>
    <script src="/WebResource/js/bootstrap-daterangepicker/daterangepicker.js"></script>

    <script type="text/javascript">
        $(function () {
            $('input[type=checkbox],input[type=radio],input[type=file]').uniform();
            $("#reservation2").val("");
            $('#reservation2').daterangepicker(null, function (start, end, label) {
                console.log(start.toISOString(), end.toISOString(), label);
            });

            bindHelper.AjaxProObject = Portal.University;
            bindHelper.init();

            $(".progress").remove();
        });

        var cg = {
            maintain: function (sysNo) {
                $.showWindow('维护信息', '<%=BuildUrl(H.Website.Facade.PageAlias.UniversityMaintain)%>?sysNo=' + sysNo + '&timer=' + new Date().getDate(), 700, 565);
            }, add: function () {
                $.showWindow('添加信息', '<%=BuildUrl(H.Website.Facade.PageAlias.UniversityMaintain)%>?timer=' + new Date().getDate(), 700, 565);
            },
            deleteSel: function () {
                var ids = bindHelper.getSelectElementSysNo();
                $.confirm("确定删除已选中数据吗？<br>系统编号为：" + ids, function () {
                    var result = Portal.Charge.Delete(ids);
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
</asp:Content>
