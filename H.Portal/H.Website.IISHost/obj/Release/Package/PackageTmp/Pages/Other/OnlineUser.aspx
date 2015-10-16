<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Master.Master" AutoEventWireup="true" CodeBehind="OnlineUser.aspx.cs" Inherits="H.Website.IISHost.Page.OnlineUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_Content" runat="server">
    <div id="content-header">
            <div id="breadcrumb"><a href="#" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a><a href="#" class="current">Online User</a> </div>
            <h1>Chat option</h1>
        </div>
        <div class="container-fluid">
            <hr>
            <div class="row-fluid">
                <div class="span12">
                    <div class="widget-box widget-chat">
                        <div class="widget-title">
                            <span class="icon"><i class="icon-comment"></i></span>
                            <h5>Let's do a chat</h5>
                        </div>
                        <div class="widget-content nopadding">
                            <div class="chat-users panel-right2">
                                <div class="panel-title">
                                    <h5>Online Users</h5>
                                </div>
                                <div class="panel-content nopadding">
                                    <ul class="contact-list">
                                        <li id="user-Alex" class="online"><a href="#">
                                            <img alt="" src="../WebResource/img/demo/av1.jpg" />
                                            <span>Alex</span></a></li>
                                        <li id="user-Linda"><a href="#">
                                            <img alt="" src="../WebResource/img/demo/av2.jpg" />
                                            <span>Linda</span></a></li>
                                        <li id="user-John" class="online new"><a href="#">
                                            <img alt="" src="../WebResource/img/demo/av3.jpg" />
                                            <span>John</span></a><span class="msg-count badge badge-info">3</span></li>
                                        <li id="user-Mark" class="online"><a href="#">
                                            <img alt="" src="../WebResource/img/demo/av4.jpg" />
                                            <span>Mark</span></a></li>
                                        <li id="user-Maxi" class="online"><a href="#">
                                            <img alt="" src="../WebResource/img/demo/av5.jpg" />
                                            <span>Maxi</span></a></li>
                                    </ul>
                                </div>
                            </div>
                            <div class="chat-content panel-left2">
                                <div class="chat-messages" id="chat-messages">
                                    <div id="chat-messages-inner"></div>
                                </div>
                                <div class="chat-message well">
                                    <button class="btn btn-success">Send</button>
                                    <span class="input-box">
                                        <input type="text" name="msg-box" id="msg-box" />
                                    </span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_Bottom" runat="server">    
    <script src="../WebResource/js/matrix.chat.js"></script>
</asp:Content>
