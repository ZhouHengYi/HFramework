<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ErrorLogDetails.aspx.cs" Inherits="H.Website.IISHost.Pages.Common.ErrorLogDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../WebResource/css/css.css" rel="stylesheet" type="text/css" />
    <script src="../../WebResource/js/jquery.min-1.7.1.js"></script>
    <script src="../../WebResource/js/Base.js"></script>
    <script src="../../WebResource/js/common.js"></script>
    <script src="../../WebResource/js/validate/Validform_v5.3.2_min.js"></script>
</head>
<body style="background-color:white;">
    <form id="Form1" runat="server" class="validateForm">
        <div>
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="editHead">
                <tr>
                    <td width="5%">&nbsp;</td>
                    <td>
                        <div class="Tit"><b>系统错误日志详细</b><u class="icon3">&nbsp;</u></div>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="editBody">
                <tr>
                    <td style="width: 120px; text-align: right;">
                        <font>SysNo：</font>
                    </td>
                    <td style="text-align: left;" id="SysNo">
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px; text-align: right;">
                        <font>LogID：</font>
                    </td>
                    <td style="text-align: left;" id="LogID">
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px; text-align: right;">
                        <font>GlobalName：</font>
                    </td>
                    <td style="text-align: left;" id="GlobalName">
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px; text-align: right;">
                        <font>LocalName：</font>
                    </td>
                    <td style="text-align: left;" id="LocalName">
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px; text-align: right;">
                        <font>Content：</font>
                    </td>
                    <td style="text-align: left;" id="Content">
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px; text-align: right;">
                        <font>LogUserName：</font>
                    </td>
                    <td style="text-align: left;" id="LogUserName">
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px; text-align: right;">
                        <font>Category：</font>
                    </td>
                    <td style="text-align: left;" id="Category">
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px; text-align: right;">
                        <font>LogServerIP：</font>
                    </td>
                    <td style="text-align: left;" id="LogServerIP">
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px; text-align: right;">
                        <font>LogServerName：</font>
                    </td>
                    <td style="text-align: left;" id="LogServerName">
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px; text-align: right;">
                        <font>ReferenceKey：</font>
                    </td>
                    <td style="text-align: left;" id="ReferenceKey">
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px; text-align: right;">
                        <font>InDate：</font>
                    </td>
                    <td style="text-align: left;" id="InDate">
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <br />
        <br />
        <div class="footer">
            <span class="padding10px">
                <a href="javaScript:void(0);" id="a_submit">
                    <img src="../../WebResource/images/footer_06.jpg" /></a>
            </span>
        </div>


        <script type="text/javascript">
            var errorLogDetails = {
                init: function () {
                    this.getDetails();
                },
                getDetails: function () {
                    var sysno = $.hFramework.querystring.get("sysNo");
                    if (sysno) {
                        Portal.ErrorLogDetails.GetDetails(sysno, function (result) {
                            if (result.error) {
                                document.write(result.error.Message);
                            } else {
                                var entity = result.value;
                                $("#SysNo").html(entity.SysNo);
                                $("#LogID").html(entity.LogID);
                                $("#GlobalName").html(entity.GlobalName);
                                $("#LocalName").html(entity.LocalName);
                                $("#Content").html(entity.Content);
                                $("#LogUserName").html(entity.LogUserName);
                                $("#Category").html(entity.Category);
                                $("#LogServerIP").html(entity.LogServerIP);
                                $("#LogServerName").html(entity.LogServerName);
                                $("#ReferenceKey").html(entity.ReferenceKey);
                                $("#InDate").html(entity.InDateStr);
                            }
                        })
                    }
                }
            };
            $(function () {
                errorLogDetails.init();
            });
        </script>
    </form>
</body>
</html>
