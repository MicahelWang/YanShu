planApp.controller('HomeController', [
    '$scope', '$http', function ($scope, $http) {
        var allowWeekDay = 4;

        $scope.AppointmentPage = true;
        $scope.ShowLoading = false;
        $scope.AppointmentSuccess = false;
        $scope.Appointment = {
            PhoneNum: "",
            Date: ""
        };
        $scope.allowAppointmentDate = new Array();
        var now = new Date();
        var weekIndex = now.getUTCDay();
        console.log(weekIndex);
        var startDate = now.AddDay(allowWeekDay - weekIndex);
        if (weekIndex > allowWeekDay) {
            startDate=startDate.AddDay(7);
        }
        console.log(startDate.Format("yyyy-MM-dd"));
        for (var i = 0; i < 8; i++) {
            var item = startDate.AddDay(7*i);
            $scope.allowAppointmentDate.push(item.Format("yyyy-MM-dd"));
        }
        $scope.Submit = function () {
            $scope.ShowLoading = true;

            $http.post("/MobileApi/Appointment", $scope.Appointment).success(function (response) {
                $scope.AppointmentPage = false;
                $scope.AppointmentSuccess = true;
            });
        };
        //$("#datetimepicker").jalendar({
        //    customDay: startDate.Format("yyyy-MM-dd"),
        //    type: 'selector',
        //    dateType: 'yyyy-mm-dd',
        //    color: '#577e9a', // Unlimited
        //    color2: '#57c8bf', // Unlimited,
        //    titleColor: '#666',
        //    done: function () {
        //        var value = $('#datetimepicker input.data1').val();
        //        var selectDate = new Date(value);
        //        if (selectDate.getUTCDay() !== allowWeekDay) {
        //            $("#datetimepicker").find(".day.this-month.selected").removeClass("selected");
        //            Utils.Toast("只能预约今天之后的周五");
        //            event.preventDefault();
        //            return false;
        //        }
        //        var result = selectDate.Format("yyyy-MM-dd");
        //        $scope.Appointment.Date = result;
        //        $scope.$apply();
        //    }

        //});
        $('#datetimepicker').datetimepicker({
            language: "zh-CN",
            format: 'yyyy-mm-dd',
            minView: "month",
            startDate: new Date(),
            todayHighlight: true,
            daysOfWeekDisabled: [0, 1, 2, 3, 4, 6]
        }).on('changeDate', function (ev) {
            console.log(ev);
            var result = ev.date.Format("yyyy-MM-dd");
            $scope.Appointment.Date = result;
            $scope.$apply();
        });

    }
]);
