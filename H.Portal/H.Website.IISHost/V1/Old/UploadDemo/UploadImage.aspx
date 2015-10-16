<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadImage.aspx.cs" Inherits="H.Portal.IISHost.UploadDemo.UploadImage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../WebResource/css/upload/uploadify.css" rel="stylesheet" />
    <script src="../WebResource/js/jquery.min-1.7.1.js"></script>
    <script src="../WebResource/js/upload/jquery.uploadify.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="queue"></div>
		<input id="file_upload" name="file_upload" type="file" multiple="true">
    </div>

    <script type="text/javascript">
        $(function() {
            $("#file_upload").uploadify({
                height: 30,
                swf: '../WebResource/js/upload/uploadify.swf',
                cancelImg: '../WebResource/images/upload/uploadify-cancel.png',
                uploader: '<%=UploadUrl%>?datetime=' + new Date().getTime(),
                width: 120,
                fileSizeLimit: '100MB',                //文件大小
                'removeCompleted': false,
                fileTypeDesc: '请选择 .jpg | .exe 文件', //文件类型提示
                fileTypeExts: '*.jpg;*.exe',             //可选文件类型
                //'uploadLimit' : 1,                     //上传文件数量
                'queueSizeLimit': 2,
                onUploadSuccess: function (file, data, response) {
                    alert('文件名：' + file.name + ' 执行结果： ' + response + ': 上传路径：' + data);
                }
            });
        });
    </script>
    </form>
</body>
</html>
