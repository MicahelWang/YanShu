var planApp = angular.module('ngPlanApp', ['ngRoute'])
    .config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
        $locationProvider.html5Mode(true);
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
        Cache.Set(CacheKeys.Products, initProducts);
    }]);
var initProducts = function (fn) {
    $.getJSON("/api/product",function (response) {
            if (response.Success) {
                var result = response.Data;
                fn(result);
            }
        });
}

