<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Maintain.Master" AutoEventWireup="true" CodeBehind="Maintain.aspx.cs" Inherits="H.Website.IISHost.Pages.SystemUser.Maintain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_Content" runat="server">
    <form runat="server"></form>
    <div class="container-fluid">
        <div class="row-fluid">
            <div class="span6">
                <div class="widget-box">
                    <div class="widget-title">
                        <span class="icon"><i class="icon-align-justify"></i></span>
                        <h5>基本信息编辑</h5>
                    </div>
                    <div class="widget-content nopadding">
                        <form action="#" method="get" class="form-horizontal">
                            <div class="control-group">
                                <label class="control-label">用户名 :</label>
                                <div class="controls">
                                    <input type="text" class="span11" placeholder="First name" id="txt_UserName"/>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label">邮  箱</label>
                                <div class="controls">
                                    <input type="text" class="span11" placeholder="First name" id="txt_Email"/>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label">创建人 :</label>
                                <div class="controls">
                                    <input type="text" class="span11" placeholder="Last name" id="txt_InUser"/>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label">创建日期 :</label>
                                <div class="controls">
                                    <input type="text" class="span11" placeholder="Company name" id="txt_InDate"/>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label">最后登录时间 :</label>
                                <div class="controls">
                                    <input type="text" class="span11" placeholder="Company name" id="txt_LastLoginDate"/>
                                </div>
                            </div>
                            <div class="form-actions">
                                <%--<button class="btn btn-danger" type="button">Cancel</button>--%>
                            </div>
                        </form>
                    </div>
                </div>                
            </div>
        </div>        
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_Bottom" runat="server">
    <script type="text/javascript">
        var systemUserMaintain = {
            init: function () {
                this.initData();
            },
            initData:function(){
                Portal.Maintain.LoadEntity($.hFramework.querystring.get("sysNo"), function (result) {
                    if (result.error) {
                        document.write(result.error.Message);
                    } else {
                        if (result.value) {
                            var entity = result.value;
                            $("#txt_UserName").val(entity.UserName);
                            $("#txt_Email").val(entity.Email);
                            $("#txt_InUser").val(entity.InUser);
                            $("#txt_InDate").val(entity.InDateStr);
                            $("#txt_LastLoginDate").val(entity.LastLoginDateStr);
                        }
                    }
                });
            }            
        };
        $(function () {
            systemUserMaintain.init();
        });
        </script>
</asp:Content>
