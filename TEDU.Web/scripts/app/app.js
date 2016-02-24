(function () {
    'use strict'
    angular.module('TEDU', ['ngRoute'])
    .config(config);

    config.$inject = ['$routeProvider', '$locationProvider'];
    function config($routeProvider, $locationProvider) {
        $routeProvider
            .when('/admin', {
                templateUrl: "/scripts/app/home/index.html",
                controller: "homeCtrl"
            })
             .when('/admin/categories', {
                 templateUrl: "/scripts/app/categories/listCategories.html",
                 controller: "categoryCtrl"
             })
             .when('/admin/posts', {
                 templateUrl: "/scripts/app/posts/listPosts.html",
                 controller: "postCtrl"
             })
            .otherwise({ redirectTo: "/admin/login" });
        $locationProvider.html5Mode(true).hashPrefix('!')
    }
})();