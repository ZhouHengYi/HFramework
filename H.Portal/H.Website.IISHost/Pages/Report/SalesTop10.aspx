<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Master.Master" AutoEventWireup="true" CodeBehind="SalesTop10.aspx.cs" Inherits="H.Website.IISHost.Page.Report.SalesTop10" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_Head" runat="server">

    <link rel="stylesheet" href="/WebResource/css/datepicker.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_Content" runat="server">
    <form runat="server">
    <div id="content-header">
        <div id="breadcrumb"><a href="#" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a> <a href="#" class="current">单品销售Top 10</a></div>
        <div id="div_condition" style="padding-left: 20px; padding-right: 20px; padding-top: 20px;" class="controls">
            <div class="input-append date">
                <span class="add-on" style="border: 0px;">Date：</span>
            </div>
            <div data-date="2014-04" class="input-append date datepicker">
                <input type="text" value="2014-04" data-date-format="yyyy-mm" class="span11" style="width: 200px;" id="txt_date">
                <span class="add-on"><i class="icon-th"></i></span>
            </div>
            <div class="input-append date">
                <button type="button" class="btn btn-info" style="margin-left: 30px;" id="btn_search">Search</button>
            </div>
        </div>
    </div>
    <div class="accordion" id="collapse-group" style="padding-left: 20px; padding-right: 20px;">
        <div class="accordion-group widget-box">
            <div class="accordion-heading">
                <div class="widget-title">
                    <a data-parent="#collapse-group" href="#collapseGOne" data-toggle="collapse"><span class="icon"><i class="icon-th"></i></span>
                        <h5 id="h5_title">03月单品销售TOP10</h5>
                    </a>
                </div>
            </div>
            <div class="collapse in accordion-body" id="collapseGOne">
                <div class="widget-content nopadding">
                    <table class="table table-bordered table-striped" id="tbl_List">
                        <tr>
                            <th>商品商城编号</th>
                            <th>商品商家编号</th>
                            <th>品牌</th>
                            <th>商品名称</th>
                            <th>单价</th>
                            <th>供货商名称</th>
                            <th>月度销量</th>
                        </tr>
                        <tr class="odd gradeX">
                            <td bind="$.ProductID"></td>
                            <td bind="$.merchantProductID"></td>
                            <td bind="$.BrandName_Ch"></td>
                            <td bind="$.ProductName"></td>
                            <td bind="$.CurrentPrice"></td>
                            <td bind="$.VendorName"></td>
                            <td bind="$.TotalQty"></td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <br />
        <div class="accordion-group widget-box">
            <div class="accordion-heading">
                <div class="widget-title">
                    <a data-parent="#collapse-group" href="#collapseGTwo" data-toggle="collapse"><span class="icon"><i class="icon-th"></i></span>
                        <h5>历史单品销售TOP10</h5>
                    </a>
                </div>
            </div>
            <div class="collapse in accordion-body" id="collapseGTwo">
                <div class="widget-content nopadding">
                    <table class="table table-bordered table-striped" id="tbl_List2">
                        <tr>
                            <th>商品商城编号</th>
                            <th>商品商家编号</th>
                            <th>品牌</th>
                            <th>商品名称</th>
                            <th>单价</th>
                            <th>供货商名称</th>
                            <th>月度销量</th>
                        </tr>
                        <tr class="odd gradeX">
                            <td bind="$.ProductID"></td>
                            <td bind="$.merchantProductID"></td>
                            <td bind="$.BrandName_Ch"></td>
                            <td bind="$.ProductName"></td>
                            <td bind="$.CurrentPrice"></td>
                            <td bind="$.VendorName"></td>
                            <td bind="$.TotalQty"></td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_Bottom" runat="server">    
    <script src="/WebResource/js/bootstrap-datepicker.js"></script>
    <script src="/WebResource/CustomJs/common.js" type="text/javascript"></script>
    <script src="/WebResource/CustomJs/bindHelper.js?v=2" type="text/javascript" charset="gb2312"></script>
    <script type="text/javascript">
        var oldTr = $("#tbl_List tr").eq(1).html();
        $(function () {
            getALLSaleTopReport();
            var date = new Date();
            $("#txt_date").val(date.getFullYear() + "-" + (date.getMonth() + 1));
            $('.datepicker').datepicker({
                format: 'yyyy-mm',
                weekStart: 1,
                autoclose: true,
                todayBtn: 'linked',
                language: 'zh-CN'
            });
            $("#btn_search").click(function () {
                $("#h5_title").html($("#txt_date").val() + "月单品销售TOP10");
                $("#tbl_List").find("tr[name*='bind']").remove();
                getSaleTopReport();
            });
            $("#btn_search").click();
        });

        function getSaleTopReport() {
            $("#tbl_List").append('<tr name=\"tr_loading\"><td colspan="10"><div class="progress progress-striped active"><div class="bar" style="width: 100%;"></div></div></td><tr>');
            bindHelper.trHtml = oldTr;
            Portal.SalesTop10.GetSaleTopReport($("#txt_date").val(), function (ajaxResult) {
                bindHelper.bind(ajaxResult, $("#tbl_List"));
            });
        }

        function getALLSaleTopReport(){
            Portal.SalesTop10.GetALLSaleTopReport(function (ajaxResult) {
                bindHelper.bind(ajaxResult, $("#tbl_List2"));
            });
        }
    </script>
</asp:Content>
