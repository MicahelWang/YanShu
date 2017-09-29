$(function () {
    // .container 设置了 overflow 属性, 导致 Android 手机下输入框获取焦点时, 输入法挡住输入框的 bug
    // 相关 issue: https://github.com/weui/weui/issues/15
    // 解决方法:
    // 0. .container 去掉 overflow 属性, 但此 demo 下会引发别的问题
    // 1. 参考 http://stackoverflow.com/questions/23757345/android-does-not-correctly-scroll-on-input-focus-if-not-body-element
    //    Android 手机下, input 或 textarea 元素聚焦时, 主动滚一把
    if (/Android/gi.test(navigator.userAgent)) {
        window.addEventListener('resize', function () {
            if (document.activeElement.tagName == 'INPUT' || document.activeElement.tagName == 'TEXTAREA') {
                window.setTimeout(function () {
                    document.activeElement.scrollIntoViewIfNeeded();
                }, 0);
            }
        });
    };
});
Date.prototype.Format = function (fmt) { //author: meizz 
    var o = {
        "M+": this.getMonth() + 1, //月份 
        "d+": this.getDate(), //日 
        "h+": this.getHours(), //小时 
        "m+": this.getMinutes(), //分 
        "s+": this.getSeconds(), //秒 
        "q+": Math.floor((this.getMonth() + 3) / 3), //季度 
        "S": this.getMilliseconds() //毫秒 
    };
    if (/(y+)/.test(fmt)) fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o)
        if (new RegExp("(" + k + ")").test(fmt)) fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
    return fmt;
}
Date.prototype.AddDay=function (days)
{
    var n = this.getTime() + days * 24 * 60 * 60 * 1000;
    var result = new Date(n);
    return result;
}
var CacheKeys = {
    Products: "Products",
    Plans: "Plans"
}


var productKey = "Products";
var planKey = "Plans";

var Cache = {
    Get: function (key) {
        var result = localStorage.getItem(key);
        return eval(result);
    },
    Set: function (key, value) {
        if ($.isFunction(value)) {
            if (typeof localStorage[key] === 'undefined') {
                value(function (response) {
                    //var json = JSON.stringify(response);
                    //localStorage.setItem(key, json);
                    Cache.Set(key, response);
                });
            }

        } else {
            var json = JSON.stringify(value);
            localStorage.setItem(key, json);
        }

    }
}

var Utils = {
    ShowLoading: function (msg) {
        var plan = document.getElementById("loadingToast");
        if (plan) {
            plan.remove(plan.selectedIndex);
        }
        plan = CreateElement('div', { 'class': 'weui_loading_toast', id: 'loadingToast' }, { display: 'none' });
        var mask = CreateElement('div', { 'class': 'weui_mask_transparent' });
        var toast = CreateElement('div', { 'class': 'weui_toast' });
        var loading = CreateElement('div', { 'class': 'weui_loading' });
        for (var i = 0; i < 11; i++) {
            var leaf = CreateElement('div', { 'class': 'weui_loading_leaf weui_loading_leaf_' + i });
            loading.appendChild(leaf);
        }
      
        var content = CreateElement('p', { 'class': 'weui_toast_content' }, false, msg);
        toast.appendChild(loading);
        toast.appendChild(content);
        plan.appendChild(mask);
        plan.appendChild(toast);
        var container = document.getElementById("container");
        container.appendChild(plan); //漏了这一句，否则行不通 
        plan.style.display = "block";
    },
    HideLoading: function() {
        var plan = document.getElementById("loadingToast");
        if (plan) {
            plan.style.display = "none";
            plan.remove(plan.selectedIndex);
        }
    },
    Toast: function(msg) {
        var $dom = $("#toast");
        if ($dom.length === 0) {
            $dom = $('<div id="toast">\
                    <div class="weui_mask_transparent"></div>\
                    <div class="weui_toast">\
                        <i class="weui_icon_warn"></i>\
                        <p class="weui_toast_content">已完成</p>\
                    </div>\
                    </div>');
            $dom.find(".weui_toast_content").html(msg);
            $dom.appendTo($("body"));
            setTimeout(function () {
                $dom.remove();
            }, 3000);
        }
    }

}


var CreateElement = function (t, a, y, x)//编写建立一个新对象的通用方法
{
    var e = document.createElement(t);
    if (a) {
        for (var k in a) {
            if (k == 'class') e.className = a[k];
            else if (k == 'id') e.id = a[k];
            else e.setAttribute(k, a[k]);
        }
    }
    if (y) { for (var k in y) e.style[k] = y[k]; }
    if (x) { e.appendChild(document.createTextNode(x)); }
    return e;
}