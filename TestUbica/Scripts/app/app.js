
var app = angular.module("storeApp", ['ngRoute', 'ui.bootstrap']);

app.config(function ($routeProvider,$locationProvider) {
    $routeProvider
    .when('/productos', {
        templateUrl: 'Templates/product.html',
        controller:'Controllers/controllerproduct.js'
    })
    .when('/terceros', {
        templateUrl: "Templates/companies.html",
        controller:"Controllers/controllercompanies.js"
    })
});

