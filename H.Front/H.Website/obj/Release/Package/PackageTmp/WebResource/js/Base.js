
(function ($) {
    /**
　　* @description Jquery 扩展对象
　　* @class 封装对Jquery的扩展方法
　　*/
    $.hFramework = {
        /**
 　　    * @description  判断当前页面是否是SSL页面
         * @param 无
         * @returns {bool}
 　　    */
        isSecurePage: function () {
            return location.protocol == 'https:';
        },
        /**
　　    * @description  根据当前页面域名构造url
        * @param {string} relativePath 相对路径
        * @returns {string} 绝对路径
　　    */
        buildCurrent: function (relativePath) {
            return location.protocol + '//' + location.host + '/' + relativePath;
        },
        /**
　　    * @description 格式化字符串
        * @param {string} source 带格式的字符串
        * @param {string} params 替换的参数
        * @returns {string} 格式化后的字符串
　　    */
        format: function (source, params) {
            if (arguments.length == 1)
                return function () {
                    var args = $.makeArray(arguments);
                    args.unshift(source);
                    return $.hFramework.format.apply(this, args);
                };
            if (arguments.length > 2 && params.constructor != Array) {
                params = $.makeArray(arguments).slice(1);
            }
            if (params.constructor != Array) {
                params = [params];
            }
            $.each(params, function (i, n) {
                source = source.replace(new RegExp("\\{" + i + "\\}", "g"), n);
            });
            return source;
        },
        /**
　　    * @description cookie 对象
　　    * @class 封装的读写方法
　　    */
        cookie: {
            /**
　　        * @description 保存cookie，支持一维和二维
            * @param {string} name cookie名字
            * @param {string/json} value cookie值<br/>
            * 示例1二维：json格式 {Advalue:'x1',Type:'x2'}<br/>
            * 示例2一维：字符串格式 'x1'
            * @param {json} options 扩展参数<br/>
            * 示例：{topdomain:true,expires:10}
            * @returns void
　　        */
            set: function (name, value, options) {
                var cv = "";
                options = options || {};
                value = value || null;

                if (value == null) {
                    options = $.extend({}, options);
                    options.expires = -1;
                }

                if (value != null && typeof (value) == "string") {
                    cv = escape(value).replace(/\+/g, "%2b");
                } else if (value != null && typeof (value) == "object") {
                    var jsonv = $.hFramework.cookie.ToJson($.hFramework.cookie.get(name));
                    if (jsonv == false) jsonv = {};
                    for (var k in value) {
                        eval("jsonv." + k + "=\"" + value[k] + "\"");
                    }
                    for (var k in jsonv) {
                        cv += k + '=' + escape(jsonv[k]).replace(/\+/g, "%2b") + '&';
                    }
                    cv = cv.substring(0, cv.length - 1);
                }

                var expires = "";
                if (options.expires && (typeof options.expires == 'number' || options.expires.toUTCString)) {
                    var date;
                    if (typeof options.expires == 'number') {
                        date = new Date();
                        date.setTime(date.getTime() + (options.expires * 24 * 60 * 60 * 1000));
                    } else {
                        date = options.expires;
                    }
                    expires = "; expires=" + date.toUTCString();
                }
                var path = options.path ? "; path=" + (options.path) : "; path=/";
                var domain = options.domain ? "; domain=" + (options.domain) : "";
                if (options.topdomain) {
                    var host = location.hostname
                    hostindex = host.indexOf('.');
                    if (hostindex > 0) {
                        host = host.substring(hostindex);
                        domain = "; domain=" + host;
                    }
                }
                var secure = options.secure ? "; secure" : "";
                document.cookie = [name, '=', cv, expires, path, domain, secure].join('');
            },
            /**
　　        * @description 获取cookie
            * @param {string} n cookie名字
            * @param {string} k 二维cookie的子键名<br/>
            * @returns {string} 值
                $.hFramework.cookie.get("test");
　　        */
            get: function (n, k) {
                var reg = new RegExp("(^| )" + n + "=([^;]*)(;|$)");
                var arr = document.cookie.match(reg);
                if (arguments.length == 2) {
                    if (arr != null) {
                        var kArr, kReg = new RegExp("(^| |&)" + k + "=([^&]*)(&|$)");
                        var c = arr[2];
                        var c = c ? c : document.cookie;
                        if (kArr = c.match(kReg)) {
                            return unescape(kArr[2].replace(/\+/g, "%20"));
                        } else {
                            return "";
                        }
                    } else {
                        return "";
                    }
                } else if (arguments.length == 1) {
                    if (arr != null) {
                        return unescape(arr[2].replace(/\+/g, "%20"));
                    } else {
                        return "";
                    }
                }
            },
            /**
　　        * @description 删除cookie
            * @param {string} name cookie名字
            * @param {json} options 指定domain<br/>
            * @returns {void}
　　        */
            clear: function (name, options) {
                var expires = ";expires=Thu, 01-Jan-1900 00:00:01 GMT";
                var path = options.path ? "; path=" + (options.path) : "; path=/";
                var domain = options.domain ? "; domain=" + (options.domain) : "";
                if (options.topdomain) {
                    var host = location.hostname
                    hostindex = host.indexOf('.');
                    if (hostindex > 0) {
                        host = host.substring(hostindex);
                        domain = "; domain=" + host;
                    }
                }
                var secure = options.secure ? "; secure" : "";
                document.cookie = [name, '=', expires, path, domain, secure].join('');
            }
        },
        /**
　　    * @description querystring 对象
　　    * @class 封装querystring读写方法
　　    */
        querystring: {
            /**
　　        * @description 获取queryString某个键的值
            * @param {string} key 键名
            * @returns {string} 键值
　　        */
            get: function (key) {
                var qs = $.hFramework.querystring.parse();
                var value = qs[key];
                return (value != null) ? value : "";
            },
            /**
　　        * @description 设置queryString某个键的值
            * @param {string} key 键名
            * @param {string} value 键值
            * @returns {void}
　　        */
            set: function (key, value) {
                var qs = $.hFramework.querystring.parse();
                qs[key] = encodeURIComponent(value);
                return $.hFramework.querystring.toString(qs);
            },
            /**
　　        * @private
　　        */
            parse: function (qs) {
                var params = {};

                if (qs == null) qs = location.search.substring(1, location.search.length);
                if (qs.length == 0) return params;

                qs = qs.replace(/\+/g, ' ');
                var args = qs.split('&');
                for (var i = 0, l = args.length; i < l; i++) {
                    var pair = args[i].split('=');
                    var name = pair[0];

                    var value = (pair.length == 2)
						? pair[1]
						: name;
                    params[name] = value;
                }

                return params;
            },
            /**
　　        * @private
　　        */
            toString: function (qs) {
                if (qs == null) qs = $.hFramework.querystring.parse();

                var val = "";
                for (var k in qs) {
                    if (val == "") val = "?";
                    val = val + k + "=" + qs[k] + "&";
                }
                val = val.substring(0, val.length - 1);
                return val;
            }
        },
        /**
　　    * @description 异步加载图片 对象
　　    * @class 封装异步加载图片方法
　　    */
        imgLoad: {
            /**
　　        * @private
　　        */
            objArray: [],
            /**
　　        * @description 给定区域的id,并触发异步加载行为
            * @param {[]} obj 给定区域的id数组
            * @returns {void}
　　        */
            loadImg: function (obj) {
                if (obj && obj.length > 0) {
                    for (var i = 0, l = obj.length; i < l; i++) {
                        if ($.inArray(obj[i], $.hFramework.imgLoad.objArray) == -1) {
                            $.hFramework.imgLoad.objArray.push(obj[i]);
                        }
                    }
                }
                $.hFramework.imgLoad.load();
            },
            /**
　　        * @private
　　        */
            pageTop: function () {
                return document.documentElement.clientHeight + Math.max(document.documentElement.scrollTop, document.body.scrollTop);
            },
            /**
　　        * @description 触发异步加载行为
            * @returns {void}
　　        */
            load: function () {
                for (var i = 0, l = $.hFramework.imgLoad.objArray.length; i < l ; i++) {
                    var jObj = $("#" + $.hFramework.imgLoad.objArray[i]);
                    if (jObj) {
                        jObj.find("img").each(function () {
                            if ($(this).offset().top <= $.hFramework.imgLoad.pageTop()) {
                                var src2 = $(this).attr("src2");
                                if (src2) {
                                    $(this).attr("src", src2).removeAttr("src2");
                                }
                            }
                        });
                    }
                }
            }
        },
        Json: {
            // Serializes a javascript object, number, string, or arry into JSON.
            ToJson: function (object) {
                try {
                    return JSON.stringify(object);
                } catch (e) { }
                return false;
            },
            // Converts from JSON to Javascript
            FromJson: function (text) {
                try {
                    return JSON.parse(text);
                } catch (e) {
                    return false;
                };
            }
        },
        HttpUtility: {
            UrlEncode: function (str) {
                return escape(str).replace(/\*/g, "%2A").replace(/\+/g, "%2B").replace(/-/g, "%2D").replace(/\./g, "%2E").replace(/\//g, "%2F").replace(/@/g, "%40").replace(/_/g, "%5F");
            },
            UrlDecode: function (str) {
                return unescape(str);
            }
        },
        Converter: {
            ToFloat: function (v) {
                if (!v || (v.length == 0)) {
                    return 0;
                };
                return parseFloat(v);
            }
        },
        String: {
            IsNullOrEmpty: function (v) {
                return !(typeof (v) === "string" && v.length != 0);
            },
            Trim: function (v) {
                return v.replace(/^\s+|\s+$/g, "");
            },
            TrimStart: function (v, c) {
                if ($String.IsNullOrEmpty(c)) {
                    c = "\\s";
                };
                var re = new RegExp("^" + c + "*", "ig");
                return v.replace(re, "");
            },
            TrimEnd: function (v, c) {
                if ($String.IsNullOrEmpty(c)) {
                    c = "\\s";
                };
                var re = new RegExp(c + "*$", "ig");
                return v.replace(re, "");
            },
            Camel: function (str) {
                return str.toLowerCase().replace(/\-([a-z])/g, function (m, c) { return "-" + c.toUpperCase() })
            },
            Repeat: function (str, times) {
                for (var i = 0, a = new Array(times) ; i < times; i++)
                    a[i] = str;
                return a.join();
            },
            IsEqual: function (str1, str2) {
                if (str1 == str2)
                    return true;
                else
                    return false;
            },
            IsNotEqual: function (str1, str2) {
                if (str1 == str2)
                    return false;
                else
                    return true;
            },
            MaxLengthKeyUp: function (obj, len) {
                var value = $(obj).val();
                if (value.length > len) {
                    $(obj).val(value.substring(0, len));
                }
            },
            MaxLengthKeyDown: function (obj, len) {
                if ($(obj).val().length > len) { return false; }
                return true;
            }
        },

    };

    //**************************************************************************

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
    };
})(jQuery);
/*end 通用函数*/


//Namespace
window.usingNamespace = function (a) {
    var ro = window;
    if (!(typeof (a) === "string" && a.length != 0)) {
        return ro;
    }

    var co = ro;
    var nsp = a.split(".");
    for (var i = 0; i < nsp.length; i++) {
        var cp = nsp[i];
        if (!ro[cp]) {
            ro[cp] = {};
        };
        co = ro = ro[cp];
    };

    return co;
};


usingNamespace("Web.Utils")["String"] = {
    IsNullOrEmpty: function (v) {
        return !(typeof (v) === "string" && v.length != 0);
    },
    Trim: function (v) {
        return v.replace(/^\s+|\s+$/g, "");
    }
};
