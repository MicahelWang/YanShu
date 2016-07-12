var planApp = angular.module('ngAppointmentApp', ['ngRoute'])
    .config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
        $locationProvider.html5Mode(true);
        $routeProvider.
        when('/', {
            templateUrl: '/app/appointment/_index.html',
            controller: 'HomeController'
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

