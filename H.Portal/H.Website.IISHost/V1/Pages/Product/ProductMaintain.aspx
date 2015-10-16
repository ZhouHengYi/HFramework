<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductMaintain.aspx.cs" Inherits="H.Website.IISHost.Pages.Product.ProductMaintain" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../WebResource/css/css.css" rel="stylesheet" type="text/css" />
    <link href="../../WebResource/css/upload/uploadify.css" rel="stylesheet" />
    <script src="../../WebResource/js/jquery.min-1.7.1.js"></script>
    <script src="../../WebResource/js/Base.js"></script>
    <script src="../../WebResource/js/common.js"></script>
    <script src="../../WebResource/js/validate/Validform_v5.3.2_min.js"></script>
    <script src="../../WebResource/js/upload/jquery.uploadify.js"></script>
    <script src="../../WebResource/js/kindeditor-master/kindeditor.js?v=2"></script>
</head>
<body style="background-color:white;">
    <form id="Form1" runat="server" class="validateForm">
        <div class="roud">
            <h4>控制面板 &gt; 商品分类管理</h4>
        </div>
        <div class="main">
        <div>
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="editHead">
                <tr>
                    <td width="5%">&nbsp;</td>
                    <td>
                        <div class="Tit"><b>商品信息</b><u class="icon3">&nbsp;</u></div>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="editBody">
                <tr>
                    <td style="width: 200px; text-align: right;">
                        <font>商品分类：</font>
                    </td>
                    <td style="width: 300px; text-align: left;">
                        <select class="ipt" name="ParentSysNo" id="ProductTypeSysNo" datatype="*">
                             <option value="">--请选择--</option>
                        </select>
                    </td>
                    <td>
                        <div class="Validform_checktip"></div>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        <font>商品名：</font>
                    </td>
                    <td style="text-align: left;">
                        <input type="text" value="" name="ProductName" id="ProductName" class="ipt" datatype="*validateProductName"/>
                    </td>
                    <td>
                        <div class="Validform_checktip"></div>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        <font>商品价格：</font>
                    </td>
                    <td style="text-align: left;">
                        <input type="text" value="" name="Price" id="Price" class="ipt" datatype="*validatePrice" style="width:100px;"/>
                    </td>
                    <td>
                        <div class="Validform_checktip"></div>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        <font>分量：</font>
                    </td>
                    <td style="text-align: left;">
                        <input type="text" value="" name="Weight" id="Weight" class="ipt" datatype="n1-88888" style="width:50px;" />
                        (人份)
                    </td>
                    <td>
                        <div class="Validform_checktip"></div>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        <font>主料：</font>
                    </td>
                    <td style="text-align: left;">
                        <input type="text" value="" name="Mdient" id="Mdient" class="ipt" datatype="*1-100" style="width:280px;" />
                    </td>
                    <td>
                        <div class="Validform_checktip"></div>                        
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        <font>辅料：</font>
                    </td>
                    <td style="text-align: left;">
                        <input type="text" value="" name="Sdient" id="Sdient" class="ipt" datatype="*1-100" style="width:280px;" />
                    </td>
                    <td>
                        <div class="Validform_checktip"></div>                        
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        <font>排序：</font>
                    </td>
                    <td style="text-align: left;">
                        <input type="text" value="1" name="Order" id="Order" class="ipt" datatype="n1-88888" style="width:50px;" />
                        (越大越靠前Desc)
                    </td>
                    <td>
                        <div class="Validform_checktip"></div>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        <font>做法：</font>
                    </td>
                    <td style="text-align: left; padding-left:3px;" colspan="2">
                        <textarea name="content" style="visibility:hidden; width:auto;" rows="3" id="Method"></textarea>
                    </td>
                </tr>
            </table>
            <table>
            </table>
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="editHead">
                <tr>
                    <td width="5%">&nbsp;</td>
                    <td>
                        <div class="Tit"><b>商品图片</b><u class="icon3">&nbsp;</u></div>
                    </td>
                </tr>
            </table>
            <table width="850px" border="0" cellpadding="0" cellspacing="0" class="editBody" style="padding-left:100px;">
                <tr>
                    <td>
                        <div class="divtab">
                            <table width="100%" border="0" cellspacing="1" cellpadding="0" style="text-align: center;" id="tb_Image">
                                <tr style="background-color: #dedede">
                                    <td width="20%">文件名</td>
                                    <td>文件路径</td>
                                    <td width="20%">文件大小</td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="height:80px; padding-left:20px; padding-top:10px;">
		                <input id="file_upload" name="file_upload" type="file" multiple="true">
                    </td>
                </tr>
            </table>
        </div>
        </div>
        <div class="footer">
            <span class="padding10px">
                <a href="javaScript:void(0);" id="a_submit">
                    <img src="../../WebResource/images/footer_06.jpg" /></a>
            </span>
        </div>

        <script type="text/javascript">
            var productMaintain = {
                SysNo: 0,
                UploadUrl:"<%=H.Core.Utility.WebConfig.UploadService%>",
                UploadImageUrl: "<%=H.Core.Utility.WebConfig.UploadImageUrl%>",
                EditorUrl: "<%=H.Core.Utility.WebConfig.EditorUploadService%>",
                init: function () {
                    this.loadParent();
                    this.initEntity();
                    this.initValidate();
                    this.initUpload();
                    this.initEditor();
                },
                initEntity: function () {
                    this.SysNo = $.hFramework.querystring.get("sysno");
                    if (this.SysNo && this.SysNo != 0) {
                        var result = Portal.ProductMaintain.LoadEntity(this.SysNo);
                        if (result.error) {
                            document.write(result.error.Message);
                        } else {
                            var entity = result.value;
                            $("#ProductTypeSysNo").val(entity.ProductTypeSysNo);
                            $("#ProductName").val(entity.ProductName);
                            $("#Price").val(entity.Price);
                            $("#Weight").val(entity.Weight);
                            $("#Mdient").val(entity.Mdient);
                            $("#Sdient").val(entity.Sdient);
                            $("#Method").val(entity.Method);
                            $("#Order").val(entity.Order);
                            productMaintain.addImage("", entity.BigImageUrl, 0);
                        }
                    }
                },
                initValidate: function () {
                    var _self = this;
                    $(".validateForm").Validform({
                        btnSubmit: "#a_submit",
                        tiptype: 2,
                        datatype: {
                            "*validateProductName": function (gets, obj, curform, regxp) {
                                var reg1 = /^[^\s]{1,50}$/;
                                if (!reg1.test(gets)) {
                                    return "请输入1-50位字符!";
                                }
                                var flag = _self.validateProductName(gets);
                                if (flag) {
                                    return true;
                                }
                                else {
                                    $(obj).focus();
                                    return "商品名已存在,请重新输入!";
                                }
                            },
                            "*validatePrice":function(gets, obj, curform, regxp){
                                var reg1 = /\d{1,10}(\.\d{1,2})?$/;
                                if (!reg1.test(gets)) {
                                    return "价格格式输入错误..!";
                                }
                            }
                        },
                        beforeSubmit: function (curform) {
                            var entity = {
                                SysNo: productMaintain.SysNo == "" ? 0 : productMaintain.SysNo,
                                ProductTypeSysNo: ~~$("#ProductTypeSysNo").val(),
                                ProductName: $("#ProductName").val(),
                                Price: parseFloat($("#Price").val()),
                                Weight: ~~$("#Weight").val(),
                                Mdient: $("#Mdient").val(),
                                Sdient: $("#Sdient").val(),
                                Method: $("#Method").val(),
                                BigImageUrl: $("[name='a_BigImage']").eq(0).html(),
                                Order: ~~$("#Order").val()
                            };
                            if (!entity.BigImageUrl)
                            {
                                $.alert("请上传商品图片!");
                                return false;
                            }
                            var result = Portal.ProductMaintain.Create(entity);
                            if (result.error) {
                                $.alert(result.error.Message);
                            } else {
                                if (result.value != "0") {
                                    $.alert("提交成功!");
                                } else {
                                    $.alert("提交失败!");
                                }
                            }
                            return false;
                        }
                    });
                },
                initUpload:function(){
                    $("#file_upload").uploadify({
                        height: 30,
                        swf: '../../WebResource/js/upload/uploadify.swf',
                        cancelImg: '../../WebResource/images/upload/uploadify-cancel.png',
                        uploader: productMaintain.UploadUrl + '?datetime=' + new Date().getTime(),
                        width: 120,
                        fileSizeLimit: '5MB',                //文件大小
                        'removeCompleted': false,
                        fileTypeDesc: '请选择 *.jpg;*.jpeg;*.gif;*.png;*.bmp 文件', //文件类型提示
                        fileTypeExts: '*.jpg;*.jpeg;*.gif;*.png;*.bmp',             //可选文件类型
                        //'uploadLimit': 1,                     //上传文件数量
                        'queueSizeLimit': 1,
                        onUploadSuccess: function (file, data, response) {
                            var fileUrl = productMaintain.UploadImageUrl + data;
                            //alert('文件名：' + file.name + ' 执行结果： ' + response + ': 上传路径：' + fileUrl);
                            productMaintain.addImage(file.name, fileUrl, file.size);
                        }
                    });
                },
                addImage: function (name, url, size) {
                    $("#tb_Image tr").eq(1).remove();
                    var tr = "<tr><td>" + name + "</td><td><a href=\"javaScript:void(0);\" onclick=\"window.open('" + url + "');\" name=\"a_BigImage\" title=\"" + name + "\">"
                        + url + "</a></td><td>" + size + "</td></tr>";
                    $("#tb_Image").append(tr);
                },
                initEditor: function () {
                    KindEditor.ready(function (K) {
                        editor = K.create('textarea[name="content"]', {
                            items: [
                                'source', 'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
                                'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
                                'insertunorderedlist', '|', 'image', 'link']
                        , afterBlur: function () { this.sync(); }
                        , uploadJson: '../../Kindeditor/upload_json.aspx'
                        , fileManagerJson: '../../Kindeditor/file_manager_json.aspx'
                        , allowFileManager: true
                        , afterChange: function () {
                            KindEditor('.word_count1').html(this.count());
                        }
                        });
                    });
                },
                validateProductName: function (productName) {
                    var value = Portal.ProductMaintain.ByProductNameGetInfo(productName, this.SysNo).value;
                    if (value == 1)
                        return true;
                    else
                        return false;
                },
                loadParent: function () {
                    var result = Portal.ProductMaintain.LoadParent();
                    if (result.error) {
                        document.write(result.error.Message);
                    } else {
                        if (result.value) {
                            var list = result.value;
                            for (var i = 0; i < list.length; i++) {
                                if (productMaintain.SysNo != list[i].SysNo) {
                                    $("#ProductTypeSysNo").append("<option value=\"" + list[i].SysNo + "\">" + list[i].ProductTypeName + "</option>");
                                }
                            }
                        }
                    }
                }
            };
            $(function () {
                productMaintain.init();                
            });
        </script>
    </form>
</body>
</html>
