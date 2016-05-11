$(function () {
    // .container 设置了 overflow 属性, 导致 Android 手机下输入框获取焦点时, 输入法挡住输入框的 bug
    // 相关 issue: https://github.com/weui/weui/issues/15
    // 解决方法:
    // 0. .container 去掉 overflow 属性, 但此 demo 下会引发别的问题
    // 1. 参考 http://stackoverflow.com/questions/23757345/android-does-not-correctly-scroll-on-input-focus-if-not-body-element
    //    Android 手机下, input 或 textarea 元素聚焦时, 主动滚一把
    if (/Android/gi.test(navigator.userAgent)) {
        window.addEventListener('resize', function() {
            if (document.activeElement.tagName == 'INPUT' || document.activeElement.tagName == 'TEXTAREA') {
                window.setTimeout(function() {
                    document.activeElement.scrollIntoViewIfNeeded();
                }, 0);
            }
        });
    };
});

var CacheKeys= {
    Products: "Products",
    Plans :"Plans"
}


var productKey = "Products";
var planKey = "Plans";

var Cache = {
    Get: function (key) {
        console.log("Cache Get Key="+key);
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