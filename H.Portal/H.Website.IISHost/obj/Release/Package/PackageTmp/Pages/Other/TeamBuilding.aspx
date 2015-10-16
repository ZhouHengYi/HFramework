<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Master.Master" AutoEventWireup="true" CodeBehind="TeamBuilding.aspx.cs" Inherits="H.Website.IISHost.Page.TeamBuilding" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_Content" runat="server">
    <style>
        #content-header h3 {
            color: red;
            float: none;
            font-size: 16px;
            font-weight: normal;
            margin-left: 20px;
            position: relative;
            text-shadow: 0 1px 0 #FFFFFF;
        }
    </style>
    <div id="content-header">
        <div id="breadcrumb"><a class="tip-bottom" href="#" data-original-title="Go to Home"><i class="icon-home"></i>Home</a> <a class="current" href="#">Team Building</a> </div>
        <h1>一年一度的团建活动即将拉开大幕！赶紧抱团组队，背包出发吧！</h1>
        <h3>请点击列表左上角的<i class="icon-ok"></i>报名和<i class="icon-remove"></i>取消</h3>
    </div>
    <div class="container-fluid">
        <div class="row-fluid">
            <div class="span12">
                <div class="widget-box">
                    <div class="widget-title">
                        <span class="icon" style="cursor: pointer;" title="报名"><i class="icon-ok"></i></span>
                        <h5>东京 <code>推荐</code></h5>
                        <span style="float: right; padding: 9px 10px 7px 11px;" >
                            报名人数：<a href="#myModal2" data-toggle="modal">11</a></span>
                    </div>
                    <div class="widget-content" style="height:121px;">
                        <img src="../WebResource/images/canglaoshi.jpg" style="float:left; width:121px; height:121px; margin-right:15px;" />
                        作为日本的首都，东京为我们演绎了一个国际大都市的诸多特点。它时尚、繁华，却不失古朴传统；它是世界级的商业、金融中心，也是亚洲流行风潮的引领者，一座艺术之城；而小巷深处居酒屋的热烈亲切，洋溢平民气息的下町地区，动漫与高科技，各国文化的交融，为东京增添了更加多元包容的色彩。
                            集中了世界名店的银座，充满奇趣幻想的迪士尼，樱花烂漫的上野公园，被誉为不夜城的新宿，保留了日本传统文化精华的浅草，年轻人新潮文化发源地涩谷，未来主义风格的台场，众多兼具自然风物和人文历史的公园绿地，天气好的时候还能远眺富士山的美景……东京并非千篇一律的乏味城市，每个人都能在这个“超级城市体”找到自己的钟爱。
                            此外，温泉也是来东京不可错过的项目，有赖于日本四通八达的新干线与电车系统，除了东京的大江户温泉之外，东京周边触手可及的伊豆、箱根都是著名的温泉之乡。
                        
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid">
        <div class="row-fluid">
            <div class="span12">
                <div class="widget-box">
                    <div class="widget-title">
                        <span class="icon" style="cursor: pointer;" title="取消报名"><i class="icon-remove"></i></span>
                        <h5>首尔</h5>
                        <span style="float: right; padding: 9px 10px 7px 11px;">报名人数：11</span>
                    </div>
                    <div class="widget-content">没啥好玩的，上面的好玩！</div>
                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid">
        <div class="row-fluid">
            <div class="span12">
                <div class="widget-box">
                    <div class="widget-title">
                        <span class="icon" style="cursor: pointer;" title="该活动禁止报名"><i class="icon-question-sign"></i></span>
                        <h5>马来西亚</h5>
                        <span style="float: right; padding: 9px 10px 7px 11px;">报名人数：0</span>
                    </div>
                    <div class="widget-content">活动自费！</div>
                </div>
            </div>
        </div>
    </div>
    <%--<div class="fg-toolbar ui-toolbar ui-widget-header ui-corner-bl ui-corner-br ui-helper-clearfix">
        <div class="dataTables_paginate fg-buttonset ui-buttonset fg-buttonset-multi ui-buttonset-multi paging_full_numbers" id="DataTables_Table_0_paginate">
            <a class="first ui-corner-tl ui-corner-bl fg-button ui-button ui-state-default ui-state-disabled" tabindex="0" id="DataTables_Table_0_first">First</a>
            <a class="previous fg-button ui-button ui-state-default ui-state-disabled" tabindex="0" id="DataTables_Table_0_previous">Previous</a>
            <span>
                <a class="fg-button ui-button ui-state-default ui-state-disabled" tabindex="0">1</a>
                <a class="fg-button ui-button ui-state-default" tabindex="0">2</a>
                <a class="fg-button ui-button ui-state-default" tabindex="0">3</a>
                <a class="fg-button ui-button ui-state-default" tabindex="0">4</a>
                <a class="fg-button ui-button ui-state-default" tabindex="0">5</a>
            </span>
            <a class="next fg-button ui-button ui-state-default" tabindex="0" id="DataTables_Table_0_next">Next</a>
            <a class="last ui-corner-tr ui-corner-br fg-button ui-button ui-state-default" tabindex="0" id="DataTables_Table_0_last">Last</a>
        </div>
    </div>--%>
    <div id="myModal2" class="modal hide">
        <div class="modal-header">
            <button data-dismiss="modal" class="close" type="button">×</button>
            <h3>已报人员</h3>
        </div>
        <div class="modal-body">
            <div class="widget-content nopadding" style="overflow:scroll; height:300px;">
                <ul class="recent-posts">
                    <li>
                        <div class="user-thumb">
                            <img width="40" height="40" alt="User" src="../WebResource/img/demo/av1.jpg">
                        </div>
                        <div class="article-post">
                            <div class="fr"><a href="#myModal3" data-toggle="modal" class="btn btn-primary btn-mini">Details</a> <a href="#" class="btn btn-success btn-mini">Send</a></div>
                            <span class="user-info">By: john Deo / Date: 2 Aug 2012 / Time:09:27 AM </span>
                            <p><a href="#">This is a much longer one that will go on for a few lines.It has multiple paragraphs and is full of waffle to pad out the comment.</a> </p>
                        </div>
                    </li>
                    <li>
                        <div class="user-thumb">
                            <img width="40" height="40" alt="User" src="../WebResource/img/demo/av2.jpg">
                        </div>
                        <div class="article-post">
                            <div class="fr"><a href="#" class="btn btn-primary btn-mini">Details</a> <a href="#" class="btn btn-success btn-mini">Send</a></div>
                            <span class="user-info">By: john Deo / Date: 2 Aug 2012 / Time:09:27 AM </span>
                            <p><a href="#">This is a much longer one that will go on for a few lines.It has multiple paragraphs and is full of waffle to pad out the comment.</a> </p>
                        </div>
                    </li>
                    <li>
                        <div class="user-thumb">
                            <img width="40" height="40" alt="User" src="../WebResource/img/demo/av3.jpg">
                        </div>
                        <div class="article-post">
                            <div class="fr"><a href="#" class="btn btn-primary btn-mini">Details</a> <a href="#" class="btn btn-success btn-mini">Send</a></div>
                            <span class="user-info">By: john Deo / Date: 2 Aug 2012 / Time:09:27 AM </span>
                            <p><a href="#">This is a much longer one that will go on for a few lines.Itaffle to pad out the comment.</a> </p>
                        </div>
                    </li>
                    <li>
                        <div class="user-thumb">
                            <img width="40" height="40" alt="User" src="../WebResource/img/demo/av3.jpg">
                        </div>
                        <div class="article-post">
                            <div class="fr"><a href="#" class="btn btn-primary btn-mini">Details</a> <a href="#" class="btn btn-success btn-mini">Send</a></div>
                            <span class="user-info">By: john Deo / Date: 2 Aug 2012 / Time:09:27 AM </span>
                            <p><a href="#">This is a much longer one that will go on for a few lines.Itaffle to pad out the comment.</a> </p>
                        </div>
                    </li>
                </ul>
            </div>
        </div>
        <div class="modal-footer"><a data-dismiss="modal" class="btn btn-inverse" href="#">Cancel</a> </div>
    </div>

    <div id="myModal3" class="modal hide">
        <div class="modal-header">
            <button data-dismiss="modal" class="close" type="button">×</button>
            <h3>个人资料</h3>
        </div>
        <div class="modal-body">
            <table class="table table-bordered table-invoice">
                <tbody>
                    <tr>
                        <tr>
                            <td class="width30">姓名:</td>
                            <td class="width70"><strong>TD-6546</strong></td>
                        </tr>
                        <tr>
                            <td>个人邮箱:</td>
                            <td><strong>March 23, 2013</strong></td>
                        </tr>
                        <tr>
                            <td>性别:</td>
                            <td><strong>April 01, 2013</strong></td>
                        </tr>
                        <tr>
                            <td>年龄:</td>
                            <td><strong>April 01, 2013</strong></td>
                        </tr>
                        <tr>
                            <td>QQ:</td>
                            <td><strong>April 01, 2013</strong></td>
                        </tr>
                        <td class="width30">头像:</td>
                        <td class="width70"><strong>Cliente Company name.</strong>
                            <br>
                            501 Mafia Street., washington,
                            <br>
                            NYNC 3654
                            <br>
                            Contact No: 123 456-7890
                            <br>
                            Email: youremail@companyname.com </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="modal-footer"><a data-dismiss="modal" class="btn btn-inverse" href="#">Cancel</a> </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_Bottom" runat="server">
    
    <script src="..WebResource/js/jquery.gritter.min.js"></script>
    <script src="..WebResource/js/jquery.peity.min.js"></script>
    <script src="..WebResource/js/matrix.interface.js"></script>
    <script src="..WebResource/js/matrix.popover.js"></script>
</asp:Content>
