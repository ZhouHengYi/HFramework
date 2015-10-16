<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Master.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="H.Website.IISHost.Page.Report.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_Head" runat="server">
    <style type="text/css">
        h4 {
            color: #555555;
            float: none;
            font-size: 14px;
            font-weight: normal;
            position: relative;
            text-shadow: 0 1px 0 #FFFFFF;
        }
    </style>
    
    <link rel="stylesheet" href="/WebResource/css/datepicker.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_Content" runat="server">
    <form id="Form1" runat="server">
        <div id="content-header">
            <div id="breadcrumb"><a href="#" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a> <a href="#" class="current">Dashboard</a></div>
            <h1><a href="http://www.elleshop.com.cn" target="_blank">ElleShop</a> 月度报表回顾</h1>

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
        <div class="container-fluid" style="padding-top:10px;">
            <div class="widget-box widget-plain">
                <div class="center">
                    <ul class="stat-boxes2">
                        <li title="共成交898个订单">
                            <div class="left peity_bar_bad">
                                <span><span style="display: none;">3,5,6,16,8,10,6</span>
                                    <canvas width="50" height="24"></canvas>
                                </span>-40%
                            </div>
                            <div class="right"><strong>898</strong> 共成交订单</div>
                        </li>
                        <li title="售出商品1433件">
                            <div class="left peity_bar_good"><span>12,6,9,23,14,10,13</span>+30%</div>
                            <div class="right"><strong>1433</strong> 售出商品(件)</div>
                        </li>
                        <li title="总金额923848.20元">                            
                            <div class="left peity_bar_good"><span>12,6,9,23,14,10,13</span>+30%</div>
                            <div class="right"><strong>923848.20</strong> 总金额(元)</div>
                        </li>
                        <li title="实付金额903773.68元">
                            <div class="left peity_bar_good"><span>12,6,9,23,14,10,13</span>+30%</div>
                            <div class="right"><strong>903773.68</strong> 实付金额(元)</div>
                        </li>
                    </ul>
                    <!--Chart-box-->
                    <div class="row-fluid">
                        <div class="widget-box">
                            <div class="widget-title bg_lg">
                                <span class="icon"><i class="icon-signal"></i></span>
                                <h5>Site Analytics</h5>
                            </div>
                            <div class="widget-content">
                                <div class="row-fluid">
                                    <div class="span9">
                                        <div class="chart"></div>
                                    </div>
                                    <div class="span3">
                                        <ul class="site-stats">                                                                                       
                                            <li class="bg_lh" title="共成交898个订单" id="li_order"><i class="icon-tag"></i><strong>898</strong> <small>共成交订单</small></li>
                                            <li class="bg_lh" title="新增注册用户1227人" id="li_people"><i class="icon-user"></i><strong>1227</strong> <small>新增注册用户</small></li> 
                                            <li class="bg_lh" title="售出商品1433件"><i class="icon-shopping-cart"></i><strong>1433</strong> <small>售出商品(件)</small></li>
                                            <li class="bg_lh" title="本月下订单人数928人"><i class="icon-repeat"></i><strong>928</strong> <small>下单人数</small></li>
                                            <li class="bg_lh" title="实际支付人数702人"><i class="icon-globe"></i><strong>702</strong> <small>实际支付人数</small></li>
                                            
                                            <li class="bg_lh"><i class="icon-plus"></i><strong>NULL</strong> <small>NULL</small></li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>                    
                    <hr />
                    <h4>共成交<b>898</b>个订单，
                        售出商品<b>1433</b>件，
                        总金额<b>923848.20</b>元，
                        促销优惠<b>20074.52</b>元，
                        实付金额<b>903773.68</b>元</h4>
                    <h4>平均每订单<b>1028.78</b>元，
                        成交商品均价<b>644.70</b>元</h4>
                    <h4>成交订单占总订单量的<b>59.51%</b></h4>
                    <h4>新增注册用户<b>1227</b>人，累计注册用户<b>67045</b>人</h4>                    
                    <h4>本月下订单人数<b>928</b>人，实际支付人数<b>702</b>人，其中<b>396</b>人为首次购买，<b>306</b>人为重复购买</h4>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_Bottom" runat="server">
    <script src="/WebResource/js/jquery.flot.min.js"></script>
    <script src="/WebResource/js/jquery.flot.pie.min.js"></script>
    <script src="/WebResource/js/jquery.peity.min.js"></script>
     
    <script src="/WebResource/js/bootstrap-datepicker.js"></script>
    <script type="text/javascript">
        maruti = {
            // === Peity charts === //
            peity: function () {
                $.fn.peity.defaults.line = {
                    strokeWidth: 1,
                    delimeter: ",",
                    height: 24,
                    max: null,
                    min: 0,
                    width: 50
                };
                $.fn.peity.defaults.bar = {
                    delimeter: ",",
                    height: 24,
                    max: null,
                    min: 0,
                    width: 50
                };
                $(".peity_line_good span").peity("line", {
                    colour: "#57a532",
                    strokeColour: "#459D1C"
                });
                $(".peity_line_bad span").peity("line", {
                    colour: "#FFC4C7",
                    strokeColour: "#BA1E20"
                });
                $(".peity_line_neutral span").peity("line", {
                    colour: "#CCCCCC",
                    strokeColour: "#757575"
                });
                $(".peity_bar_good span").peity("bar", {
                    colour: "#459D1C"
                });
                $(".peity_bar_bad span").peity("bar", {
                    colour: "#BA1E20"
                });
                $(".peity_bar_neutral span").peity("bar", {
                    colour: "#4fb9f0"
                });
            },

            // === Tooltip for flot charts === //
            flot_tooltip: function (x, y, contents) {

                $('<div id="tooltip">' + contents + '</div>').css({
                    top: y + 5,
                    left: x + 5
                }).appendTo("body").fadeIn(200);
            }
        }
    </script>

    <script type="text/javascript">
        $("#li_order").click(function () {
            var sin = [];
            sin.push([1, 100]);
            sin.push([2, 200]);
            sin.push([3, 500]);
            sin.push([4, 200]);
            sin.push([5, 40]);
            sin.push([6, 1000]);
            sin.push([7, 1200]);
            sin.push([8, 1050]);
            sin.push([9, 1100]);
            changeChart(sin,"订单", "#4fb9f0");
        });

        $("#li_people").click(function () {
            var sin = [];
            sin.push([1, 50]);
            sin.push([2, 30]);
            sin.push([3, 10]);
            sin.push([4, 100]);
            sin.push([5, 40]);
            sin.push([6, 70]);
            sin.push([7, 80]);
            sin.push([8, 90]);
            sin.push([9, 1100]);
            changeChart(sin, "用户", "#c0392b");
        });

        function changeChart(sin,lab,colr) {
            

            var thicks = [];
            for (var i = 1; i <= 30; i++) {
                thicks.push([i, i + "日"]);
            }

            // === Make chart === //
            var plot = $.plot($(".chart"),
                   [{ data: sin, label: lab, color: colr }], {
                       series: {
                           lines: { show: true },
                           points: { show: true }
                       },
                       grid: { hoverable: true, clickable: true },
                       xaxis: { ticks: thicks }
                   });



            // === Point hover in chart === //
            var previousPoint = null;
            $(".chart").bind("plothover", function (event, pos, item) {

                if (item) {
                    if (previousPoint != item.dataIndex) {
                        previousPoint = item.dataIndex;

                        $('#tooltip').fadeOut(200, function () {
                            $(this).remove();
                        });
                        var x = item.datapoint[0].toFixed(2),
                            y = item.datapoint[1].toFixed(2);

                        maruti2.flot_tooltip(item.pageX, item.pageY, item.series.label + " " + parseInt(x) + "日 = " + y);
                    }

                } else {
                    $('#tooltip').fadeOut(200, function () {
                        $(this).remove();
                    });
                    previousPoint = null;
                }
            });
            maruti2 = {
                // === Tooltip for flot charts === //
                flot_tooltip: function (x, y, contents) {

                    $('<div id="tooltip">' + contents + '</div>').css({
                        top: y + 5,
                        left: x + 5
                    }).appendTo("body").fadeIn(200);
                }
            }
        }

    </script>

    <script type="text/javascript">

        $(function () {
            var date = new Date();
            $("#txt_date").val(date.getFullYear() + "-" + (date.getMonth() + 1));
            $('.datepicker').datepicker({
                format: 'yyyy-mm',
                weekStart: 1,
                autoclose: true,
                todayBtn: 'linked',
                language: 'zh-CN'
            });

            // === Prepare peity charts === //
            maruti.peity();
            $("#li_order").click();
        });
    </script>
</asp:Content>
