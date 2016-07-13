﻿planApp.controller('HomeController', [
    '$scope', '$http', function ($scope, $http) {
        $('#datetimepicker').datetimepicker({
            language: "zh-CN",
            format: 'yyyy-mm-dd',
            minView: "month",
            startDate: new Date(),
            todayHighlight: true,
            daysOfWeekDisabled: [0, 1, 2, 4, 5, 6]
        });

        $scope.AppointmentPage = true;
        $scope.ShowLoading = false;
        $scope.AppointmentSuccess = false;

        $scope.Submit = function () {
            $scope.ShowLoading = true;
            console.log("11");
            $http.get("/api/product").success(function (response) {
                $scope.AppointmentPage = false;
                $scope.AppointmentSuccess = true;
            });
        };

    }
]);
