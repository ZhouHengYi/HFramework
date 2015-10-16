var bindHelper = {
    AjaxProObject:"",
    trHtml: "",
    init:function(){
        trHtml = $("#tbl_List tr").eq(1).html();
        this.search();
        $("#btn_search").click(function () {
            bindHelper.search();
        });
        $("#btn_clear").click(function () {
            $(".Consearch input").each(function () {
                $(this).val("");
            });
            $(".Consearch select").each(function () {
                $(this).val("-1");
            });
        });
        //�س��¼�,��ѯ����
        $(document).keyup(function (ev) {
            if (ev.keyCode == 13) {
                bindHelper.search();
                return false;
            }
        });
    },
    search: function (CurrentPage) {
        $("#pageIndex").html(CurrentPage);
        //��ȡ��������
        var SEntity = {
            Condition: {},
            PagingInfo: {}
        };
        //�����ѯ����
        $(".Consearch input").each(function () {
            SEntity.Condition[$(this).attr("data-Name")] = $(this).val();
        });
        $(".Consearch select").each(function () {
            SEntity.Condition[$(this).attr("data-Name")] = $(this).val();
        });
        //��ҳ����
        SEntity.PagingInfo["PageSize"] = 10;
        if (CurrentPage) {
            SEntity.PagingInfo["PageIndex"] = CurrentPage;
        }
        else {
            SEntity.PagingInfo["PageIndex"] = 1;
        }
        this.AjaxProObject.Search(SEntity, function (ajaxResult) {
            if (ajaxResult.error) {
                document.write(ajaxResult.error.Message);
            }
            else if (ajaxResult.value) {
                var json = eval("(" + ajaxResult.value + ")");
                if (json) {
                    bindHelper.bindList(json);
                }
            } else {
                $("tr[name*='bind']").remove();
                $("#tbl_List tr").eq(1).remove();
                $("#tbl_List").append("<tr name=\"bind\"><td colspan='20'>������Ϣ..!</td></tr>");
            }
        });
    },
    bindList: function (data) {
        $("tr[name*='bind']").remove();
        $("#tbl_List tr").eq(1).remove();
        //ѭ������Դ ���б��ֵ
        if (data.length > 0) {
            $(data).each(function () {
                var tData = this;
                var replaceHtml = bindHelper.trHtml;
                $(trHtml).filter("td").each(function () {
                    if ($(this).attr("bind") != "" && $(this).attr("bind") != null) {
                        var bindTag = $(this).attr("bind");
                        var newBindTag = bindTag.substring(2);
                        var oldTdHtml = $(this).context.outerHTML;                       
                        if (tData[newBindTag].toString()) {
                            var html = $(this).html();
                            if (html == "") {
                                var newTdHtml = $(this).html(tData[newBindTag]).context.outerHTML;
                                replaceHtml = replaceHtml.replace(oldTdHtml, newTdHtml);
                            } else {
                                html = html.replace("$.Value", tData[newBindTag]);
                                var newTdHtml = $(this).html(html).context.outerHTML;
                                replaceHtml = replaceHtml.replace(oldTdHtml, newTdHtml);
                            }
                        }
                    }
                });
                $("#pageTotal").html(tData.TotalCount);
                var pageSize = $("#pageSize").html();
                var pageCount = tData.TotalCount % pageSize == 0 ? tData.TotalCount / pageSize : parseInt(tData.TotalCount / pageSize) + 1;
                $("#pageCount").html(pageCount);
                $("#tbl_List").append("<tr name=\"bind\">" + replaceHtml + "</tr>");
            });
        } else {
            $("#tbl_List").append("<tr name=\"bind\"><td colspan='20'>������Ϣ..!</td></tr>");
        }
    },
    setPage: function () {
        var pageIndex = $("#txt_pageIndex").val();
        var pageCount = $("#pageCount").html();
        if (pageIndex < 1) {
            pageIndex = 1;
        } else if (pageIndex > pageCount)
        {
            pageIndex = pageCount;
        }
        if (pageIndex != $("#pageIndex").html()) {
            this.search(pageIndex);
        }
    },
    nextPage: function () {
        var pageCount = $("#pageCount").html();
        var pageIndex = $("#pageIndex").html();
        pageIndex = parseInt(pageIndex) + 1;
        if (pageIndex <= pageCount)
        {
            this.search(pageIndex);
        }
    },
    prevPage: function () {
        var pageIndex = $("#pageIndex").html();
        pageIndex = parseInt(pageIndex) - 1;
        if (pageIndex >= 1) {
            this.search(pageIndex);
        }
    },
    selectElement: function (obj) {
        if ($(obj).attr("checked")) {
            $("#tbl_List [name='selectElement']").attr("checked", true);
        } else {           
            $("#tbl_List [name='selectElement']").attr("checked", false);
        }
    },
    getSelectElementSysNo: function () {
        var ids = "";
        $("[name='selectElement']:checked").each(function () {
            ids += $(this).val() + ",";
        });
        if (ids.length > 0) {
            ids = ids.substring(0, ids.length - 1)
        }
        return ids;
    }
};