<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCPaginationBar.ascx.cs" Inherits="H.Website.IISHost.UserControls.UCPaginationBar" %>
<asp:Literal ID="ltBeginPage" runat="server" />
<asp:Literal ID="ltPrev" runat="server" />
<asp:Literal ID="ltFirstPage" runat="server"/>
<asp:Literal ID="ltOmitP" runat="server" />
<asp:Literal ID="ltPageInfoP" runat="server"/>
<asp:Literal ID="ltCurrentPage" runat="server"/>
<asp:Literal ID="ltPageInfoN" runat="server"/>
<asp:Literal ID="ltOmitN" runat="server" />
<asp:Literal ID="ltLastPage" runat="server"/>
<asp:Literal ID="ltNext" runat="server" />
<asp:Literal ID="ltEndPage" runat="server" />
<asp:PlaceHolder ID="plConfirm" runat="server" Visible="false">
<span class="mr5 ml10">跳转至</span>
<input type="text" maxlength="4" id="setShowPageNav" value="自定义" class="intxt hasDefaultText">
<span class="mr10 ml5">页</span>
<a id="btnSetShowPageNav" class="btn_confirm"  style="display: none;" href="javascript:void(0);" ref1="<%=ConfirmUrl %>"><span>确定</span></a>
</asp:PlaceHolder>
<script type="text/ecmascript">
    function initPaginationBarA(defaultText) {
        if (!$("#setShowPageNav").length || !$("#btnSetShowPageNav").length) {
            return;
        }

        $("#setShowPageNav").focus(function () {
            $("#setShowPageNav").val("");
            $("#btnSetShowPageNav").show();
        });
        $("#setShowPageNav").blur(function () {
            if ($("#setShowPageNav").val() == "" || $("#setShowPageNav").val() == defaultText) {
                $("#setShowPageNav").val(defaultText);
                $("#btnSetShowPageNav").hide();
            }
        });

        $("#btnSetShowPageNav").click(function () {
            var url = $("#btnSetShowPageNav").attr("ref1");
            var qty = $.trim($("#setShowPageNav").val());
            var page = parseInt(qty, 10);
            var number = 1;
            var regexNumber = /^[0-9]*[1-9][0-9]*$/;

            if (regexNumber.test(qty) == false || isNaN(page) == true || page <= 0) {
                number = 1;
            }
            else if (page > 9999) {
                number = 9999;
            }
            else {
                number = page;
            }
            url += number;
            window.location.href = url;
            return false;
        });
    }
    $(function () {
        initPaginationBarA("自定义");
    })
</script>