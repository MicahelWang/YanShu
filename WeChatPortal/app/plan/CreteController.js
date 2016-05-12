planApp.controller('CreateController', [
    '$scope', function ($scope) {
        $scope.Products = Cache.Get(CacheKeys.Products);
        $scope.Plan = {
            ProductType: 0
        };
    }
]);
