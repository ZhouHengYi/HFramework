<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Master.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="H.Website.IISHost.Page.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_Content" runat="server">
    <div id="content-header">
        <div id="breadcrumb"><a href="#" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a> <a href="javaScript:void(0);">Dashboard</a></div>
    </div>
    <div class="container-fluid">
        <div class="quick-actions_homepage">
            <ul class="quick-actions">
                <li class="bg_lb"><a href="javaScript:void(0);"><i class="icon-dashboard"></i><%--<span class="label label-important">20</span>--%> My Dashboard </a></li>
                <li class="bg_lg span3"><a href="TeamBuilding.aspx"><i class="icon-home"></i>Team Building</a> </li>
                <li class="bg_ly"><a href="OnlineUser.aspx"><i class="icon-user"></i><span class="label label-success">101</span> Register User </a></li>
            </ul>
        </div>
        <div class="row-fluid">
            <div class="span6">
                <div class="widget-box">
                    <div class="widget-title">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <h5>大家都去哪</h5>
                    </div>
                    <div class="widget-content">
                        <div class="pie"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_Bottom" runat="server">
    
    <script src="../WebResource/js/jquery.flot.min.js"></script>
    <script src="../WebResource/js/jquery.flot.pie.min.js"></script>

    <script type="text/ecmascript">
        $(document).ready(function () {
            var data = [];
            var series = 2;

            data[0] = { label: "日本-东京", data: 90 }
            data[1] = { label: "韩国-首尔", data: 5 }
            data[2] = { label: "未参与", data: 5 }

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
</asp:Content>
