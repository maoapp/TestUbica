'use strict';

app.controller("mvtosController", function ($scope, $http) {

    $scope.mvtos = [];
    $scope.thirds = [       
       
    ];
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
    });

    $scope.addMvto = function () {
        console.log($scope.newMvto);
        var data = JSON.parse($scope.newMvto.ThirdId);        
        $scope.newMvto.Third = data;
        $scope.newMvto.ThirdId = data.Nit;
        console.log($scope.newMvto);
        $http.post(urlCreate, $scope.newMvto).then(function (response) {
            $scope.mvtos.push($scope.newMvto);
            $scope.newMvto = {};            
        });
    }

    $scope.delete = function (index) {
        var id = $scope.mvtos[index].MvtoId;
        console.log(id);
        $http.post(urlDelete + '/' + id).then(function (response) {
            $scope.mvtos.splice(index, 1);
        });
    };

    $scope.orderBy = function (value) {      
        $scope.orderSelect = value;
    };


    $scope.form = function (value) {
        $scope.states.formActive = value;
    };

});
