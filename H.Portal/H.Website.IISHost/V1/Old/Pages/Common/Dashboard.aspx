<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="H.Portal.IISHost.Pages.Common.Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>后台</title>
    <link href="../../WebResource/css/index.css" rel="stylesheet" />
    <script src="../../WebResource/js/jquery.min-1.7.1.js"></script>    
    <script src="../../WebResource/js/common.js"></script>    
    <script src="../../WebResource/js/Base.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="blurMenu">
        <div class="top">
            <img src="../../WebResource/images/mainlogo.jpg" class="float_l" id="img_logo"/>
            <div class="div_1">                
                <div class="div_2">
                    <a href="#">
                        <img src="../../WebResource/images/home.jpg" /></a><a href="#"><img src="../../WebResource/images/fresh.jpg" /></a><a href="#"><img src="../../WebResource/images/clock.jpg" /></a><a href="#"><img src="../../WebResource/images/return.jpg" /></a><a href="#"><img src="../../WebResource/images/status.jpg" /></a>
                    <div class="search">
                        <select class="select">
                            <option>查看日志</option>
                        </select><input type="text" class="searchcont" /><input type="image" class="searchbtn" src="../../WebResource/images/searchbtn.jpg" />
                    </div>
                    <div class="loginOut">
                        <img src="../../WebResource/images/logOut.png" width="35" height="28" id="img_loginOut" style="cursor:pointer;" title="退出系统" />
                    </div>                    
                </div>
            </div>
            <div id="tabs">
            </div>
        </div>
        <iframe src="History.aspx" width="100%"  style="float: right; border:0px solid red;" scrolling="no" onload="javascript:dashboard.adjustFrameSize();"id="iframe_main"></iframe>
        </div>
        <div class="out" id="div_menu" style="display:none;">
            <div class="out2">
                <ul class="list1 float_l" id="ul_menu">
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
                    <li><a href="#" url="/pages/user/user.aspx">用户管理</a></li>
                    <li><a href="#" url="/pages/user/role.aspx">角色管理</a></li>
                    <li><a href="#" url="/pages/user/privilege.aspx">权限管理</a></li>
                </ul>
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
                        dashboard.addTab("历史记录", "/Pages/Common/History.aspx");
                    }
                    //读取Cookie已保存选中的Tab
                    var cookieSelTab = $.hFramework.cookie.get("SelectTab");
                    if (cookieSelTab != "")
                    {
                        var selTab = cookieSelTab.split("&");
                        for (var i = 0; i < selTab.length; i++) {
                            var selUrl = $.hFramework.HttpUtility.UrlDecode(selTab[i]).toLowerCase();
                            if ($("a[url='" + selUrl + "']")) {
                                var title = $("a[url='" + selUrl + "']").text();
                                if(title != "")
                                    dashboard.addTab(title, $("a[url='" + selUrl + "']").attr("url"));
                            }
                        }
                    }

                    $("#blurMenu").click(function (obj) {
                        if (obj != null) {
                            if (obj.target.id != "img_logo")
                                $("#div_menu").fadeOut(300);
                        }
                    });

                    $("#img_logo").click(function () {
                        if ($("#div_menu").css("display") == "none")
                            $("#div_menu").fadeIn(300);
                        else
                            $("#div_menu").fadeOut(300);
                    });

                    $("#img_loginOut").click(function () {
                        Portal.Dashboard.LoginOut(function (ajaxResult) {
                            var json = eval("(" + ajaxResult.value + ")");
                            if (json.Code == "OK") {
                                location.href = json.Return;
                            } else {
                                alert("登录失败！");
                            }
                        });
                    });
                    $("#ul_menu a").click(function () {
                        $("#ul_menu a").removeClass("selected");
                        $(this).addClass("selected");

                        //加载Menu2 导航数据
                    });

                    $("#ul_menu2 a").click(function () {
                        $("#ul_menu2 a").removeClass("selected");
                        $(this).addClass("selected");

                        //加载Menu3 导航数据
                    });

                    //新增Tab窗口页面
                    $("#ul_menu3 a").click(function () {
                        var title = $(this).text();
                        dashboard.addTab(title, $(this).attr("url"));
                        $("#div_menu").fadeOut(300);
                    });
                },
                adjustFrameSize: function () {
                    var frm = document.getElementById("iframe_main"); //将iframe1替换为你的ID名
                    var subWeb = document.frames ? document.frames[down].document : frm.contentDocument;
                    if (frm != null && subWeb != null) {
                        frm.style.height = "500px"; //初始化一下,否则会保留大页面高度
                        frm.style.height = subWeb.documentElement.scrollHeight + "px";
                        subWeb.body.style.overflowX = "auto";
                        subWeb.body.style.overflowY = "auto";
                    }
                },
                addTab: function (title,url) {
                    var html = "<div class=\"tab\" tag=\"" + url + "\"><span class=\"section\"><b class=\"float_raa close\" onclick=\"dashboard.removeTab(this);\">×</b><a href=\"javaScript:dashboard.tabClick('" + url + "');\" style=\"cursor:pointer;\"><b>" + title + "</b></a></span></div>";
                    if ($("#tabs div[tag='" + url + "']").length == 0)
                        $("#tabs").append(html);
                    $("#iframe_main").attr("src", url);

                    //记录Cookie 已选择Tab
                    var selTab;
                    if ($.hFramework.cookie.get("SelectTab")) {
                        selTab = $.hFramework.cookie.get("SelectTab");
                        if(selTab.indexOf(url) < 0)
                            selTab += "&" + url;
                    } else
                        selTab = url;

                    $.hFramework.cookie.set("SelectTab", selTab, { topdomain: true, expires: 10 });
                },
                removeTab: function (obj) {
                    $(obj).parent().parent().remove();
                    var tag = $(obj).parent().parent().attr("tag");
                    var selectTab = $.hFramework.cookie.get("SelectTab");
                    selectTab = selectTab.replace("&" + tag, "");
                    $.hFramework.cookie.clear("SelectTab",{ topdomain: true, expires: 10 });
                    $.hFramework.cookie.set("SelectTab", selectTab, { topdomain: true, expires: 10 });
                },
                tabClick: function (url) {
                    //切换Tab页
                    $("#iframe_main").attr("src", url);
                },
                
            };
            $(function () {                
                dashboard.onLoad();
            });            
        </script>
    </form>
</body>
</html>
