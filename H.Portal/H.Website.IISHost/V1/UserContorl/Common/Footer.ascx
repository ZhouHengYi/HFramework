<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="H.Website.IISHost.UserContorl.Common.Footer" %>
<span class="padding10px">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td width="5%" align="left">
                <a href="#">
                    <img src="../../WebResource/images/but_03.jpg" /></a>
            </td>
            <td width="20%" align="left">
                <div class="put_out rel">
                    <a href="#">导出当前页</a>
                    <div class="Pxial">
                        <a href="#">导出当前页</a>
                        <a href="#">导出所有</a>
                    </div>
                </div>
            </td>
            <td width="75%" align="right">
                <span id="pageSize" style="display: none">10</span>
                <div class="page">
                    总记录：<span id="pageTotal">0</span>条
                            <input name="" type="text" class="ipt" style="width: 40px;" id="txt_pageIndex" />&nbsp;&nbsp;<span id="pageIndex">1</span>/<span id="pageCount">1</span>页&nbsp;&nbsp;
                            <a href="javaScript:bindHelper.setPage();">转到</a>
                    <a href="javaScript:bindHelper.search(1);">&lt;</a>
                    <a href="javaScript:bindHelper.prevPage();">&lt;上一页</a>
                    <a href="javaScript:bindHelper.nextPage();">下一页&gt;</a>
                    <a href="javaScript:bindHelper.search($('#pageCount').html());">&gt;</a>
                </div>
            </td>
        </tr>
    </table>
</span>