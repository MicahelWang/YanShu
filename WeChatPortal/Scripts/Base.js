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

var CacheKeys = {
    Products: "Products",
    Plans: "Plans"
}


var productKey = "Products";
var planKey = "Plans";

var Cache = {
    Get: function (key) {
        console.log("Cache Get Key=" + key);
        var result = localStorage.getItem(key);
        return eval(result);
    },
    Set: function (key, value) {
        if ($.isFunction(value)) {
            if (typeof localStorage[key] === 'undefined') {
                value(function (response) {
                    console.log(response);
                    //var json = JSON.stringify(response);
                    //localStorage.setItem(key, json);
                    Cache.Set(key, response);
                });
            }

        } else {
            var json = JSON.stringify(value);
            console.log("Cache Set Key=" + key + ",Value=" + json);
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