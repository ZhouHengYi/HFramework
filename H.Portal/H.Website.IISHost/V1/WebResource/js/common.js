$(document).ready(function () {
    if (typeof (AjaxPro) != "undefined" && typeof ($.utility) != "undefined") {
        AjaxPro.onLoading = function (b, request) {
            b ? $.utility.ajax.onStart() : $.utility.ajax.onStop();
        }
    }

    $("#iframe_main").click(function (obj) {
        if (window.parent.document.getElementById("div_menu")) {
            if (window.parent.document.getElementById("div_menu").style.display != "none")
                window.parent.document.getElementById("img_logo").click();
        }
    });

    $(".validateForm").keyup(function (ev) {
        if (ev.keyCode == 13) {
            $("#a_submit").click();
            return false;
        }
    });
    $(".main").click(function () {
        if ($(window.parent.document).find("#div_menu").css("display") == "block")
            $(window.parent.document).find("#div_menu").fadeOut(300);
    });
    //屏蔽F5刷新
    document.onkeydown = function (e) {
        var ev = window.event || e;
        var code = ev.keyCode || ev.which;
        if (code == 116) {
            ev.keyCode ? ev.keyCode = 0 : ev.which = 0;
            cancelBubble = true;
            if ($(window.parent.document).find("#iframe_main")) {
                $(window.parent.document).find("#iframe_main").attr("src", $(window.parent.document).find("#iframe_main").attr("src"));
                return false;
            }
            return true;
        }
    }
});



/* 1.1、utility function
* -------------------------------------------------- */
(function ($) {
    $.utility = {
        showOverlay: function (options, overlayId, oncallback) {
            var settings = $.extend({
                bgColor: "#000",
                opacity: 0.2,
                zIndex: 499
            }, options)

            var elem = $("<div id='formMask_overlay'></div>")
                .prependTo("body")
                .attr("overlayId", overlayId)
                .css({
                    'backgroundColor': settings.bgColor,
                    'opacity': settings.opacity,
                    'z-index': settings.zIndex
                })
                .fadeIn("fast", oncallback);
            if ($.browser.msie && $.browser.version == "6.0") {
                elem.css("position", "absolute")
                .width($("body").width())
                .height($("body").height());
            }
        },
        showNewLoading: function (requestId, allowCancel) {
            var elem = $('<div id="NewLoading" class="loading"> \
                        <a href="#" class="close" title="正在处理 …… "></a> \
                        <p>正在处理 …… </p> \
                        <div class="loadImg"></div> \
                      </div>')
            .prependTo("body")
            .attr("requestId", requestId);

            $("a.close", elem).css({
                "display": allowCancel ? "" : "none"
            }).click(function () {
                $.ajaxPost.abort();
                if (typeof (AjaxPro) != "undefined") {
                    AjaxPro.abort();
                }
                return false;
            });

            setLocation();

            elem.show();

            $(window).resize(setLocation).scroll(setLocation);

            function setLocation() {
                elem.css({
                    "position": "absolute",
                    "top": $(window).scrollTop() + ($(window).height() - elem.height()) / 2,
                    "left": $(window).scrollLeft() + ($(window).width() - elem.width()) / 2
                });
            }
        },
        hideOverlay: function (overlayId, oncallback) {
            var elem = $("[id=formMask_overlay][overlayId=" + overlayId + "]").fadeOut("normal", oncallback);
            $(".bgiframe", elem).remove();
            elem.remove();
        },
        hideNewLoading: function (requestId) {
            $("[id=NewLoading][requestId=" + requestId + "]").hide().remove();
        },
        ajax: {
            requestId: "ajax_globalId",
            onStart: function () {
                $.utility.showOverlay({ bgColor: "#000", opacity: 0.2, zIndex: 1000 }, $.utility.ajax.requestId);
                $.utility.showNewLoading($.utility.ajax.requestId);
            },
            onStop: function () {
                $.utility.hideOverlay($.utility.ajax.requestId);
                $.utility.hideNewLoading($.utility.ajax.requestId);
            },
            onError: function (error) {
                $.alert("<br />" + error.Message + (error.Detail ? "<br /><br />" + error.Detail : ""), "error");
            }
        },
        span_check: {
            check: function (_span) {
                $("#" + _span).attr("checked", !$("#" + _span).attr("checked"));
            }
        },
        request: function (name)
        {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
            var r = window.location.search.substr(1).match(reg);
            if (r != null)
                return unescape(r[2]);
            else
                return null;
        },
        cookie: {
            setCookie: function (name, value) {
                var Days = 30;
                var exp = new Date();
                exp.setTime(exp.getTime() + Days * 24 * 60 * 60 * 1000);
                document.cookie = name + "=" + escape(value) + ";expires=" + exp.toGMTString();
            },
            getCookie: function (name) {
                var arr, reg = new RegExp("(^| )" + name + "=([^;]*)(;|$)");
                if (arr = document.cookie.match(reg))
                    return unescape(arr[2])
                else
                    return null;
            }
        }
    };
})(jQuery);

(function ($) {
    /*!
 * jQuery showDialog
 * befen.net
 * Date: 2013.02.08
*/
    function detectMacXFF() {
        var userAgent = navigator.userAgent.toLowerCase();
        if (userAgent.indexOf("mac") != -1 && userAgent.indexOf("firefox") != -1) {
            return true;
        }
    }

    function in_array(needle, haystack) {
        if (typeof needle == "string" || typeof needle == "number") {
            for (var i in haystack) {
                if (haystack[i] == needle) {
                    return true;
                }
            }
        }
        return false;
    }

    function sd_load(sd_width) {
        if (sd_width) {
            $("#SD_window").css("width", sd_width + "px");
        }
        var sd_top = ($(window).height() - $("#SD_window").height()) / 2 + $(document).scrollTop();
        if (sd_top < 0) {
            sd_top = 0;
        }
        var sd_left = ($(window).width() - $("#SD_window").width()) / 2;
        if (sd_left < 0) {
            sd_left = 0;
        }
        $("#SD_window").css("top", sd_top / 2);
        $("#SD_window").css("left", sd_left);
    }

    function sd_remove() {
        if ($(window.document).find("#btn_search").length > 0) {
            $(window.document).find("#btn_search").click();
        }
        $("#SD_close,#SD_cancel,#SD_confirm").unbind("click");
        $("#SD_window,#SD_overlay,#SD_HideSelect").remove();
        if (typeof document.body.style.maxHeight == "undefined") {
            $("body", "html").css({ height: "auto", width: "auto" });
        }
        
    }

    function showDialog(mode, msg, t, sd_width) {
        var sd_width = sd_width ? sd_width : 400;
        var mode = in_array(mode, ['confirm', 'window', 'info', 'loading']) ? mode : 'alert';
        var t = t ? t : "提示信息";
        var msg = msg ? msg : "";
        var confirmtxt = confirmtxt ? confirmtxt : "确定";
        var canceltxt = canceltxt ? canceltxt : "取消";
        //sd_remove();
        try {
            if (typeof document.body.style.maxHeight === "undefined") {
                $("body", "html").css({ height: "100%", width: "100%" });
                if (document.getElementById("SD_HideSelect") === null) {
                    $("body").append("<iframe id='SD_HideSelect'></iframe><div id='SD_overlay'></div>");
                }
            } else {
                if (document.getElementById("SD_overlay") === null) {
                    $("body").append("<div id='SD_overlay'></div>");
                }
            }
            if (mode == "alert") {
                if (detectMacXFF()) {
                    $("#SD_overlay").addClass("SD_overlayMacFFBGHack");
                } else {
                    $("#SD_overlay").addClass("SD_overlayBG");
                }
            } else {
                if (detectMacXFF()) {
                    $("#SD_overlay").addClass("SD_overlayMacFFBGHack2");
                } else {
                    $("#SD_overlay").addClass("SD_overlayBG2");
                }
            }
            $("body").append("<div id='SD_window'></div>");
            var SD_html;
            SD_html = "";
            SD_html += "<table cellspacing='0' cellpadding='0'><tbody><tr><td class='SD_bg'></td><td class='SD_bg'></td><td class='SD_bg'></td></tr>";
            SD_html += "<tr><td class='SD_bg'></td>";
            SD_html += "<td id='SD_container'>";
            SD_html += "<h3 id='SD_title'>" + t + "</h3>";
            SD_html += "<div id='SD_body'><div id='SD_content'>" + msg + "</div></div>";
            SD_html += "<div id='SD_button'><div class='SD_button'>";
            SD_html += "<a id='SD_confirm'>" + confirmtxt + "</a>";
            SD_html += "<a id='SD_cancel'>" + canceltxt + "</a>";
            SD_html += "</div></div>";
            SD_html += "<a href='javascript:;' id='SD_close' title='关闭'></a>";
            SD_html += "</td>";
            SD_html += "<td class='SD_bg'></td></tr>";
            SD_html += "<tr><td class='SD_bg'></td><td class='SD_bg'></td><td class='SD_bg'></td></tr></tbody></table>";
            $("#SD_window").append(SD_html);
            $("#SD_confirm,#SD_cancel,#SD_close").bind("click", function () {
                sd_remove();
            });
            if (mode == "info" || mode == "alert") {
                $("#SD_cancel").hide();
                $("#SD_button").show();
            }
            if (mode == "window") {
                $("#SD_close").show();
            }
            if (mode == "confirm") {
                $("#SD_button").show();
            }
            var sd_move = false;
            var sd_x, sd_y;
            $("#SD_container > h3").click(function () { }).mousedown(function (e) {
                sd_move = true;
                sd_x = e.pageX - parseInt($("#SD_window").css("left"));
                sd_y = e.pageY - parseInt($("#SD_window").css("top"));
            });
            $(document).mousemove(function (e) {
                if (sd_move) {
                    var x = e.pageX - sd_x;
                    var y = e.pageY - sd_y;
                    $("#SD_window").css({ left: x, top: y });
                }
            }).mouseup(function () {
                sd_move = false;
            });
            $("#SD_body").width(sd_width - 50);
            sd_load(sd_width);
            $("#SD_window").show();
            $("#SD_window").focus();
            $(document).keyup(function (ev) {
                if (ev.keyCode == 27) {
                    sd_remove();
                    return false;
                }
            });
        } catch (e) {
            alert("System Error !");
        }
    }

    $.showInfo = function (msg, fn, timeout) {
        showDialog("info", msg);
        $("#SD_confirm").unbind("click");
        if (fn && timeout) {
            st = setTimeout(function () {
                sd_remove();
                fn();
            }, timeout * 1000);
        }
        $("#SD_confirm").bind("click", function () {
            if (timeout) {
                clearTimeout(st);
            }
            sd_remove();
            if (fn) {
                fn();
            }
        });
    }

    $.showWindow = function (title, the_url, sd_width, sd_height) {
        var sd_width = sd_width ? sd_width : 400;
        var msg = "<iframe id=\"popContent\" frameborder=\"0\" style=\"width: " + (sd_width - 50) + "px; height: " + sd_height + "px;\" src=\"" + the_url + "\" onload=\"$.utility.hideNewLoading('showWindow');\"></iframe>";
        //$.utility.showNewLoading("showWindow");

        showDialog("window", msg, title, sd_width);
    }

    $.showDiv = function (title, the_url, sd_width) {
        var sd_width = sd_width ? sd_width : 400;
        $.ajax({
            type: "GET",
            dataType: "html",
            cache: false,
            url: the_url,
            data: "isajax=1",
            success: function (data) {
                showDialog("window", data, title, sd_width);
                //$.utility.hideNewLoading('showDiv');
            },
            error: function (data) {
                $.alert("读取数据失败");
            },
            beforeSend: function (data) {
                //$.utility.showNewLoading("showDiv");
            }
        });
    }

    $.confirm = function(msg, fn) {
        showDialog("confirm", msg);
        //$("#SD_confirm").unbind("click");
        $("#SD_confirm").bind("click", function () {
            if (fn) {
                fn();
            }
        });
    }
    $.alert = function (msg,fn) {
        showDialog("alert", msg);
    }
    $.Tip = function (msg) {
        $("#span_cmdTip").html(msg);
        $("#span_cmdTip").show();
        setTimeout("$('#span_cmdTip').hide();", 3000);
    }

})(jQuery);

