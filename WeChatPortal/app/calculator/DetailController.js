planApp.controller('DetailController', [
    '$scope', '$routeParams', '$http', function ($scope, $routeParams, $http) {
        var planId = $routeParams.id;

        var productName = "";


        var products = Cache.Get(CacheKeys.Products);

        for (var key in products) {
            var item = products[key];
            if (item.ID == planId) {
                productName = item.Name;
                break;;
            }
        }
        $scope.Detail = {
            PlanId: "Plan_" + productName,
            ProductName: productName,
            Name: "Name_" + planId,
            IdCardNo: "",
            ContactName: "",
            ContactPhone: "",
            Age: "",
            Sex: 0
        };
        $scope.Cancel = function () {
            history.go(-1);
        }
        $http.get("/api/product")
            .success(function (response) {
                $scope.Detail.Products = response.Data;
            });
    }
]);