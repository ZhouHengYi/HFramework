<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="H.Portal.IISHost.Pages.User.User" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../WebResource/css/index.css" rel="stylesheet" />
    <script src="../../WebResource/js/jquery.min-1.7.1.js"></script>
    <script src="../../WebResource/js/common.js"></script>
</head>
<div class="location">控制面板 > 用户管理 > 用户管理</div>
<div class="main">
        <div class="content">
            <div class="nei">
                <table id="Tbl_List" class="border ke-zeroborder" style="word-break: break-all;" border="0" cellpadding="0" cellspacing="1" align="center" width="99%">
                    <tbody>
                        <tr>
                            <td colspan="10" background="../images/bj_03.jpg" bgcolor="#F1F3F5" align="center" height="26">
                                <span style="cursor: pointer;" onclick="location.href='NewEdit.aspx'">
                                    <img src="../images/add.gif" style="vertical-align: middle;" />&nbsp;添加信息</span>
                            </td>
                        </tr>
                        <tr bgcolor="#c0c0c0">
                            <td class="forumRow_hui" align="center" height="25" width="5%">
                                <strong>选中</strong>
                            </td>
                            <td class="forumRow_hui" bgcolor="#c0c0c0" align="center" height="25" width="5%">
                                <strong>ID</strong>
                            </td>
                            <td class="forumRow_hui" bgcolor="#c0c0c0" align="center">
                                <strong>信息标题</strong>
                            </td>
                            <td class="forumRow_hui" bgcolor="#c0c0c0" align="center" width="10%">
                                <strong>类型</strong>
                            </td>
                            <td class="forumRow_hui" bgcolor="#c0c0c0" align="center" width="10%">
                                <strong>推荐</strong>
                            </td>
                            <td class="forumRow_hui" bgcolor="#c0c0c0" align="center" width="10%">
                                <strong>排序</strong>
                            </td>
                            <td class="forumRow_hui" align="center" width="12%">
                                <strong>创建日期</strong>
                            </td>
                            <td class="forumRow_hui" align="center" width="12%">
                                <strong>操作</strong>
                            </td>
                        </tr>
                        <tr class="tdbg">
                            <td bgcolor="#c0c0c0" align="center" height="22">
                                <input value="189" name="check" type="checkbox" />
                                <input name="Rp_List$ctl00$Hide_ProId" id="Rp_List_ctl00_Hide_ProId" value="189" type="hidden" />
                            </td>
                            <td bind="$.sysNo" bgcolor="#e3e3e3" align="center">
                                <br />
                            </td>
                            <td bind="$.title" bgcolor="#e3e3e3" align="center">
                                <br />
                            </td>
                            <td bind="$.type" bgcolor="#e3e3e3" align="center">
                                <br />
                            </td>
                            <td bind="$.recommand" bgcolor="#e3e3e3" align="center">
                                <br />
                            </td>
                            <td bind="$.sort" bgcolor="#e3e3e3" align="center">
                                <br />
                            </td>
                            <td bind="$.createDate" bgcolor="#e3e3e3" align="center">
                                <br />
                            </td>
                            <td bgcolor="#e3e3e3" align="center">
                                <a href="NewEdit.aspx?id=189">查看</a> <a onclick="return shanchu();" id="Rp_List_ctl00_LinkButton1" href="javascript:__doPostBack('Rp_List$ctl00$LinkButton1','')">删除</a>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
    </div>
</div>
</html>
