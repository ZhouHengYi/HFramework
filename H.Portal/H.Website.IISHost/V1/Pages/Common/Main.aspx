<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="H.Website.IISHost.Pages.Common.Main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>小二上菜后台管理系统</title>
    <link href="../../WebResource/css/css.css" rel="stylesheet" type="text/css" />
    <script src="../../WebResource/js/jquery.min-1.7.1.js"></script>
    <script src="../../WebResource/js/demo.js"></script>
    <script src="../../WebResource/js/Base.js"></script>
    <script src="../../WebResource/js/common.js"></script>
</head>
<body>
    <form runat="server">
        <div id="blurMenu">
        <!--头部开始-->
        <div class="headerbg">
            <div class="logo fl">
                <a href="javaScript:void(0);">
                    <img src="../../WebResource/images/Hlogo.png"  id="img_logo"/></a>
            </div>
            <div class="Hright fr">
                <div class="Hbar">
                    <div class="Hicon fl">
                        <a href="http://www.021zzd.com" target="_blank">
                            <img src="../../WebResource/images/home.jpg" /></a>
                        <a href="javaScript:location.reload();">
                            <img src="../../WebResource/images/fresh.jpg" /></a>
                        <a href="javaScript:dashboard.openHistory();">
                            <img src="../../WebResource/images/clock.jpg" /></a>
                        <a href="javaScript:history.go(-1);">
                            <img src="../../WebResource/images/return.jpg" /></a>
                        <a href="javaScript:dashboard.openHistory();">
                            <img src="../../WebResource/images/status.jpg" /></a>
                    </div>

                    <div class="Hseach fl">

                        <div class="Hselect fl">
                            <a href="javaScript:void(0);" class="white" id="a_search" tag="product">商品管理</a>
                            <div class="Hxial">
                                <a href="javaScript:void(0);" tag="product">商品管理</a>
                                <a href="javaScript:void(0);" tag="sytemUser">用户管理</a>
                            </div>
                        </div>
                        <div class="Hinput fr">
                            <input name="" type="text" class="Hiptsty" id="txt_search"/>
                            <input name="" type="button" class="Hsubsty" id="btn_search"/>
                        </div>

                    </div>

                    <div class="Hlink fl">
                        <h4><a href="#" class="white">快速链接：</a></h4>
                    </div>
                    <div class="Hrlink fr">
                        <div class="Hrlinklist fl">
                            <a href="#" class="white">小二上菜</a>
                        </div>
                        <div class="Hrlinklist fl rel">
                            <h4>
                                <asp:Literal ID="lit_UserName" runat="server"></asp:Literal>
                            </h4>
                            <div class="Hrxial">
                                <a href="javaScript:$.showWindow('系统用户密码修改','../SystemUser/UpdatePassword.aspx',700,230);" id="a_updatePassword">修改密码</a>
                                <a href="javaScript:void(0);" id="a_logout">注销</a>
                            </div>
                        </div>
                        <div class="Hrlinklist fl rel">
                            <h4>
                                <a href="#" class="Asty" style="color: #FFF;">选项</a>
                            </h4>
                            <div class="Hrxial">
                                <a href="#">中文</a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="Hbar" style="padding-top: 2px; height: 24px;">
                    <div class="Hclose fl">
                        <ul>
                            <%--<li id="Hcloseon">
                                <h4>首页</h4>
                                <h5>&nbsp;</h5>
                            </li>--%>
                        </ul>
                    </div>
                    <div class="Hnarrow fr" align="right">
                        <a href="#">
                            <img src="../../WebResource/images/hicon_20.jpg" /></a>
                    </div>
                </div>
            </div>
            <div class="clr"></div>
        </div>
        </div>
        <div class="out" id="div_menu" style="display: none;">
            <div class="out2">
                <asp:Literal ID="lit_SiteMap_Note" runat="server"></asp:Literal>
                <asp:Literal ID="lit_SiteMap_Parent" runat="server"></asp:Literal>
                <asp:Literal ID="lit_SiteMap_Child" runat="server"></asp:Literal>
                <%--<ul class="list1 float_l" id="ul_menu">
                    <li><a href="#" class="selected">控制面板</a></li>
                    <li><a href="#">测试测试</a></li>
                    <li><a href="#">测试测试</a></li>
                    <li><a href="#">测试测试</a></li>
                    <li><a href="#">测试测试</a></li>
                    <li><a href="#">测试测试</a></li>
                    <li><a href="#">测试测试</a></li>
                </ul>
                <ul class="list1 float_l" id="ul_menu2">
                    <li><a href="#" class="selected">用户管理</a></li>
                    <li><a href="#">基本信息维护</a></li>
                    <li><a href="#">系统检测</a></li>
                    <li><a href="#">测试测试</a></li>
                    <li><a href="#">测试测试</a></li>
                    <li><a href="#">测试测试</a></li>
                    <li><a href="#">测试测试</a></li>
                </ul>
                <ul class="list2 float_l" id="ul_menu3">
                    <li><a href="#" url="/pages/common/history.aspx">历史记录</a></li>
                    <li><a href="#" url="/pages/systemuser/systemuser.aspx">用户管理</a></li>
                    <li><a href="#" url="/pages/user/role.aspx">角色管理</a></li>
                    <li><a href="#" url="/pages/SystemUser_Privilege/SystemUser_Privilege.aspx">权限管理</a></li>
                </ul>--%>
                <div style="height: 0; font-size: 0; clear: both;">&nbsp;</div>
                <div class="quick textright">
                    <p class="float_l search2">
                        <input type="text" class="searchcont2" /><input type="image" src="../../WebResource/images/searchbtn2.jpg" />
                    </p>
                    <p class="all"><a href="#" class="hover">所有</a><a href="#">收藏夹</a></p>
                </div>
            </div>
            <div class="out2_r float_l">
                <p class="fourteen">常见问题</p>
                <p><a href="#">测试测试</a></p>
                <p><a href="#">测试测试</a></p>
                <p><a href="#">测试测试</a></p>
                <p><a href="#">测试测试</a></p>
                <p><a href="#">测试测试</a></p>
                <p><a href="#">测试测试</a></p>
                <p><a href="#">测试测试</a></p>
                <p><a href="#">测试测试</a></p>
                <p><a href="#">测试测试</a></p>
            </div>
        </div>        
        <iframe src="History.aspx" width="100%"  style="float: right; border:0px solid red;" scrolling="no" onload="javascript:dashboard.adjustFrameSize(this);"id="iframe_main"></iframe>
        
            <script type="text/javascript">
            var dashboard = {
                onLoad: function () {
                    //获取登录前路径
                    var returnUrl = $.hFramework.cookie.get("LoginReturnUrl");
                    if (returnUrl != "" && returnUrl.toLocaleLowerCase() != "/pages/common/dashboard.aspx") {
                        returnUrl = $.hFramework.HttpUtility.UrlDecode(returnUrl).toLowerCase();
                        if ($("a[url='" + returnUrl + "']")) {
                            var title = $("a[url='" + returnUrl + "']").text();
                            if (title != "")
                                dashboard.addTab(title, $("a[url='" + returnUrl + "']").attr("url"));
                        }
                    } else {
                        dashboard.addTab("历史记录", "/pages/common/history.aspx");
                    }
                    //读取Cookie已保存选中的Tab
                    var cookieSelTab = $.hFramework.cookie.get("SelectTab");
                    if (cookieSelTab != "") {
                        var selTab = cookieSelTab.split("&");
                        for (var i = 0; i < selTab.length; i++) {
                            var selUrl = $.hFramework.HttpUtility.UrlDecode(selTab[i]);
                            if ($("a[url='" + selUrl + "']")) {
                                var title = $("a[url='" + selUrl + "']").text();
                                if (title != "")
                                    dashboard.addTab(title, $("a[url='" + selUrl + "']").attr("url"));
                            }
                        }
                    }
                    dashboard.bindEvents();
                },
                adjustFrameSize: function (obj) {
                    var win = obj;
                    if (document.getElementById) {
                        if (win && !window.opera) {
                            if (win.contentDocument && win.contentDocument.body.offsetHeight)

                                win.height = win.contentDocument.body.offsetHeight;
                            else if (win.Document && win.Document.body.scrollHeight)
                                win.height = win.Document.body.scrollHeight;
                        }
                    }
                },
                addTab: function (title, url) {
                    var id = "";
                    if ($(".Hbar li").length == 0)
                    {
                        id = "id=\"Hcloseon\"";
                    }
                    //判断是否重复
                    url = url.toLocaleLowerCase();
                    var html = "<li tag=\"" + url + "\" " + id + "><h4 onclick=\"dashboard.tabClick(this,'" + url + "');\">" + title + "</h4><h5 onclick=\"dashboard.removeTab(this);\">&nbsp;</h5></li>";
                    if ($(".Hbar li[tag='" + url + "']").length == 0) {
                        $(".Hbar ul").append(html);
                    }
                    //记录Cookie 已选择Tab
                    var selTab;
                    if ($.hFramework.cookie.get("SelectTab")) {
                        selTab = $.hFramework.cookie.get("SelectTab");
                        if (selTab.indexOf(url) < 0)
                            selTab += "&" + url;
                    } else
                        selTab = url;

                    $.hFramework.cookie.set("SelectTab", selTab, { topdomain: true, expires: 10 });
                    $(".Hbar li[tag='" + url + "'] h4").click();
                    $.get("BrowsingHistory.aspx?cmd=add&pageName=" + title + "&pageUrl=" + url + "&timer=" + new Date().getDate());
                },
                removeTab: function (obj) {                   
                    var prev = $(obj).parent().prev();
                    $(obj).parent().remove();
                    var tag = $(obj).parent().attr("tag");
                    var selectTab = $.hFramework.cookie.get("SelectTab").toLowerCase();
                    if (selectTab.indexOf("&") > 0) {
                        selectTab = selectTab.replace("&" + tag, "");
                        $.hFramework.cookie.clear("SelectTab", { topdomain: true, expires: 10 });
                        $.hFramework.cookie.set("SelectTab", selectTab, { topdomain: true, expires: 10 });
                        prev.find("h4").click();                        
                    } else {
                        $.hFramework.cookie.clear("SelectTab", { topdomain: true, expires: 10 });
                        dashboard.addTab("历史记录", "/pages/common/history.aspx");
                    }
                },
                tabClick: function (obj, url) {
                    $(".Hbar li").attr("id","");
                    $(obj).parent().attr("id", "Hcloseon");
                    //切换Tab页
                    $("#iframe_main").attr("src", url);
                },
                openHistory: function () {
                    dashboard.addTab("历史记录", "/pages/common/history.aspx");
                },
                bindEvents: function () {
                    $("#blurMenu").click(function (obj) {
                        if (obj != null) {
                            if (obj.target.id != "img_logo") {
                                $("#div_menu").fadeOut(300);
                            }
                        }
                    });
                    $("#img_logo").click(function () {
                        if ($("#div_menu").css("display") == "none")
                            $("#div_menu").fadeIn(300);
                        else
                            $("#div_menu").fadeOut(300);
                    });
                    $("#a_logout").click(function () {
                        Portal.Main.LoginOut(function (ajaxResult) {
                            if (ajaxResult.error) {
                                document.write(ajaxResult.error.Message);
                            } else {
                                var json = eval("(" + ajaxResult.value + ")");
                                if (json.Code == "OK") {
                                    location.href = json.Return;
                                }
                            }
                        });
                    });
                    //一级导航事件
                    $("#ul_menu a").live("click", function () {
                        $("#ul_menu a").removeClass("selected");
                        $(this).addClass("selected");

                        //加载Menu2 导航数据
                        var result = Portal.Main.AjaxLoadSiteMapToParent($(this).attr("key"));
                        if (result.error) {
                            $.alert(result.error.Message);
                        } else {
                            $("#ul_menu2").html(result.value);
                            $("#ul_menu2 a").eq(0).click();
                        }
                    });
                    //二级导航事件
                    $("#ul_menu2 a").live("click", function () {
                        $("#ul_menu2 a").removeClass("selected");
                        $(this).addClass("selected");

                        //加载Menu3 导航数据
                        var result = Portal.Main.AjaxLoadSiteMapToChild($(this).attr("key"));
                        if (result.error) {
                            $.alert(result.error.Message);
                        } else {
                            $("#ul_menu3").html(result.value);
                        }
                    });
                    //三级导航事件
                    $("#ul_menu3 a").live("click", function () {
                        var title = $(this).text();
                        dashboard.addTab(title, $(this).attr("url"));
                        $("#div_menu").fadeOut(300);
                    });
                    $(".Hselect,.Hrlinklist,.put_out").hover(
                       function () { $(this).find(".Hxial,.Hrxial,.Pxial").show(0); },
                       function () { $(this).find(".Hxial,.Hrxial,.Pxial").hide(0); });
                    $(".Hxial a").click(function () {
                        $("#a_search").html($(this).html());
                        $("#a_search").attr("tag",$(this).attr("tag"));
                    });
                    $("#btn_search").click(function () {
                        var tag = $("#a_search").attr("tag");
                        var search = $("#txt_search").val();
                        if (tag == "product")
                        {

                        } else if (tag == "systemUser")
                        {

                        }
                        $.alert(tag + " | " + search);
                    });
                }
            };
            $(function () {
                dashboard.onLoad();
            });
        </script>
    </form>
</body>
</html>
