'use strict';

app.controller("companiesController", function ($scope, $http) {

    $scope.companies = [];
    $scope.states = {
        formActive: false
    };
    $scope.newCompany = {};

    $http.get(urlGet).then(function (response) {
        var data = response.data
        $scope.companies = data;
    });


    $scope.addCompany = function () {
        $http.post(urlAdd,$scope.newCompany).then(function (response) {
            var data = $scope.newCompany;
            $scope.companies.push(data);
            $scope.newCompany = {};           
        });
        $scope.states.formActive = false;
    }

    $scope.deteleCompany = function (index) {       
        var id = $scope.companies[index].ThirdId;
        $http.post(urlDelete + '/' + id);
        $scope.companies.splice(index, 1);
    }

    $scope.orderBy = function (item) {
        $scope.orderSelected = item;
    }

    $scope.form = function (state) {
        $scope.states.formActive = state;
    }

});