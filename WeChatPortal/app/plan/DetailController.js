planApp.controller('DetailController', [
    '$scope', '$routeParams', '$http', function($scope, $routeParams, $http) {

        $scope.Detail = {
            PlanId: $routeParams.id,
            Name: "Plan1"
        };
        $http.get("/api/product")
            .success(function(response) {
                $scope.Detail.Products = response.Data;
            });
    }
]);