<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Master.Master" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="H.Website.IISHost.Page.UserInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_Head" runat="server">        
    <link rel="stylesheet" href="/WebResource/css/uniform.css" />
    <link rel="stylesheet" href="/WebResource/css/select2.css" />
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_Content" runat="server">
    <div id="content-header">
        <div id="breadcrumb"><a href="index.html" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a><a href="#" class="current">个人资料</a> </div>
    </div>
    <div class="container-fluid">
        <hr>
        <div class="row-fluid">
            <div class="span12">
                <div class="widget-box">
                    <div class="widget-title">
                        <span class="icon"><i class="icon-pencil"></i></span>
                        <h5>基本信息</h5>
                    </div>
                    <div class="widget-content nopadding">
                        <form class="form-horizontal" method="post" action="#" name="basic_validate" id="basic_validate" novalidate="novalidate" runat="server">
                            <div class="control-group">
                                <label class="control-label">登陆账号</label>
                                <div class="controls">
                                    <input type="text" name="loginId" id="txt_UserName" runat="server" readonly="readonly">
                                </div>
                            </div>
<%--                            <div class="control-group">
                                <label class="control-label">姓&nbsp;&nbsp;&nbsp;名</label>
                                <div class="controls">
                                    <input type="text" name="required" id="required">
                                </div>
                            </div>--%>
                            <div class="control-group">
                                <label class="control-label">个人邮箱</label>
                                <div class="controls">
                                    <input type="text" name="email" id="txt_Email" readonly="readonly" runat="server">
                                </div>
                            </div>
                            <%--<div class="control-group">
                                <label class="control-label" for="checkboxes">性&nbsp;&nbsp;&nbsp;别</label>
                                <div class="controls">
                                    <div class="btn-group" data-toggle="buttons-radio">
                                        <button type="button" class="btn btn-primary active">男</button>
                                        <button type="button" class="btn btn-primary">女</button>
                                    </div>
                                </div>
                            </div>                            
                            <div class="control-group">
                                <label class="control-label">年&nbsp;&nbsp;&nbsp;龄</label>
                                <div class="controls">
                                    <input type="text" name="number" id="age">
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label">头像</label>
                                <div class="controls">
                                    <div class="uploader" id="uniform-undefined"><input type="file" size="19" style="opacity: 0;"><span class="filename" style="-moz-user-select: none;">No file selected</span><span class="action" style="-moz-user-select: none;">Choose File</span></div>
                                </div>
                            </div>--%>
                            <div class="form-actions">
                                <input type="submit" value="Save" class="btn btn-success">
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>  
        <div class="row-fluid">
            <div class="span12">
                <div class="widget-box">
                    <div class="widget-title">
                        <span class="icon"><i class="icon-pencil"></i></span>
                        <h5>修改密码</h5>
                    </div>
                    <div class="widget-content nopadding">
                        <form novalidate="novalidate" id="password_validate" name="password_validate" action="#" method="post" class="form-horizontal">                            
                            <div class="control-group">
                                <label class="control-label">原始密码：</label>
                                <div class="controls" style="width:250px;">
                                    <input type="password"  name="OldPassword" id="OldPassword" datatype="*oldPassword">                                    
                                    <div class="Validform_checktip" ></div>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label">密&nbsp;码：</label>
                                <div class="controls">
                                    <input type="password" name="Password" id="Password" datatype="*6-20">                       
                                    <div class="Validform_checktip" ></div>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label">确认密码：</label>
                                <div class="controls">
                                    <input type="password" name="Password2" datatype="*" recheck="Password">                       
                                    <div class="Validform_checktip" ></div>
                                </div>
                            </div>
                            <div class="form-actions">
                                <input type="submit" class="btn btn-success" value="Save" id="btn_submit">
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>      
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_Bottom" runat="server">    
    <script src="/WebResource/CustomJs/validate/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript">
        var updatePassword = {
            init: function () {
                this.initValidate();
            },
            initValidate: function () {
                var _self = this;
                $("#password_validate").Validform({
                    btnSubmit: "#btn_submit",
                    tiptype: 2,
                    datatype: {
                        "*oldPassword": function (gets, obj, curform, regxp) {
                            var reg1 = /^[^\s]{6,20}$/;
                            if (!reg1.test(gets)) {
                                return "请输入6-20位字符!";
                            }
                            var flag = _self.validatePassword(gets);
                            if (flag) {
                                return true;
                            }
                            else {
                                $(obj).focus();
                                return "原始密码输入错误!";
                            }
                        }
                    },
                    beforeSubmit: function (curform) {
                        var entity = {
                            UserName: $("#UserName").val(),
                            OldPassword: $("#OldPassword").val(),
                            Password: $("#Password").val()
                        };
                        var _self = this;
                        var flag = Portal.UpdatePassword.UpdatePasswordMethod(entity).value;
                        if (flag == "1") {
                            $.alert("修改成功!");
                        } else {
                            $.alert("修改失败!");
                        }
                        return false;
                    }
                });
            },
            validatePassword: function (oldPassword) {
                var value = Portal.UpdatePassword.ValidatePassword(oldPassword).value;
                if (value == 1)
                    return true;
                else
                    return false;
            }
        };
        $(function () {
            updatePassword.init();
        });
        </script>
</asp:Content>
