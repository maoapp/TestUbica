'use strict';

app.controller("productController", function ($scope,$http) {

    $scope.test = "We are there";
    $scope.newProduct = {};
    $scope.states = {
        addActive : true,
        formActive: false      
    }

    $scope.products = [];




    $http.get(urlGet).then(function (response) {
        var data = response.data;
        $scope.products = data;
    })

    $scope.addProduct = function () {
        $http.post(urlAdd,$scope.newProduct).then(function (response) {        
            $scope.products.push($scope.newProduct);
            $scope.states.formActive = false;
            $scope.states.addActive = true;
        })
    }

    $scope.deleteProduct = function (index) {
        var id=$scope.products[index].ProductId;
        $http.post(urlDelete+'/'+id);
        $scope.products.splice(index, 1);
    }

    $scope.onForm = function () {
        $scope.states.addActive = false;
        $scope.states.formActive = true;
        $scope.newProduct = {};
    }

    $scope.cancel = function () {
        $scope.states.addActive = true;
        $scope.states.formActive = false;
    }

    $scope.orderBy = function (value) {
  
        $scope.orderSelect = value;
    }

    $scope.filterValue = function ($event) {
        if (isNaN(String.fromCharCode($event.keyCode))) {
            $event.preventDefault();
        }
    };

})