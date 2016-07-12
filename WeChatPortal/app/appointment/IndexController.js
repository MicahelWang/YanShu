planApp.controller('HomeController', [
    '$scope', '$http', function($scope, $http) {
        $scope.Plans = new Array;
        $http.get("/api/product").
            success(function (response) {
                $('#datetimepicker').datetimepicker({
                    language:"zh-CN",
                    format: 'yyyy-mm-dd',
                    minView: "month",
                    startDate: new Date(),
                    todayHighlight: true,
                    daysOfWeekDisabled: [0, 1, 2, 4, 5, 6]
                });
                $scope.Plans = response.Data;
                Cache.Set(CacheKeys.Plans, response.Data);
            });
    }
]);
