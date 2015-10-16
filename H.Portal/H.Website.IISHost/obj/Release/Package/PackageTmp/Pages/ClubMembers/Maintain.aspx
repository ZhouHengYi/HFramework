<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Maintain.Master" AutoEventWireup="true" CodeBehind="Maintain.aspx.cs" Inherits="H.Website.IISHost.Pages.ClubMembers.Maintain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_Head" runat="server">
    <link href="/WebResource/css/upload/uploadify.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_Content" runat="server">
    <div class="container-fluid">
        <div class="row-fluid">
            <div class="span6">
                <div class="widget-box">
                    <div class="widget-title">
                        <span class="icon"><i class="icon-align-justify"></i></span>
                        <h5>基本信息编辑</h5>
                    </div>
                    <div class="widget-content nopadding">
                        <form action="#" method="get" class="form-horizontal" runat="server">
                            <div class="control-group">
                                <label class="control-label">活动名称 :</label>
                                <div class="controls">
                                    <input type="text" class="span11" placeholder="First name" id="txt_Title" datatype="*6-20"/>
                                    <div class="Validform_checktip" ></div>
                                </div>
                            </div>
                            <div class="control-group" id="div_upload">
                                <label class="control-label">图片：</label>
                                <div class="controls">
                                    <div id="queue"></div>
		                            <input id="file_upload" name="file_upload" type="file" multiple="true">
                                    <div id="div_uploadMsg"></div>
                                    <input type="hidden" id="hide_FileUrl" />
                                    最多可以选择两张图片上传，一张列表图，一张大图
                                </div>
                            </div>
                            <div class="control-group" id="div_SmallimageUrl">
                                <label class="control-label">小图地址：</label>
                                <div class="controls" id="div_SmallimageUrlHtml"></div>
                            </div>
                            <div class="control-group" id="div_BigimageUrl">
                                <label class="control-label">大图地址：</label>
                                <div class="controls" id="div_BigimageUrlHtml"></div>
                            </div>
                            <div class="control-group" id="div_InUser">
                                <label class="control-label">发布人：</label>
                                <div class="controls" id="div_InUserHtml">
                                    
                                </div>
                            </div>
                            <div class="control-group" id="div_InDate">
                                <label class="control-label">发布时间：</label>
                                <div class="controls" id="div_InDateHtml">
                                    
                                </div>
                            </div>
                            <div class="form-actions">
                                <button type="button" class="btn btn-success" id="btn_submit">Save</button>
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
    
    <script src="/WebResource/CustomJs/validate/Validform_v5.3.2_min.js"></script>
    <script src="/WebResource/CustomJs/upload/jquery.uploadify.js"></script>
    <script type="text/javascript">
        var cm = {
            init: function () {
                this.loadEntity();
                this.initData();
            },
            loadEntity: function () {
                this.SysNo = $.hFramework.querystring.get("sysNo");
                if (this.SysNo && this.SysNo != 0) {
                    var result = Portal.Maintain.LoadEntity(this.SysNo);
                    if (result.error) {
                        document.write(result.error.Message);
                    } else {
                        $("#txt_Title").val(result.value.Title);
                        $("#div_InUserHtml").html(result.value.InUser);
                        $("#div_InDateHtml").html(result.value.InDateStr);
                        $("#div_SmallimageUrlHtml").html(result.value.SmallimageUrl);
                        $("#div_BigimageUrlHtml").html(result.value.BigImageUrl);
                        $("#hide_FileUrl").val(result.value.ImageUrl);
                        $("#div_upload").hide();
                        cm.setFiles(result.value.SmallImageUrl, result.value.BigImageUrl);
                    }
                } else {
                    $("#div_InUser").hide();
                    $("#div_InDate").hide();
                }
            },
            initData: function () {
                $(".form-horizontal").Validform({
                    btnSubmit: "#btn_submit",
                    tiptype: 2,                    
                    beforeSubmit: function (curform) {
                        var entity = {
                            Title: $("#txt_Title").val(),
                            Content: $("#txt_Content").val(),
                            SmallImageUrl: $("#a_SmallImageUrl").html(),
                            BigImageUrl: $("#a_BigimageUrl").html()
                        };
                        if ($("#div_SmallimageUrlHtml").html().length == 0 || $("#div_BigimageUrlHtml").html().length == 0) {
                            $.alert('请上传图片！');
                            return false;
                        }
                        this.SysNo = $.hFramework.querystring.get("sysNo");
                        if (this.SysNo && this.SysNo != 0) {
                            entity.SysNo = this.SysNo;
                            var flag = Portal.Maintain.Update(entity).value;
                        } else {

                            var flag = Portal.Maintain.Insert(entity).value;
                        }

                        if (parseInt(flag) > 0) {
                            $.alert("操作成功!");
                        } else {
                            $.alert("操作失败!");
                        }
                        return false;
                    }
                });
            },
            setFiles: function (SmallImageUrl, BigImageUrl) {
                var siUrl = '<%=UploadImageUrl%>' + SmallImageUrl;
                var bigUrl = '<%=UploadImageUrl%>' + BigImageUrl;
                var item = "<a href='" + siUrl + "' target='_blank' id='a_SmallImageUrl'>" + SmallImageUrl + "</a>";
                var item2 = "<a href='" + bigUrl + "' target='_blank' id='a_BigimageUrl'>" + BigImageUrl + "</a>";
                $("#div_SmallimageUrlHtml").html(item);
                $("#div_BigimageUrlHtml").html(item2);
                if ($("[name*='a_Del']").length > 0) {
                    $("#tr_fileTipMsg").remove();
                }
            }
        };
        $(function () {
            cm.init();
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $("#file_upload").uploadify({
                buttonText:'选择文件',
                height: 30,
                swf: '/WebResource/CustomJs/upload/uploadify.swf',
                cancelImg: '/WebResource/images/upload/uploadify-cancel.png',
                uploader: '<%=UploadUrl%>?datetime=' + new Date().getTime(),
                width: 100,
                fileSizeLimit: '5MB',                //文件大小
                'removeCompleted': false,
                fileTypeDesc: '请选择 *.jpg;*.jpeg;*.gif;*.ai;*.pdg;*.png 文件', //文件类型提示
                fileTypeExts: '*.jpg;*.jpeg;*.gif;*.ai;*.pdg;*.png',             //可选文件类型
                'uploadLimit' : 2,                     //上传文件数量
                'queueSizeLimit': 2,
                onUploadSuccess: function (file, data, response) {
                    if (response) {
                        $("#hide_FileUrl").val(data);
                        var url = '<%=UploadImageUrl%>' + data;
                        if ($("#div_SmallimageUrlHtml").html().length == 0) {
                            $("#div_SmallimageUrlHtml").html("上传成功<br/>地址：<a href='" + url + "' target='_blank' id='a_SmallImageUrl'>" + data + "</a>");
                        } else {
                            $("#div_BigimageUrlHtml").html("上传成功<br/>地址：<a href='" + url + "' target='_blank' id='a_BigimageUrl'>" + data + "</a>");
                        }
                    } else {
                        $("#div_uploadMsg").html("操作失败，请稍后重试！");
                    }
                    
                }
            });
        });
    </script>
</asp:Content>
