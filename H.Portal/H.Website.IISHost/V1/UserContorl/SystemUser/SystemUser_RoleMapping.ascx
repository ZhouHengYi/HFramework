<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SystemUser_RoleMapping.ascx.cs" Inherits="H.Website.IISHost.UserContorl.SystemUser.SystemUser_RoleMapping" %>
<div style="width:90%; border:0px solid red; height:100px;">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style="text-align:left; padding-left:30px;">
                <asp:Repeater ID="rp_roleList" runat="server">
                    <ItemTemplate>
                        <input type="checkbox" value="<%#Eval("SysNo") %>" name="che_role"/><span style="cursor:pointer;" onclick="$(this).prev().attr('checked',!$(this).prev().attr('checked'))"><%#Eval("RoleName") %></span>
                        &nbsp;&nbsp;
                    </ItemTemplate>
                </asp:Repeater>
            </td>
        </tr>                                
    </table>
</div>