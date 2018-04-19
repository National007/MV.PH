$(function () {
    
    $.upLoadDefaults = $.upLoadDefaults || {};
    $.upLoadDefaults.property = {
        multiple: false, //多文件上床
        water: false, //是否水印
        thumbnail: false, //是否缩略图
        types: false,
        sendurl: null, //响应链接地址
        filetypes: "jpg,jpeg,png,gif,bmp", //文件类型
        filesize: "2048", //默认文件大小
        btntext: "浏览…", //按钮名称
        swf: null //swf地址
    };
    //鍒濆鍖栦笂浼犳帶浠�
    $.fn.InitUploader = function (p) {
        var fun = function (parentObj) {
            p = $.extend({}, $.upLoadDefaults.property, p || {});
            var btnObj = $('<div class="upload-btn">' + p.btntext + '</div>').appendTo(parentObj);
            //鍒濆鍖栧睘鎬�
            p.sendurl += "?action=uploadFile";
            if (!p.types) {
                p.sendurl += "&IsType=2";
            }
            if (p.water) {
                p.sendurl += "&IsWater=1";
            }
            if (p.thumbnail) {
                p.sendurl += "&IsThumbnail=1";
            }
            //if (!p.multiple) {
            //    p.sendurl += "&DelFilePath=" + parentObj.siblings(".upload-path").val();
            //}

            //鍒濆鍖朩ebUploader
            var uploader = WebUploader.create({
                auto: true, //鑷姩涓婁紶
                swf: p.swf, //SWF璺緞
                server: p.sendurl, //涓婁紶鍦板潃
                pick: {
                    id: btnObj,
                    multiple: p.multiple
                },
                accept: {
                    /*title: 'Images',*/
                    extensions: p.filetypes
                    /*mimeTypes: 'image/*'*/
                },
                fileSingleSizeLimit: p.filesize * 1024 //大小转化为KB
            });

            uploader.on('fileQueued', function (file) {
                if (parentObj.children(".upload-progress").length == 0) {
                    var fileProgressObj = $('<div class="upload-progress"></div>').appendTo(parentObj);
                    var progressText = $('<span class="txt">正在上传，请稍后...</span>').appendTo(fileProgressObj);
                    var progressBar = $('<span class="bar"><b></b></span>').appendTo(fileProgressObj);
                    var progressCancel = $('<a class="close" title="关闭">X</a>').appendTo(fileProgressObj);
                    progressCancel.click(function () {
                        fileProgressObj.remove();
                    });
                }
            });

            uploader.on('uploadProgress', function (file, percentage) {
                var progressObj = parentObj.children(".upload-progress");
                $(".txt").val(file.name);
                progressObj.find(".bar b").width(percentage * 100 + "%");
            });


            //文件上传成功
            uploader.on('uploadSuccess', function (file, data) {
                //alert(data.error+"\n"+data.url+"\n"+data.fileType);
                if (data.error == '0') {
                    if (!p.multiple) {
                        parentObj.siblings(".upload-name").val(data.filename);
                        parentObj.siblings(".upload-path").val(data.url);
                        parentObj.siblings(".upload-size").val(data.size);
                        parentObj.siblings(".upload-type").val(data.fileType);
                    } else {
                        addImage(parentObj,data);
                    }
                    var progressObj = parentObj.children(".upload-progress");

                    progressObj.children(".txt").html("上传成功" + file.name);
                   
                }
                else {
                    alert("上传失败");
                }
                uploader.removeFile(file); 
            });

            uploader.on('uploadComplete', function (file) {
                var progressObj = parentObj.children(".upload-progress");
                progressObj.children(".txt").html("浏览…");
                if (uploader.getStats().queueNum == 0) {
                    progressObj.remove();
                }
            });

        };
        return $(this).each(function () {
            fun($(this));
        });
    }

});

//批量图片上传
function addImage(targetObj,data) {
    //图片列表叠加
    var newLi = $('<li>'
    + '<input type="hidden" name="ElintAttachment" id="ElintAttachment" value="' + data.filename + '|' + data.fileType + '|' + data.url + '|' + data.size + '|'+data.thumbnail+'" />'
    + '<input type="hidden" name="hid_photo_remark" value="" />'
    + '<div class="img-box" onclick="setFocusImg(this);">'
    + '<img src="' + data.url + '" />'
    + '<span class="remark"><i>暂无描述...</i></span>'
    + '</div>'
    + '<a href="javascript:;" onclick="setRemark(this);">描述</a>'
    + '<a href="javascript:;" onclick="delImg(this);">删除</a>'
    + '</li>');
    newLi.appendTo(targetObj.siblings(".photo-list").children("ul"));

    //默认第一张图片为焦点图片
    //var focusPhotoObj = targetObj.siblings(".focus-photo");
    //if (focusPhotoObj.val() == "") {
    //    focusPhotoObj.val(thumbSrc);
    //    newLi.children(".img-box").addClass("selected");
    //}
}
//图片文件点击获取焦点
function setFocusImg(obj) {
    var focusPhotoObj = $(obj).parents(".photo-list").siblings(".focus-photo");
    focusPhotoObj.val($(obj).children("img").eq(0).attr("src"));
    $(obj).parent().siblings().children(".img-box").removeClass("selected");
    $(obj).addClass("selected");
}

//图片附件删除
function delImg(obj) {
    var d = top.dialog({
        title: '提示',
        width: '260px',
        content: '确定要删除该图片吗？',
        okValue: '确定',
        ok: function () {
            var parentObj = $(obj).parent().parent();
            $(obj).parent().remove(); //移除附件

        },
        cancelValue: '取消',
        cancel: function () { }
    }).showModal();
}
//图片附件描述
function setRemark(obj) {
    var parentObj = $(obj);
    var HideRemark = parentObj.prevAll("input[name='hid_photo_remark']").eq(0);
    var d = top.dialog({
        title: "图片描述",
        content: '<textarea id="ImageRemark" style="margin:10px 0;font-size:12px;padding:3px;color:#000;border:1px #d2d2d2 solid;vertical-align:middle;width:300px;height:50px;">' + HideRemark.val() + '</textarea>',
        button: [{
            value: '批量描述',
            callback: function () {
                var remarkObj = $('#ImageRemark', top.document);
                if (remarkObj.val() == "") {
                    top.dialog({
                        title: '提示',
                        content: '亲，总该写点什么吧？',
                        okValue: '确定',
                        ok: function () { },
                        onclose: function () {
                            remarkObj.focus();
                        }
                    }).showModal();
                    return false;
                }
                parentObj.parent().parent().find("li input[name='hid_photo_remark']").val(remarkObj.val());
                parentObj.parent().parent().find("li .img-box .remark i").html(remarkObj.val());
            }
        }, {
            value: '单张描述',
            callback: function () {
                var remarkObj = $('#ImageRemark', top.document);
                if (remarkObj.val() == "") {
                    top.dialog({
                        title: '提示',
                        content: '亲，总该写点什么吧？',
                        okValue: '确定',
                        ok: function () { },
                        onclose: function () {
                            remarkObj.focus();
                        }
                    }).showModal();
                    return false;
                }
                HideRemark.val(remarkObj.val());
                parentObj.siblings(".img-box").children(".remark").children("i").html(remarkObj.val());
            },
            autofocus: true
        }]
    }).showModal();
}

//删除附件节点
function delAttachNode(obj) {
    var d = top.dialog({
        title: '提示',
        width: '260px',
        content: '确定要删除该文件吗？',
        okValue: '确定',
        ok: function () {
            $(obj).parent().remove();
        },
        cancelValue: '取消',
        cancel: function () { }
    }).showModal();
}
