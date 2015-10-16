
$(document).ready(function(){
    var login = $("[tag='loginform']");
	var recover = $('#recoverform');
	var speed = 400;

	$('#to-recover').click(function(){
		
	    $("[tag='loginform']").slideUp();
		$("#recoverform").fadeIn();
	});
	$('#to-login').click(function(){		
		$("#recoverform").hide();
		$("[tag='loginform']").fadeIn();
	});
    
	if ($.browser.msie == true && $.browser.version.slice(0, 3) < 10) {
	    $('input[placeholder]').each(function () {

	        var input = $(this);

	        $(input).val(input.attr('placeholder'));

	        $(input).focus(function () {
	            if (input.val() == input.attr('placeholder')) {
	                input.val('');
	            }
	        });

	        $(input).blur(function () {
	            if (input.val() == '' || input.val() == input.attr('placeholder')) {
	                input.val(input.attr('placeholder'));
	            }
	        });
	    });
	}

    //�س��¼�,��ѯ����
	$(document).keyup(function (ev) {
	    if (ev.keyCode == 13) {
	        $(".btn-success").click();
	        return false;
	    }
	    return true;
	});
	$("#btn_login").click(function () {
	    var returnUrl = $.hFramework.querystring.get("ReturnUrl");
	    var loginName = $("#txt_LoginName").val();
	    var reg = /^[^\s]{4,20}$/;
	    if (!reg.test(loginName)) {
	        $.alert("�������û���4-20�ַ�!");
	        return;
	    }

	    var pwd = $("#txt_LoginPwd").val();
	    var reg2 = /^[^\s]{6,20}$/;
	    if (!reg2.test(pwd)) {
	        $.alert("����������6-20�ַ�!");
	        return;
	    }
	    Portal.Login.Loging(loginName, pwd, function (ajaxResult) {
	        if (ajaxResult.error) {
	            $.alert(ajaxResult.error.Message);
	        } else {
	            var json = eval("(" + ajaxResult.value + ")");
	            if (json.Code == "OK") {
	                if (returnUrl) {
	                    location.href = $.hFramework.HttpUtility.UrlDecode(returnUrl);
	                } else {
	                    location.href = json.Return;
	                }
	            } else {
	                $.alert(json.Message);
	            }
	        }
	    });
	});

	$("#btn_Send").click(function () {
	    var newLogin = $(".NewLoginName").val();
	    if (newLogin.length == 0) {
	        $.alert("�Լ���,�α���..!");
	        return;
	    }
	    var reg = /^[^\s]{4,20}$/;
	    if (!reg.test(newLogin)) {
	        $.alert("�������û���4-20�ַ�!");
	        return;
	    }
	    var email = $(".txt_Email").val();
	    var reg = /^[^\s]{4,20}$/;
	    if (!reg.test(email)) {
	        $.alert("������������4-20�ַ�!");
	        return;
	    }

	    Portal.Login.Register(newLogin, email, function (ajaxResult) {
	        if (ajaxResult.error) {
	            $.alert(ajaxResult.error.Message);
	        } else {
	            var json = eval("(" + ajaxResult.value + ")");
	            if (json.Code == "OK") {
	                $.alert(json.Message);
	            } else {
	                $.alert(json.Message);
	            }
	        }
	    });
	})
});