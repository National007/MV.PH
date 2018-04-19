
$(function () {
    $("#parentMenu").text($("#hidMenuParent", parent.document).val());  //在iframe中获取父窗口的元素
    $("#ChildrenMenu").text($("#hidMenuChildren", parent.document).val());
});
/*全选*/
function quanxuan() {
    if ($("#font").text() == "全选") {

        $("#font").text("取消");
    }
    else {

        $("#font").text("全选");
    }

    var chk = $(":checkbox");
    for (var i = 0; i < chk.length; i++) {
        if ($("#font").text() == "取消") {
            chk[i].checked = true;
        }
        else {
            chk[i].checked = false;
        }
    }

}

///展示层
function Show_layer(title, url, w, h) {
    parent.layer.open({
        type: 2,
        title: '<span style="font-weight:bold">' + title + '</span>',
        //shadeClose: false, //点击遮罩关闭
        shade: 0.2,
        area: ["" + w + "", "" + h + ""],
        //maxmin: true,
        closeBtn: 1,
        content: ['' + url + '', 'yes'], //iframe的url，yes是否有滚动条
        //end: function () {
        //    location.reload();
        //}
    });
}
/*弹出框最大化*/
function Full_layer(title, url) {
    var index =layer.open({
        type: 2,
        title: '<span style="font-weight:bold">' + title + '</span>',
        content: url
    });
    layer.full(index);
}
/*弹出固定长度、宽度的artDialog*/
function showartDialog(title,url,w,h) {
    var d = top.dialog({
        title: '' + title + '',
        width: ""+w+"",
        height: ""+h+"",
        url: ""+url+""
    }).showModal();
}

/*弹出自适应artDialog*/
function showpadDialog(title, url) {
    var d = top.dialog({
        title: '' + title + '',
        url: "" + url + ""
    }).showModal();
}

/*关闭artDialog弹出框*/
function CloseArt() {
    var list = top.dialog.list;
    for (var i in list) {
        list[i].close();
    };
}

/*复选框全选*/
function checkAll(obj) {
    var chk = $(":checkbox");
    for (var i = 0; i < chk.length; i++) {
        if (obj.checked) {
            chk[i].checked = true;
        }
        else {
            chk[i].checked = false;
        }
    }
}

/*返回上一页*/
function back() {
    //window.location.href = document.referrer;
    window.location.href = window.history.back(-1);
}

