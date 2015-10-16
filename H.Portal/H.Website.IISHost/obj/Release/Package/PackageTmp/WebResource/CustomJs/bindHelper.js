var bindHelper = {
    AjaxProObject:"",
    trHtml: "",
    init: function () {
        $("#tbl_List [name='title-table-checkbox']").each(function () {
            $(this).parent().removeClass("checked");
        });
        trHtml = $("#tbl_List tr").eq(1).html();
        $("#tbl_List").append('<tr name=\"tr_loading\"><td colspan="10"><div class="progress progress-striped active"><div class="bar" style="width: 100%;"></div></div></td><tr>');
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
        //回车事件,查询数据
        $(document).keyup(function (ev) {
            if (ev.keyCode == 13) {
                bindHelper.search();
                return false;
            }
        });
    },
    search: function (CurrentPage) {
        //获取搜索条件
        var SEntity = {
            Condition: {},
            PagingInfo: {}
        };
        //对象查询条件
        $(".controls input").each(function () {
            SEntity.Condition[$(this).attr("data-Name")] = $(this).val();
        });
        $(".controls select").each(function () {
            SEntity.Condition[$(this).attr("data-Name")] = $(this).val();
        });
        //分页条件
        SEntity.PagingInfo["PageSize"] = 10;
        if (CurrentPage) {
            SEntity.PagingInfo["PageIndex"] = CurrentPage;
        }
        else {
            SEntity.PagingInfo["PageIndex"] = 1;
        }


        $("#pageIndex").val(SEntity.PagingInfo["PageIndex"]);
        this.AjaxProObject.Search(SEntity, function (ajaxResult) {
            if (ajaxResult.error) {
                document.write(ajaxResult.error.Message);
            }
            else if (ajaxResult.value) {
                var json = eval("(" + ajaxResult.value + ")");
                if (json) {
                    bindHelper.bindList(json, $("#tbl_List"));
                }
            } else {
                $("tr[name*='bind']").remove();
                $("#tbl_List tr").eq(1).remove();
                $("#tbl_List").append("<tr name=\"bind\"><td colspan='20'>暂无信息..!</td></tr>");
            }
        });
    },
    bind: function (ajaxResult, dataControl) {
        $(dataControl).find("[name*='tr_loading']").remove();

        if (ajaxResult.error) {
            document.write(ajaxResult.error.Message);
        }
        else if (ajaxResult.value) {
            var json = eval("(" + ajaxResult.value + ")");
            if (json) {
                bindHelper.bindList(json, dataControl);
            }
        } else {
            $(dataControl).find("tr[name*='bind']").remove();
            $(dataControl).find("tr").eq(1).remove();
            $(dataControl).append("<tr name=\"bind\"><td colspan='20'>暂无信息..!</td></tr>");
        }
    },
    bindList: function (data, dataControl) {
        $(dataControl).find("tr[name*='bind']").remove();
        $(dataControl).find("tr").eq(1).remove();
        $(dataControl).find("tr[name*='tr_loading']").remove();
        //循环数据源 给列表绑值
        if (data.length > 0) {
            $(data).each(function () {
                var tData = this;
                var replaceHtml = bindHelper.trHtml;
                if (replaceHtml == "") {
                    replaceHtml = trHtml;
                    bindHelper.trHtml = trHtml;
                }
                $(bindHelper.trHtml).filter("td").each(function () {
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
                //$("#pageTotal").html(tData.TotalCount);
                $("#pageTotal").val(tData.TotalCount);
                var pageSize = $("#pageSize").val();
                var pageCount = tData.TotalCount % pageSize == 0 ? tData.TotalCount / pageSize : parseInt(tData.TotalCount / pageSize) + 1;
                //$("#pageCount").html(pageCount);
                $("#pageCount").val(pageCount);
                $(dataControl).append("<tr name=\"bind\">" + replaceHtml + "</tr>");

                
            });

            $("#tbl_List [name='selectElement']").bind("click",function () {
                if ($(this).attr("checked")) {
                    $(this).parent().addClass("checked");
                } else {
                    $(this).parent().removeClass("checked");
                }
            });

            $.get("/UserControls/UCPaginationBar_Ajax.aspx?PageSize=" + $("#pageSize").val() + "&RecordCount=" + $("#pageTotal").val() + "&CurrentPageNumber=" + $("#pageIndex").val(), function (result) {
                $("#div_pager").html(result);
            })

        } else {
            $(dataControl).append("<tr name=\"bind\"><td colspan='20'>暂无信息..!</td></tr>");
            $("#div_pager").html("");
        }
    },
    setPage: function (pageIndex) {
        //var pageIndex = $("#txt_pageIndex").val();
        var pageCount = $("#pageCount").val();
        if (pageIndex < 1) {
            pageIndex = 1;
        } else if (pageIndex > pageCount)
        {
            pageIndex = pageCount;
        }
        if (pageIndex != $("#pageIndex").val()) {
            this.search(pageIndex);
        }
    },
    nextPage: function () {
        var pageCount = $("#pageCount").val();
        var pageIndex = $("#pageIndex").val();
        pageIndex = parseInt(pageIndex) + 1;
        if (pageIndex <= pageCount)
        {
            this.search(pageIndex);
        }
    },
    prevPage: function () {
        var pageIndex = $("#pageIndex").val();
        pageIndex = parseInt(pageIndex) - 1;
        if (pageIndex >= 1) {
            this.search(pageIndex);
        }
    },
    lastPage:function(){
        var pageIndex = $("#pageCount").val();
        pageIndex = parseInt(pageIndex) - 1;
        if (pageIndex >= 1) {
            this.search(pageIndex);
        }
    },
    firstPage: function () {
        var pageIndex = $("#pageIndex").val();
        pageIndex = parseInt(pageIndex) - 1;
        if (pageIndex >= 1) {
            this.search(pageIndex);
        }
    },
    selectElement: function (obj) {
        if ($(obj).attr("checked")) {
            $("#tbl_List [name='selectElement']").attr("checked", true);
            $("#tbl_List [name='selectElement']").each(function () {
                $(this).parent().addClass("checked");
            });
        } else {           
            $("#tbl_List [name='selectElement']").attr("checked", false);
            $("#tbl_List [name='selectElement']").each(function () {
                $(this).parent().removeClass("checked");
            });
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