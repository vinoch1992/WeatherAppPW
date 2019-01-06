var weatherapp = angular.module('weatherapp', ['ngRoute']);

weatherapp.config(function ($routeProvider) {
    $routeProvider

        .when('/', {
            templateUrl: 'pages/weather.html',
            controller: 'weatherController'
        });
});

weatherapp.controller('weatherController', function ($scope, $http, $rootScope, $location) {
    $scope.weather = function () {
        if ($scope.zipcode === undefined || $scope.zipcode == null)
            alert("Zip code must be entered!");
        else {
            $http(
                {
                    method: 'GET',
                    url: 'http://weatherapppwapp.azurewebsites.net/api/values?zipcode='+$scope.zipcode,
                }).then(function successCallback(response) {
                    if (response.data == null || response.data == "")
                        alert("Invalid Zip Code!");
                    else {
                        if(response.data.cityName == null || response.data.cityName == '')
                            alert("Invalid Zip Code!");                        
                        else
                            $scope.weatherInfo = 'At the location ' + response.data.cityName + ', the temperature is ' + response.data.temprature + ', the timezone is ' + response.data.timeZone + ', and the elevation is '+ response.data.elevation+'.';
                    }
                }, function errorCallback(response) {
                    alert("Connection with server is failed!");
                });
        }
    };
});