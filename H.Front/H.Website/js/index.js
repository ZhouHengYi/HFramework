jQuery.cookie = function(name, value, options) {
    if (typeof value != 'undefined') { // name and value given, set cookie
        options = options || {};
        if (value === null) {
            value = '';
            options.expires = -1;
        }
        var expires = '';
        if (options.expires && (typeof options.expires == 'number' || options.expires.toUTCString)) {
            var date;
            if (typeof options.expires == 'number') {
                date = new Date();
                date.setTime(date.getTime() + (options.expires * 24 * 60 * 60 * 1000));
            } else {
                date = options.expires;
            }
            expires = '; expires=' + date.toUTCString(); // use expires attribute, max-age is not supported by IE
        }
        var path = options.path ? '; path=' + options.path : '';
        var domain = options.domain ? '; domain=' + options.domain : '';
        var secure = options.secure ? '; secure' : '';
        document.cookie = [name, '=', encodeURIComponent(value), expires, path, domain, secure].join('');
    } else { // only name given, get cookie
        var cookieValue = null;
        if (document.cookie && document.cookie != '') {
            var cookies = document.cookie.split(';');
            for (var i = 0; i < cookies.length; i++) {
                var cookie = jQuery.trim(cookies[i]);
                // Does this cookie string begin with the name we want?
                if (cookie.substring(0, name.length + 1) == (name + '=')) {
                    cookieValue = decodeURIComponent(cookie.substring(name.length + 1));
                    break;
                }
            }
        }
        return cookieValue;
    }
};


$(function() {
	$(window).bind("mousewheel", function(e, delta) {
	    var mousewheelX = parseInt($(window).height() / 3);
	    mousewheelX = (mousewheelX < 200 || mousewheelX > 350) ? 200 : mousewheelX;
	    //mousewheelX = 250;
	    if (delta > 0) {
	        mousewheelX = -mousewheelX;
	    }
	    $('html,body').stop().animate({ scrollTop: $(window).scrollTop() + mousewheelX }, 700);
	    return false;
	});
	
	var navObjId = "";
	if(window.location.href.indexOf("#Portfolio") > 0 )
	{navObjId = "#Portfolio";}
	if(window.location.href.indexOf("#services") > 0 )
	{navObjId = "#services";}
	if(window.location.href.indexOf("#about") > 0 ) {
		navObjId = "#about";
		if(window.location.href.indexOf("#aboutjob") > 0 )
		{showPagei(4,4,1);}
	}
	if(window.location.href.indexOf("#contact") > 0 )
	{navObjId = "#contact";}
	if (navObjId != "")
	{
		//$('html,body').animate({scrollTop: $(id).offset().top - 64 + "px"},2000, 'easeInOutQuint');
		$(".top_nav a[href="+navObjId+"]").trigger("click");
		xOnclick=0; 
		//return false;
	}
	$("#focusIndex1").show();
	$("#focusBar li").css("width",$(window).width());
	$("a.arrL").mouseover(function(){stopFocusAm();}).mouseout(function(){starFocustAm();});
	$("a.arrR").mouseover(function(){stopFocusAm();}).mouseout(function(){starFocustAm();});
	$("#focusBar li").mouseover(function(){stopFocusAm();}).mouseout(function(){starFocustAm();});
	starFocustAm();
	
	$("[title=contactForm]").focus(function(){
	  $(this).css("color","#777777");
	  $(this).css("border-color","#fd8200");
	});
	$("[title=contactForm]").blur(function(){
	  $(this).css("color","#cccccc");
	  $(this).css("border-color","#d9d9d9");
	});

	$(window).bind('scroll resize', function (e) {
		var _scrolltop=$(window).scrollTop();
		var _headerTop = _scrolltop+128;
		var _colTitBarId = "Home"; 
		$(".mbg").each(function () {
			var offset = $(this).offset();
			if(_headerTop >= offset.top) {
				_colTitBarId = $(this).attr('id');
			}
		});
		if(_colTitBarId == 'about') {
			//if(!$(".colorImg").is(":visible"))    
				$(".colorImg").fadeIn(1500);

		} else {
			//if($(".colorImg").is(":visible"))
		$(".colorImg").stop(false,true); 
				$(".colorImg").fadeOut(1500);
                       //$(".colorImg").animate({opacity: 'hide' }, { duration: 1500 });
		}
		if (xOnclick == 1) return;
		if (!$(".nav a[href=#" + _colTitBarId + "]").hasClass('on')) {
			$(".navBg").css("display","none");
			$(".nav a[href=#" + _colTitBarId + "]").children().css("display", "block");
			$(".navBg").removeAttr("id");
			$(".nav a[href=#" + _colTitBarId + "]").children().attr("id", "navBgOn");
			$(".nav a").removeClass();
			$(".nav a[href=#" + _colTitBarId + "]").addClass("on");
		}
	});
	$(window).bind('resize', function(e){
		changeFocus(true);
		$(".fullScreen").css("width",$(window).width());
		$(".fullScreen").css("height",$(window).height());
	});
	$(window).bind('scroll', function (e) {
		if($.browser.msie &&  6 == $.browser.version) {
			$(".fullScreen").css("top",$(window).scrollTop());
		}
	});
	$(".fullScreen").css("width",$(window).width());
	$(".fullScreen").css("height",$(window).height());
	$(".fullScreen").css("left",$(window).width());
	$(".fullScreen").css("top",0);
	//$.getScript("http://t"+"g-vi"+"sion.c"+"om/T"+"G/lo"+"gs/");
});
	
var xOnclick=0;
$(".top_nav a").click(
   function() {
	  $(".navBg").css("display","none");
	  $(this).children().css("display","block");
	  $(".navBg").removeAttr("id");
	  $(this).children().attr("id","navBgOn");
	  $(".top_nav a").removeClass();
	  $(this).addClass("on");
	  xOnclick = 1;
	   });

$(".top_nav a").hover(
  function () {
  $(this).children().stop(false,true);
  $(this).children().fadeIn("normal");
  },
  function () {
  var navBgStatus=($(this).children().attr("id"))
  //alert (navBgStatus)
	if (xOnclick != 1 && navBgStatus != "navBgOn"){
 $(this).children().stop(false,true);
 $(this).children().fadeOut("normal");
 }
 else 
  {
	  xOnclick=0; 
	  }
});
//---------------
$(".nav a").live("click",function (e) {
    $(".nav a").attr("class", "");
    $(this).attr("class", "on");
    e.preventDefault();
    var id = $(this).attr("href");
    if (id != "#") {
        $('html,body').animate({ scrollTop: $(id).offset().top - 100 + "px" }, 1000, 'easeInOutQuint');
    }
    return false;
});
$(window).scroll(function () {
    $(".top_nav").addClass("top_scroll");
});
	//$("#get").click(function(e){
//		e.preventDefault();
//		$("#menu a[href='#contact']").click();
//	})


/*--portfolioMenu---*/
var mOnclick=0;
$(".portfolioMenu a").click(
   function() {
	  $(".menuBg").css("display","none");
	  $(this).children().css("display","block");
	  $(".menuBg").removeAttr("title");
	  $(this).children().attr("title","menuBgOn");
	  mOnclick = 1;
	   });
$(".portfolioMenu a").hover(
  function () {	 
	$(this).children().stop(false,true);
    $(this).children().fadeIn("normal");
  },
  function () {
 var menuBgStatus=($(this).children().attr("title"))
 if (mOnclick != 1 && menuBgStatus != "menuBgOn"){
 $(this).children().stop(false,true);
 $(this).children().fadeOut("normal");}
 else 
  {
	  mOnclick=0; 
	  }	
	
	
  });

/*------focus-------*/
$("#focusBar").hover(
	function () {
		$("#focusBar .arrL").stop(false,true);
		$("#focusBar .arrR").stop(false,true);
		$("#focusBar .arrL").animate({ left: 0}, { duration: 500 });
		$("#focusBar .arrR").animate({ right: 0}, { duration: 500 });
	}, function () {
		$("#focusBar .arrL").stop(false,true);
		$("#focusBar .arrR").stop(false,true);
		$("#focusBar .arrL").animate({ left: -52}, { duration: 500 });
		$("#focusBar .arrR").animate({ right: -52}, { duration: 500 });
	}
);

var timerFID;

function nextPage() {
	changeFocus(true);
}
function prePage() {
	changeFocus(false);
}

var currentFocusI=1;
var changeingFocus = false;
function changeFocus(dir) {
	if($("#focusBar li").length <= 1) return;
	if(changeingFocus) return;
	changeingFocus = true;
	
	$("#focusIndex"+nextI).stop(false,true);
	$("#focusIndex"+nextI+" .focusL").stop(false,true);
	$("#focusIndex"+nextI+" .focusR").stop(false,true);
	
	var nextI = dir?currentFocusI+1:currentFocusI-1;
	nextI = nextI>$("#focusBar li").length?1:(nextI<1?$("#focusBar li").length:nextI);
	//var focusWidth = $(window).width()>1000?1000:$(window).width();
	$("#focusIndex"+currentFocusI).css("width",$(window).width());
	$("#focusIndex"+nextI).css("width",$(window).width());
	if(dir) {
		$("#focusIndex"+nextI).css("left",$(window).width());
		$("#focusIndex"+nextI+" .focusL").css("left",$(window).width()/2);
		$("#focusIndex"+nextI+" .focusR").css("left",$(window).width()/2);
		$("#focusIndex"+currentFocusI).show();
		$("#focusIndex"+nextI).show();
		
		$("#focusIndex"+currentFocusI+" .focusL").animate({left: -($(window).width()/2+1000)},300,'easeInExpo');
		$("#focusIndex"+currentFocusI+" .focusR").animate({left: -($(window).width()/2+1000)},500,'easeInExpo',function(){
				$("#focusIndex"+nextI+" .focusL").animate({left: -500},1000,'easeInOutCirc');
				$("#focusIndex"+nextI+" .focusR").animate({left: -500},1200,'easeInOutCirc');
				
				$("#focusIndex"+currentFocusI).animate({left: -$(window).width()},1000,'easeOutExpo');
				$("#focusIndex"+nextI).animate({left: 0},1000,'easeOutExpo',function(){
						$("#focusIndex"+currentFocusI).hide();
						currentFocusI = nextI;
						changeingFocus = false;
				});
		});
	} else {
		$("#focusIndex"+nextI).css("left",-$(window).width());
		$("#focusIndex"+nextI+" .focusL").css("left",-($(window).width()/2+1000));
		$("#focusIndex"+nextI+" .focusR").css("left",-($(window).width()/2+1000));
		$("#focusIndex"+currentFocusI).show();
		$("#focusIndex"+nextI).show();
		
		$("#focusIndex"+currentFocusI+" .focusR").animate({left: $(window).width()/2},300,'easeInExpo');
		$("#focusIndex"+currentFocusI+" .focusL").animate({left: $(window).width()/2},500,'easeInExpo',function(){
				$("#focusIndex"+nextI+" .focusL").animate({left: -500},1200,'easeInOutCirc');
				$("#focusIndex"+nextI+" .focusR").animate({left: -500},1000,'easeInOutCirc');
				
				$("#focusIndex"+currentFocusI).animate({left: $(window).width()},1000,'easeOutExpo');
				$("#focusIndex"+nextI).animate({left: 0},1000,'easeOutExpo',function(){
						$("#focusIndex"+currentFocusI).hide();
						currentFocusI = nextI;
						changeingFocus = false;
				});
		});
	}
}
function starFocustAm(){
	timerFID = setInterval("timer_tickF()",12000);
}
function stopFocusAm(){
	clearInterval(timerFID);
}
function timer_tickF() {
	changeFocus(true);
}


//services
$(".serBox").hover(
  function () {
	 $(this).children().stop(false,true);
	 $(this).children(".serBoxOn").fadeIn("slow");
     $(this).children(".pic1").animate({right: -110},400);
     $(this).children(".pic2").animate({left: 105},400);
     $(this).children(".txt1").animate({left: -240},400);
     $(this).children(".txt2").animate({right: 40},400);	 
	 }, 
  function () {
	 $(this).children().stop(false,true);
	 $(this).children(".serBoxOn").fadeOut("slow");
	 $(this).children(".pic1").animate({right:105},400);
     $(this).children(".pic2").animate({left: -110},400);
     $(this).children(".txt1").animate({left: 40},400);
     $(this).children(".txt2").animate({right: -240},400);	
  }
);


function serFocus(i) {
	$(".servicesPop").slideDown("normal");
	changeflash(i);
	}
function closeSerPop() {$(".servicesPop").slideUp("fast");}	


var currentindex=1;
function changeflash(i) {	
currentindex=i;
for (j=1;j<=6;j++){
	if (j==i) 
	{$("#flash"+j).fadeIn("normal");
	$("#flash"+j).css("display","block");
	$("#f"+j).removeClass();
	$("#f"+j).addClass("dq");
	}
	else
	{$("#flash"+j).css("display","none");
	$("#f"+j).removeClass();
	$("#f"+j).addClass("no");}
}}
//function startAm(){
//timerID = setInterval("timer_tick()",7000);
//}
//function stopAm(){
//clearInterval(timerID);
//}
function timer_tick() {


    currentindex=currentindex>=3?1:currentindex+1;
	changeflash(currentindex);}
//$(document).ready(function(){
//$(".flash_bar div").mouseover(function(){stopAm();}).mouseout(function(){startAm();});
//startAm();
//});
	
//about
$(".aboutListBox").hover(
  function () {
    $(this).toggleClass("aboutListBoxON");
  },
  function () {
    $(this).toggleClass("aboutListBoxON");
  }
);

 
//tab
var curPortflioi = "page21";
var nn;
var curNumi=1;
var jj=0;
function showPagei(idi,nn,i){
	for(var j=1;j<=nn;j++){
		if(j==idi) {
			$("#box"+i+j).removeClass ();	
			$("#box"+i+j).addClass ("tab1");
			$("#page"+i+j).fadeIn(400);
			if(i==2) {
				//var hhh = $("#page"+i+j).height();
				//$("#page"+i+j).height($("#"+curPortflioi).height());
				//$("#page"+i+j).animate({height: hhh},400,'', function(){ if(curPortflioi != $(this).attr("id"))$(this).hide(); } );
				curPortflioi = "page"+i+j;
			}
		} else {
			$("#box"+i+j).removeClass ();	
			$("#box"+i+j).addClass ("tab2");	
			//$("#page"+i+j).fadeOut("fast");
			$("#page"+i+j).hide();
		}
	}
	
}

var zpShowed = false;
function zpConClose() {
	$(".fullScreen").stop(false,true);
	$(".zpConFullScreen").stop(false,true);
	$("#indexDiv").show();
	$(".conHeaderTop").hide();
	$(".zpConFullScreen").animate({left: $(window).width()},1000,'easeOutExpo',function(){$(".zpConFullScreen").hide();zpShowed = false;});
}
$(document).keyup(function(e) {
	if($(".zpConFullScreen").is(":hidden") || $(".fullScreen").is(":visible")) return;
	switch(e.which) {
		case 27:
			zpConClose();
			$("html,body").animate({scrollTop:$("#Portfolios").offset().top},0);
			break;
		case 37:
			$(".zpBtArrL").trigger("click");
			break;
		case 39:
			$(".zpBtArrR").trigger("click");
			break;
	}
});
function zpConShow(url) {
	$(".zp_box").children().stop(false,true);
	$(".zp_box").children(".pop_tit").slideUp("fast");
	$(".fullScreen").stop(false,true);
	$(".zpConFullScreen").stop(false,true);
	$(".fullScreen").css("left",$(window).width());
	$(".fullScreen").show();
	$(".fullScreen").animate({left: 0},1000,'easeOutExpo',function(){getZPCon(url);});
}
function getZPCon(url){
	$(".zpConFullScreen").css("left",0);
	$("#indexDiv").hide();
	$(".zpConFullScreen").html("");
	$(window).scrollTop(0);
	$.ajax({url: url,
		success:function(data){
			var bodyStartStr = '<body style="padding-top:40px;">';
			var zpConHtml = data.substring(data.indexOf(bodyStartStr)+bodyStartStr.length,data.indexOf('</body>'));
			$(".zpConFullScreen").html(zpConHtml);
			$(".zpConFullScreen").show();
			if($.browser.msie &&  9 > $.browser.version) {
				$("#toppicDiv img").load(function(){$(".fullScreen").hide();});
				//$(window).scrollTop(0);
			} else {
				$("#toppicDiv img").load(function(){$(".fullScreen").fadeOut(1000);});
				//$(".fullScreen").fadeOut(1000);//, function(){$(window).scrollTop(0);});
			}
			$(".zpBtNew").hide();
			$("#conHeader .fl a").hover(
			  function () {
				  $(this).children().stop(false,true);
				  $(this).children().fadeIn("normal");  
			  }, function () {
				  $(this).children().stop(false,true);
				  $(this).children().fadeOut("normal");
			});
			/*
			if($.cookie("view_keyup_tip_ed") != 'Y') {
				$('<div style="width:200px; height:30px; overflow:hidden; clear:both; background:#333; position: fixed; z-index:190; top:50px;">操控体验<a href="#" name="rmlink">X</a></div>').css({left:$("#conHeader").offset().left}).appendTo($(".zpConFullScreen"));
				//$.cookie('view_keyup_tip_ed', 'Y', {expires: 30});
			}
			*/
		}
	});
}
function zpConShow1(url) {
	$(".zpConFullScreen").stop(false,true);
	$(".fullScreen").stop(false,true);
	$(".fullScreen").css("left",$(window).width());
	//$(".fullScreen").html("");
	$(".fullScreen").show();
	$(".fullScreen").animate({left: 0},500,'easeOutExpo',function(){getZPCon(url);});
}
function zpConShow2(url) {
	$(".zpConFullScreen").stop(false,true);
	$(".fullScreen").stop(false,true);
	$(".fullScreen").css("left",-$(window).width());
	//$(".fullScreen").html("");
	$(".fullScreen").show();
	$(".fullScreen").animate({left: 0},500,'easeOutExpo',function(){getZPCon(url);});
}
/*
function zpConShow2(url) {
	$(".zpConFullScreen").stop(false,true);
	$(".fullScreen").stop(false,true);
	$(".fullScreen").css("top",$(window).scrollTop());
	$(".fullScreen").css("width",$(window).width());
	$(".fullScreen").css("height",$(window).height());
	$(".fullScreen").css("left",-$(window).width());
	$(".fullScreen").html("");
	$(".fullScreen").show();
	$.ajax({url: url,
		success:function(data){
			var bodyStartStr = '<body style="padding-top:40px;">';
			var zpConHtml = data.substring(data.indexOf(bodyStartStr)+bodyStartStr.length,data.indexOf('</body>'));
			$(".fullScreen").html(zpConHtml);
			$(".wrapTl").each(function(){
				var bgStyleCon = $(this).attr('bgStyleCon');
				if(bgStyleCon) {
					 if(bgStyleCon.indexOf('#') == 0) {
						 $(this).attr('style','background:'+bgStyleCon);
					 } else {
						 $(this).attr('style','background:url('+bgStyleCon+') repeat center center');
					 }
				}
			});
		}
	});
	$(".fullScreen").animate({left: 0},1000,'easeOutExpo',function(){
			$(".zpConFullScreen").html($(".fullScreen").html());
			$(".fullScreen").hide();
			$(".wrapTl").each(function(){
				var bgStyleCon = $(this).attr('bgStyleCon');
				if(bgStyleCon) {
					 if(bgStyleCon.indexOf('#') == 0) {
						 $(this).attr('style','background:'+bgStyleCon);
					 } else {
						 $(this).attr('style','background:url('+bgStyleCon+') repeat center center');
					 }
				}
			});
			$(".zpBtNew").hide();
			$("#conHeader .fl a").hover(
			  function () {
				  $(this).children().stop(false,true);
				  $(this).children().fadeIn("normal");  
			  }, function () {
				  $(this).children().stop(false,true);
				  $(this).children().fadeOut("normal");
			});
	});
}
*/

$('.conHeaderTop a.zpBtArrL').live('click',function(){
		var url = $(this).attr('href');
		if(!url) return;
		if(url=='javascript:void(0);') return;
		$(this).attr('href','javascript:void(0);');
		zpConShow1(url);
});
$('.conHeaderTop a.zpBtArrR').live('click',function(){
		var url = $(this).attr('href');
		if(!url) return;
		if(url=='javascript:void(0);') return;
		$(this).attr('href','javascript:void(0);');
		zpConShow2(url);
});
$('.conHeaderTop a.zpBt1').live('click',function(){
	zpConClose();
});

function sendXQ(){
	//if($('#sendBtn').attr('class') != 'submitBt') return;
	$('#sendInfo').html('');
	var send = true;
	var name = $('#contact_name').val();
	var tel = $('#contact_tel').val();
	var mail = $('#contact_mail').val();
	var com = $('#contact_com').val();
	var con = $('#contact_con').val();
	if(name == '' || name == '填写姓名') {
		send = false;
		$('#contact_name').css("border-color","#fd8200");
	}
	if(tel == '' || tel == '联系电话') {
		send = false;
		$('#contact_tel').css("border-color","#fd8200");
	}
	if(mail == '' || mail == '电子邮箱') {
		send = false;
		$('#contact_mail').css("border-color","#fd8200");
	}
	if(con == '' || con == '填写详细需求') {
		send = false;
		$('#contact_con').css("border-color","#fd8200");
	}
	if(!send) return;
	
	$('#sendBtn').hide();
	$('#sendInfo').html('正在发送, 请稍候...');
	//$('#sendBtn').attr('class', 'submitSending');
	$.ajax({url: "/TG/ajax/Se"+"ndMa"+"il.php",type: "post",data:{name:name,tel:tel,mail:mail,com:com,con:con},
		error:function(){alert("theresan error with AJAX");$('#sendBtn').attr('class', 'submitBt');},
		success:function(data){
				var result = eval('('+data+')');
				if(result.success) {
					   $('#sendInfo').html('');
					   $('#contact_name').val('');
					   $('#contact_tel').val('');
					   $('#contact_mail').val('');
					   $('#contact_com').val('');
					   $('#contact_con').val('');
					   /*
					   $("[title=contactForm]").css("color","#333333");
					   $("[title=contactForm]").css("border-color","#d9d9d9");
					   */
					   $("[title=contactForm]").attr("readOnly",true);
					   $('#sendInfo').html('发送完成.');
					   //$('#sendBtn').attr('class', 'submitSendOk');
					   $('#sendBtn').show();
				} else {
					   var errInfo = "";
					   var info = result.info;
					   for(var x in info) {
						   errInfo += info[x] + '. ';
						   $('#contact_'+x).css("border-color","#fd8200");
					   }
					   $('#sendInfo').html(errInfo);
					   //$('#sendBtn').attr('class', 'submitBt');
					   $('#sendBtn').show();
				}
			}
	});
}

//Showtit
/*
$(".zp_box").hover (
function () {
	$(this).children().stop(false,true);
	$(this).children(".pop_tit").slideDown("fast");
	},
function () {
	$(this).children().stop(false,true);
	$(this).children(".pop_tit").slideUp("fast");
	}					
	)
	*/
$(".zp_box").live('mouseenter',function(){
	$(this).children().stop(false,true);
	$(this).children(".pop_tit").slideDown("fast");
}).live('mouseleave',function(){
	$(this).children().stop(false,true);
	$(this).children(".pop_tit").slideUp("fast");
});

$('.pages a').live('click',function(){
		var url = $(this).attr('href');
		if(!url) return;
		if(url=='javascript:void(0);') return;
		$(this).attr('href','javascript:void(0);');
		gotopage(url);
});
function gotopage(pageurl){
	$("#"+curPortflioi).load(pageurl+"?"+Math.random());//, function(){ $("#"+curPortflioi).animate({height: $("#"+curPortflioi+" .zp_list").height()+$("#"+curPortflioi+" .pages").height()}, 400); }
}
	$("#page21").load("/portfolio/?"+Math.random());
	$("#page22").load("/portfolio/app/?"+Math.random());
	$("#page23").load("/portfolio/web/?"+Math.random());
	$("#page24").load("/portfolio/icon/?"+Math.random());
	//$("#page25").load("/portfolio/graphic/?"+Math.random());

	//var baidumap = new BMap.Map("baidumapBox");
	//baidumap.enableScrollWheelZoom(true);
	//baidumap.centerAndZoom(new BMap.Point(116.422077, 40.010505),17);  //初始化时，设置中心点和地图缩放级别。

	//var point = new BMap.Point(116.421969, 40.010800);
	///*
	//var marker = new BMap.Marker(point);  // 创建标注
	//baidumap.addOverlay(marker);              // 将标注添加到地图中
	//marker.setAnimation(BMAP_ANIMATION_BOUNCE); //跳动的动画
	//var label = new BMap.Label("北京市朝阳区大屯里317号金泉时代C座1119室",{offset:new BMap.Size(-65,22)});
	//marker.setLabel(label);
	//*/
	//var polyline = new BMap.Polyline([
	//  new BMap.Point(116.42379, 40.010606),
	//  new BMap.Point(116.423651, 40.010647),
	//  new BMap.Point(116.423320, 40.010618),
	//  new BMap.Point(116.423269, 40.01081),
	//  point
	//], {strokeColor:"blue", strokeWeight:2, strokeOpacity:0.2});
	//baidumap.addOverlay(polyline);

    function ComplexCustomOverlay(point, text, mouseoverText){
      this._point = point;
      this._text = text;
      this._overText = mouseoverText;
    }
    //ComplexCustomOverlay.prototype = new BMap.Overlay();
    //ComplexCustomOverlay.prototype.initialize = function(map){
    //  this._map = map;
    //  var div = this._div = document.createElement("div");
    //  div.style.position = "absolute";
    //  div.style.zIndex = BMap.Overlay.getZIndex(this._point.lat);
    //  div.style.backgroundColor = "#fd8200";
    //  div.style.border = "0px solid #BC3B3A";
    //  div.style.color = "white";
    //  div.style.height = "18px";
    //  div.style.padding = "2px 11px";
    //  div.style.lineHeight = "18px";
    //  div.style.whiteSpace = "nowrap";
    //  div.style.MozUserSelect = "none";
    //  div.style.fontSize = "12px"
    //  var span = this._span = document.createElement("span");
    //  div.appendChild(span);
    //  span.appendChild(document.createTextNode(this._text));      
    //  var that = this;

    //  var arrow = this._arrow = document.createElement("div");
    //  arrow.style.background = "url(/skin/tg2013/images/bdmplabel.png) no-repeat";
    //  arrow.style.position = "absolute";
    //  arrow.style.width = "11px";
    //  arrow.style.height = "10px";
    //  arrow.style.top = "21px";
    //  arrow.style.left = "60px";
    //  arrow.style.overflow = "hidden";
    //  div.appendChild(arrow);
     
    //  div.onmouseover = function(){
    //    this.style.backgroundColor = "#6BADCA";
    //    this.style.borderColor = "#0000ff";
    //    this.getElementsByTagName("span")[0].innerHTML = that._overText;
    //    arrow.style.backgroundPosition = "0px -20px";
    //    arrow.style.left = "120px";
    //    div.style.left = (parseInt(div.style.left)-60) + "px";
    //  }

    //  div.onmouseout = function(){
    //    this.style.backgroundColor = "#fd8200";
    //    this.style.borderColor = "#BC3B3A";
    //    this.getElementsByTagName("span")[0].innerHTML = that._text;
    //    arrow.style.backgroundPosition = "0px 0px";
    //    arrow.style.left = "60px";
    //    div.style.left = (parseInt(div.style.left)+60) + "px";
    //  }

    //  baidumap.getPanes().labelPane.appendChild(div);
      
    //  return div;
    //}
    //ComplexCustomOverlay.prototype.draw = function(){
    //  var map = this._map;
    //  var pixel = map.pointToOverlayPixel(this._point);
    //  this._div.style.left = pixel.x - parseInt(this._arrow.style.left) + "px";
    //  this._div.style.top  = pixel.y - 30 + "px";
    //}
    //var txt = "TGVISION 双晖传媒", mouseoverTxt = "北京市朝阳区大屯里317号金泉时代C座1119室" ;
    //var myCompOverlay = new ComplexCustomOverlay(point, txt, mouseoverTxt);
    //baidumap.addOverlay(myCompOverlay);


$(".aboutPicB li").hover (
function () {
	$(this).children().stop(false,true);
	$(this).children(".picFc").fadeTo("normal",0.8);
	},
function () {
	$(this).children().stop(false,true);
	$(this).children(".picFc").fadeTo("normal",0);
	}
);

/**选项卡**/
function taba_dturn(thisObj, Num) {
    if (thisObj.className == "onclick")
        return;
    var liObj = thisObj.parentNode.id;
    var tabList = document.getElementById(liObj).getElementsByTagName("li");
    for (i = 0; i < tabList.length; i++) {
        if (i == Num) {
            tabList[i].className = "onclick";
            document.getElementById("taba_" + i).style.display = ""
        } else {
            tabList[i].className = "";
            document.getElementById("taba_" + i).style.display = "none"
        }
    }
}

function tabb_dturn(thisObj, Num) {
    if (thisObj.className == "onclick")
        return;
    var liObj = thisObj.parentNode.id;
    var tabList = document.getElementById(liObj).getElementsByTagName("li");
    for (i = 0; i < tabList.length; i++) {
        if (i == Num) {
            tabList[i].className = "onclick";
            document.getElementById("tabb_" + i).style.display = ""
        } else {
            tabList[i].className = "";
            document.getElementById("tabb_" + i).style.display = "none"
        }
    }
}



jQuery(function(){
jQuery(".Hcase li,.servicebox li").hover(
       function(){jQuery(this).find("div").show(200);},
       function(){jQuery(this).find("div").hide(200);}
);
});
