<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Maintain.Master" AutoEventWireup="true" CodeBehind="Maintain.aspx.cs" Inherits="H.Website.IISHost.Pages.$$$TableName$$$.Maintain" %>

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
                        <form id="Form1" action="#" method="get" class="form-horizontal" runat="server">
                            <div class="control-group">
                                <label class="control-label">标准名称 :</label>
                                <div class="controls">
                                    <input type="text" class="span11" placeholder="First name" id="txt_Title" datatype="*6-20"/>
                                    <div class="Validform_checktip" ></div>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label">附件：</label>
                                <div class="controls">
                                    <div id="queue"></div>
		                            <input id="file_upload" name="file_upload" type="file" multiple="true">
                                    
                                </div>
                            </div>
                            <div id="div_uploadMsg">
                                <table class="table table-bordered table-striped" style="width:95%; float:right;">
                                    <thead>
                                        <tr>
                                            <th width="8%">状态</th>
                                            <th>Path</th>                                            
                                            <th width="10%">删除</th>
                                        </tr>
                                    </thead>
                                    <tbody id="tbody_files">
                                        <tr id="tr_fileTipMsg">
                                            <td colspan="3">暂无信息..</td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            <br />
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
                            <div class="control-group">
                                <label class="control-label">Message：</label>
                                <div class="controls">
                                    <textarea class="span11" id="txt_Content"></textarea>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label">描述：</label>
                                <div class="controls">
                                    <textarea class="span11" id="txt_Remark"></textarea>
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
        var mgmte = {
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
                        $("#txt_Content").val(result.value.Content);
                        $("#txt_Remark").val(result.value.Remark);
                        $("#div_InUserHtml").html(result.value.InUser);
                        $("#div_InDateHtml").html(result.value.InDateStr);
                        if (result.value.Files)
                            this.setFiles(result.value.Files);
                    }
                } else {
                    $("#div_InUser").hide();
                    $("#div_InDate").hide();
                }
            },
            initData: function () {
                var _self = this;
                $(".form-horizontal").Validform({
                    btnSubmit: "#btn_submit",
                    tiptype: 2,
                    beforeSubmit: function (curform) {
                        var entity = {
                            Title: $("#txt_Title").val(),
                            Content: $("#txt_Content").val(),
                            Remark: $("#txt_Remark").val(),
                            Files: _self.getFiles()
                        };
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
            getFiles: function () {
                var Files = new Array();
                $("[name*='files']").each(function () {
                    var f = {
                        Flag: 1,
                        FileName: $(this).attr("fileName"),
                        Path: $(this).attr("path")
                    };
                    Files.push(f);
                });
                return Files;
            },
            setFiles: function (Files) {
                for (var i = 0; i < Files.length; i++) {
                    var url = '<%=UploadImageUrl%>' + Files[i].Path;
                    var item = "<tr><td width=\"8%\"><span class=\"label label-success\">Success</span></td><td><a href='" + url + "' target='_blank' name='files' path='" + Files[i].Path + "' fileName='" + Files[i].FileName + "'>" + Files[i].Path + "</a></td><td width=\"10%\"><a href=\"javaScript:void(0);\" name='a_Del'>删除</a></td></tr>";
                    $("#tbody_files").append(item);

                    if ($("[name*='a_Del']").length > 0) {
                        $("#tr_fileTipMsg").remove();
                    }
                }
            }
        };
        $(function () {
            mgmte.init();

            $("[name*='a_Del']").live("click", function () {
                $(this).parent().parent().remove();

                if ($("[name*='a_Del']").length > 0) {
                    $("#tr_fileTipMsg").remove();
                } else {
                    $("#tbody_files").append("<tr id=\"tr_fileTipMsg\"><td colspan=\"3\">暂无信息..</td></tr>");
                }
            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $("#file_upload").uploadify({
                buttonText: '选择文件',
                height: 30,
                swf: '/WebResource/CustomJs/upload/uploadify.swf',
                cancelImg: '/WebResource/images/upload/uploadify-cancel.png',
                uploader: '<%=UploadUrl%>?datetime=' + new Date().getTime(),
                width: 120,
                fileSizeLimit: '5MB',                //文件大小
                'removeCompleted': true,
                fileTypeDesc: '请选择 *.jpg;*.jpeg;*.gif;*.ai;*.pdg 文件', //文件类型提示
                fileTypeExts: '*.jpg;*.jpeg;*.gif;*.ai;*.pdg',             //可选文件类型
                'uploadLimit': 10,                     //上传文件数量
                'queueSizeLimit': 2,
                onUploadSuccess: function (file, data, response) {
                    if (response) {
                        $("#tr_fileTipMsg").remove();
                        var url = '<%=UploadImageUrl%>' + data;
                        var item = "<tr><td width=\"8%\"><span class=\"label label-success\">Success</span></td><td><a href='" + url + "' target='_blank' name='files' path='" + data + "' fileName='" + file.name + "'>" + data + "</a></td><td width=\"10%\"><a href=\"javaScript:void(0);\" name='a_Del'>删除</a></td></tr>";
                        $("#tbody_files").append(item);
                    } else {
                        $("#div_uploadMsg").html("操作失败，请稍后重试！");
                    }

                }
            });
        });
    </script>
</asp:Content>
