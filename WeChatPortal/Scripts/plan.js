angular.module('ngPlanApp', ['ngRoute'])
.controller('HomeController', ['$scope', '$http', function ($scope, $http) {
    $scope.Plans = new Array;
    $http.get("/api/product").
        success(function (response) {
            $scope.Plans = response.Data;
            Cache.Set(CacheKeys.Plans, response.Data);
        });

    console.info("HomeController");
    console.info($scope.Plans);
}])
.controller('CreateController', ['$scope', function ($scope) {
    $scope.Products = Cache.Get(CacheKeys.Products);
    $scope.Plan = {
        ProductType: 0
    };
}])
.controller('DeleteController', ['$scope', function ($scope) { }])
.controller('EditController', ['$scope', function ($scope) { }])
.controller('DetailController', ['$scope', '$routeParams', '$http', function ($scope, $routeParams, $http) {

    $scope.Detail = {
        PlanId: $routeParams.id,
        Name: "Plan1"
    };
    $http.get("/api/product")
   .success(function (response) {
       $scope.Detail.Products = response.Data;
   });
}])
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
