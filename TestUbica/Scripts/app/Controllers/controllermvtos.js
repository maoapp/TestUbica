'use strict';

app.controller("mvtosController", function ($scope, $http) {

    $scope.mvtos = [];
    $scope.thirds = [];
    $scope.newMvto = {};
    $scope.states = {
        formActive:false
    };

    $http.get(urlGetMvtoes).then(function (response) {
        var data = response.data;
        angular.forEach(data, function (item) {
            var conver = item.Date.replace(/\/Date\((-?\d+)\)\//, '$1');
            item.Date = new Date(parseInt(conver));
        }); 
        $scope.mvtos = data;
    });

    $http.get(urlGetThirds).then(function (response) {
        var data = response.data;
        $scope.third = data;
        console.log(data);
    });

    $scope.addMvto = function () {
        $http.post(urlCreate, $scope.newMvto).then(function (response) {
            var data = reponse.data;
            $scope.mvtos.push(data);
            $scope.mvtos = {};

        });
    }


    $scope.form = function (value) {
        $scope.states.formActive = value;
    };

});
