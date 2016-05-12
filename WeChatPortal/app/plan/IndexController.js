planApp.controller('HomeController', [
    '$scope', '$http', function($scope, $http) {
        $scope.Plans = new Array;
        $http.get("/api/product").
            success(function(response) {
                $scope.Plans = response.Data;
                Cache.Set(CacheKeys.Plans, response.Data);
            });
        console.info("HomeController");
        console.info($scope.Plans);
    }
]);
