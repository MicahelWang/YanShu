planApp.controller('CreateController', [
    '$scope', '$http', function ($scope, $http) {
        $scope.Products = Cache.Get(CacheKeys.Products);
        $scope.SelectedProduct = false;
        $scope.CreateSuccess = false;
        $scope.CreatePlan = {
            ProductType: 0,
            PlanId: 0,
            Name: "",
            IdCardNo: "",
            ContactName: "",
            ContactPhone: "",
            Age: "",
            Sex:0
        };
        $scope.NextStep = function () {
            if ($scope.CreatePlan.ProductType !== 0) {
                $scope.SelectedProduct = true;
            }
            $scope.master = angular.copy($scope.CreatePlan);
        }
        $scope.Reset= function() {
            $scope.CreatePlan = angular.copy($scope.master);
        }
        $scope.Create = function () {
            Utils.ShowLoading("资料提交中");
            $http.get("/api/product")
           .success(function (response) {
               Utils.HideLoading();
               $scope.CreateSuccess = true;
           });
        }
    }
]);
