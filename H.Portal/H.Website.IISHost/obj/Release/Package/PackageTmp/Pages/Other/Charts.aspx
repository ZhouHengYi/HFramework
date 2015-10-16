<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Master.Master" AutoEventWireup="true" CodeBehind="Charts.aspx.cs" Inherits="H.Website.IISHost.Page.Charts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_Content" runat="server">
    <div id="content-header">
        <div id="breadcrumb"><a href="#" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a> <a href="#" class="current">Charts &amp; graphs</a></div>
        <h1>Charts &amp; graphs</h1>
    </div>
    <div class="accordion" id="collapse-group" style=" padding-left:20px; padding-right:20px;">
        <div class="accordion-group widget-box">
            <div class="accordion-heading">
                <div class="widget-title">
                    <a data-parent="#collapse-group" href="#collapseGOne" data-toggle="collapse"><span class="icon"><i class="icon-ok"></i></span>
                        <h5>Data List</h5>
                    </a>
                </div>
            </div>
            <div class="collapse in accordion-body" id="collapseGOne">
                <div class="widget-content">This is opened by default </div>
            </div>
        </div>
        <div class="accordion-group widget-box">
            <div class="accordion-heading">
                <div class="widget-title">
                    <a data-parent="#collapse-group" href="#collapseGTwo" data-toggle="collapse"><span class="icon"><i class="icon-signal"></i></span>
                        <h5>Charts</h5>
                    </a>
                </div>
            </div>
            <div class="collapse accordion-body" id="collapseGTwo">
                <div class="widget-content">Another is open </div>
            </div>
        </div>        
    </div>
    <div class="container-fluid">
        <div class="row-fluid">
            <div class="span12">
                <div class="widget-box">
                    <div class="widget-title">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <h5>Turning-series chart</h5>
                    </div>
                    <div class="widget-content">
                        <div id="placeholder"></div>
                        <p id="choices"></p>
                    </div>
                </div>
            </div>
        </div>
        <div class="row-fluid">
            <div class="span6">
                <div class="widget-box">
                    <div class="widget-title">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <h5>Pie chart</h5>
                    </div>
                    <div class="widget-content">
                        <div class="pie"></div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row-fluid">
                <div class="span12">
                    <div class="widget-box">
                        <div class="widget-title">
                            <span class="icon"><i class="icon-signal"></i></span>
                            <h5>Bar chart</h5>
                        </div>
                        <div class="widget-content">
                            <div class="chart"></div>
                        </div>
                    </div>
                </div>
            </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_Bottom" runat="server">
    <script src="../WebResource/js/jquery.flot.min.js"></script>
    <script src="../WebResource/js/jquery.flot.pie.min.js"></script>

    <!--Turning-series-chart-js-->
    <script type="text/javascript">
        $(function () {
            datasets = {
                "商品分类1": { label: "商品分类1", data: [] },
                "商品分类2": { label: "商品分类2", data: [] },
                "商品分类3": { label: "商品分类3", data: [] },
                "商品分类4": { label: "商品分类4", data: [] },
            };

            datasets.商品分类1.data.push([1, 100]);
            datasets.商品分类1.data.push([2, 200]);
            datasets.商品分类1.data.push([3, 500]);
            datasets.商品分类1.data.push([4, 200]);
            datasets.商品分类1.data.push([5, 40]);
            datasets.商品分类1.data.push([6, 1000]);
            datasets.商品分类1.data.push([7, 1200]);
            datasets.商品分类1.data.push([8, 1050]);
            datasets.商品分类1.data.push([9, 1100]);

            // hard-code color indices to prevent them from shifting as
            // countries are turned on/off
            var i = 0;
            $.each(datasets, function (key, val) {
                val.color = i;
                ++i;
            });

            // insert checkboxes 
            var choiceContainer = $("#choices");
            $.each(datasets, function (key, val) {
                choiceContainer.append('<br/><input type="checkbox" name="' + key +
                                       '" checked="checked" id="id' + key + '">' +
                                       '<label for="id' + key + '">'
                                        + val.label + '</label>');
            });
            choiceContainer.find("input").click(plotAccordingToChoices);


            function plotAccordingToChoices() {
                var data = [];

                choiceContainer.find("input:checked").each(function () {
                    var key = $(this).attr("name");
                    if (key && datasets[key])
                        data.push(datasets[key]);
                });

                if (data.length > 0)
                    $.plot($("#placeholder"), data, {
                        yaxis: { min: 0 },
                        xaxis: { tickDecimals: 0 }
                    });
            }

            plotAccordingToChoices();
        });
</script>
    <script type="text/ecmascript">
        $(document).ready(function () {
            var data = [];
            var series = 2;

            data[0] = { label: "Series1", data: 2 }
            data[1] = { label: "Series2", data: 2 }

            var pie = $.plot($(".pie"), data, {
                series: {
                    pie: {
                        show: true,
                        radius: 3 / 4,
                        label: {
                            show: true,
                            radius: 3 / 4,
                            formatter: function (label, series) {
                                return '<div style="font-size:8pt;text-align:center;padding:2px;color:white;">' + label + '<br/>' + Math.round(series.percent) + '%</div>';
                            },
                            background: {
                                opacity: 0.5,
                                color: '#000'
                            }
                        },
                        innerRadius: 0.2
                    },
                    legend: {
                        show: false
                    }
                }
            });
           
        });
    </script>
    <script type="text/javascript">
        // === Prepare the chart data ===/
        var sin = [], cos = [];
        //for (var i = 0; i < 14; i += 0.5) {
        //    sin.push([i, Math.sin(i)]);
        //    cos.push([i, Math.cos(i)]);
        //}

        sin.push([1, 100]);
        sin.push([2, 200]);
        sin.push([3, 500]);
        sin.push([4, 200]);
        sin.push([5, 40]);
        sin.push([6, 1000]);
        sin.push([7, 1200]);
        sin.push([8, 1050]);
        sin.push([9, 1100]);

        var thicks = [];
        for (var i = 1; i <= 30; i++) {
            thicks.push([i, i + "日"]);
        }

        // === Make chart === //
        var plot = $.plot($(".chart"),
               [{ data: sin, label: "商品分类1", color: "#ee7951" }, { data: cos, label: "cos(x)", color: "#4fb9f0" }], {
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

                    maruti.flot_tooltip(item.pageX, item.pageY, item.series.label + " " + parseInt(x) + "日 = " + y);
                }

            } else {
                $('#tooltip').fadeOut(200, function () {
                    $(this).remove();
                });
                previousPoint = null;
            }
        });
        maruti = {
            // === Tooltip for flot charts === //
            flot_tooltip: function (x, y, contents) {

                $('<div id="tooltip">' + contents + '</div>').css({
                    top: y + 5,
                    left: x + 5
                }).appendTo("body").fadeIn(200);
            }
        }

    </script>
</asp:Content>
