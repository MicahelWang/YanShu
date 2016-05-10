angular.module('ngRouteExample', ['ngRoute'])
.controller('HomeController', function ($scope) {  })
.controller('AboutController', function ($scope) { })
.controller('CreateController', function ($scope) { })
.controller('DeteleController', function ($scope) { })
.controller('EditController', function ($scope) { })
.controller('DetailController', function ($scope) { })
.config(function ($routeProvider) {
    $routeProvider.
    when('/home', {
        templateUrl: 'embedded.home.html',
        controller: 'HomeController'
    }).
    when('/about', {
        templateUrl: 'embedded.about.html',
        controller: 'AboutController'
    }).
    otherwise({
        redirectTo: '/home'
    });
});
