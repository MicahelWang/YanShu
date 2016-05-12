var planApp = angular.module('ngPlanApp', ['ngRoute'])
    .config(function ($routeProvider) {
        $routeProvider.
        when('/', {
            templateUrl: '/app/plan/_index.html',
            controller: 'HomeController'
        }).
        when('/Create', {
            templateUrl: '/app/plan/_create.html',
            controller: 'CreateController'
        }).
            when('/Detail/:id', {
                templateUrl: '/app/plan/_detail.html',
                controller: 'DetailController'
            }).
        otherwise({
            redirectTo: '/'
        });
    });
planApp.animation('.hide-animation', function () {
    return {
        beforeAddClass: function (element, className, done) {
            if (className === 'ng-hide') {
                element.animate({
                    opacity: 0
                }, 500, done);
            } else {
                done();
            }
        },
        removeClass: function (element, className, done) {
            if (className === 'ng-hide') {
                element.css('opacity', 0);
                element.animate({
                    opacity: 1
                }, 500, done);
            } else {
                done();
            }
        }
    };
});

var InitProducts = function (fn) {
    $.getJSON(
        "/api/product",
        function (response) {
            if (response.Success) {
                var result = response.Data;
                fn(result);
            }
        });
}

Cache.Set(CacheKeys.Products, InitProducts);
