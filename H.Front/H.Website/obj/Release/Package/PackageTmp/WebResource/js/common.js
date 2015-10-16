$(document).ready(function () {
    if (typeof (AjaxPro) != "undefined" && typeof ($.utility) != "undefined") {
        AjaxPro.onLoading = function (b, request) {
            b ? $.utility.ajax.onStart() : $.utility.ajax.onStop();
        }
    }

    $(".main").click(function (obj) {
        if (window.parent.document.getElementById("div_menu").style.display != "none")
            window.parent.document.getElementById("img_logo").click();
    });
});