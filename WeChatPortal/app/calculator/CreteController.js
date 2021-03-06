﻿planApp.controller('CreateController', [
    '$scope', '$http', function ($scope, $http) {
        $scope.Products = Cache.Get(CacheKeys.Products);
        $scope.SelectedProduct = false;
        $scope.CreateSuccess = false;
        $scope.CreatePlan = {
            ProductType: 0,
            SumAssured: 0,
            ShowSumAssured: false,
            SumAssuredArray: [{ Text: "请选择", Value: "0" }],
            PaymentTerms: 0,
            ShowPaymentTerms: false,
            PaymentTermsArray: [{ Text: "请选择", Value: "0" }],
            Currency: 0,
            ShowCurrency: false,
            CurrencyArray: [{ Text: "请选择", Value: "0" }],
            SmokingStatus: false,
            ShowSmokingStatus: false,
            Age: "",
            ShowAge: false,
            Gender: 0,
            ShowGender: false
        };
        $scope.NextStep = function () {
            if ($scope.CreatePlan.ProductType !== 0) {
                switch ($scope.CreatePlan.ProductType) {
                    case "1":
                        $scope.CreatePlan.ShowAge = true;
                        $scope.CreatePlan.ShowPaymentTerms = true;
                        $scope.CreatePlan.ShowSumAssured = true;
                        $scope.CreatePlan.SumAssuredArray = [{ Text: "请选择", Value: "0" }, { Text: "10万", Value: "10" }, { Text: "20万", Value: "20" }, { Text: "50万", Value: "50" }, { Text: "100万", Value: "100" }];
                        $scope.CreatePlan.PaymentTermsArray = [{ Text: "请选择", Value: "0" }, { Text: "5年", Value: "5ys" }, { Text: "10年", Value: "10ys" }, { Text: "一次结清", Value: "sin" }];
                        break;
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                        $scope.CreatePlan.ShowGender = true;
                        $scope.CreatePlan.ShowAge = true;
                        $scope.CreatePlan.ShowPaymentTerms = true;
                        $scope.CreatePlan.ShowSumAssured = true;
                        $scope.CreatePlan.ShowSmokingStatus = true;
                        $scope.CreatePlan.ShowCurrency = true;
                        $scope.CreatePlan.SumAssuredArray = [{ Text: "请选择", Value: "0" }, { Text: "10万", Value: "10" }, { Text: "20万", Value: "20" }, { Text: "50万", Value: "50" }, { Text: "100万", Value: "100" }];
                        $scope.CreatePlan.PaymentTermsArray = [{ Text: "请选择", Value: "0" }, { Text: "10年", Value: "10ys" }, { Text: "18年", Value: "sin" }];
                        $scope.CreatePlan.CurrencyArray = [{ Text: "请选择", Value: "0" }, { Text: "美元", Value: "usd" }, { Text: "港币", Value: "hkd" }];
                    default:

                }
                $scope.SelectedProduct = true;
            }

            $scope.master = angular.copy($scope.CreatePlan);
        }
        $scope.Reset = function () {
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
