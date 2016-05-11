$(function () {
    Cache.Set(productKey, InitProducts);
});

var InitProducts = function (fn) {
    $.getJSON("/api/product", function (response) {
        if (response.Success) {
            var result = response.Data;
            fn(result);
        };
    });
}
var InitPlans = function (fn) {
    $.getJSON("/api/product", function (response) {
        if (response.Success) {
            var result = response.Data;
            fn(result);
        };
    });
}

angular.module('ngRouteExample', ['ngRoute'])
.controller('HomeController', function ($scope) {
    $scope.Plans =new Array;
    InitPlans(function (data) {
        $scope.Plans = data;
        console.info($scope.Plans);
        //Cache.Set(CacheKeys.Plans, data);
    });
    console.info("HomeController");
    console.info($scope.Plans);
})
.controller('CreateController', function ($scope) {
    $scope.Products = Cache.Get(CacheKeys.Products);
})
.controller('DeleteController', function ($scope) { })
.controller('EditController', function ($scope) { })
.controller('DetailController', function ($scope, $routeParams, $http) {

    $scope.Detail = {
        PlanId: $routeParams.id,
        Name: "Plan1"
    };
    $http.get("/api/product")
   .success(function (response) { $scope.Detail.Products = response.Data; });
})
.config(function ($routeProvider) {
    $routeProvider.
    when('/', {
        templateUrl: 'tpl_planIndex',
        controller: 'HomeController'
    }).
    when('/Create', {
        templateUrl: 'tpl_planCreate',
        controller: 'CreateController'
    }).
        when('/Detail/:id', {
            templateUrl: 'tpl_planDetail',
            controller: 'DetailController'
        }).
        when('/Delete/:id', {
            templateUrl: 'tpl_planDetail',
            controller: 'DeleteController'
        }).
        when('/Edit/:id', {
            templateUrl: 'tpl_planEdit',
            controller: 'EditController'
        }).
    otherwise({
        redirectTo: '/'
    });
});