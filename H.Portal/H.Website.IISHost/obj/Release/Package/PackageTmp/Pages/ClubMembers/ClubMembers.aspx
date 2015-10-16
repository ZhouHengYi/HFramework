<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Master.Master" AutoEventWireup="true" CodeBehind="ClubMembers.aspx.cs" Inherits="H.Website.IISHost.Pages.ClubMembers.ClubMembers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_Head" runat="server">
    <style type="text/css">
        
#content {
    padding-bottom: 45px;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_Content" runat="server">
   <div id="content-header">
       <form runat="server"></form>
        <div id="breadcrumb"><a href="#" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a> <a href="#" class="current">会员活动一览</a></div>
        <iframe src="/Pages/ClubMembers/Data.aspx" width="100%" height="600" border="0"></iframe> 
        <div class="fg-toolbar ui-toolbar ui-widget-header ui-corner-bl ui-corner-br ui-helper-clearfix">
            <%--<div style="float: left; margin-top: 5px;">
                <button class="btn btn-info btn-large" style="font-size: 13.5px; padding: 5px 19px;">新增</button>
                <button class="btn btn-danger btn-large" style="font-size: 13.5px; padding: 5px 19px;" onclick="systemUser.deleteSel();">删除</button>
            </div>--%>
            <div class="dataTables_paginate fg-buttonset ui-buttonset fg-buttonset-multi ui-buttonset-multi paging_full_numbers" style="float: right; display:none;" id="div_pager">

            </div>
        </div>
        
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_Bottom" runat="server">
  <script src="/WebResource/CustomJs/bindHelper.js" charset="gbk"></script>
    <script type="text/javascript">
        $(function () {
            bindHelper.AjaxProObject = Portal.ClubMembers;
            bindHelper.init();
        });
    </script>
</asp:Content>
