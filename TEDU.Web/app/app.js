(function () {
    'use strict';
    angular.module('tedu', 
        [
        'tedu.categories',
        'tedu.accounts',
        'tedu.pages',
        'tedu.posts',
        'tedu.common'
        ])
    .config(configRoute)
    .config(configSecurity)
    .run(run);
    configRoute.$inject = ['$stateProvider', '$urlRouterProvider', '$httpProvider']
    function configRoute($stateProvider, $urlRouterProvider, $httpProvider) {
        $urlRouterProvider.otherwise("login");

        $stateProvider
              .state('base', {
                  url: "",
                  templateUrl: "/app/shared/views/base.html",
                  abstract: true
              })
              .state('login', {
                  url: "/login",
                  templateUrl: "/app/components/login/login.html",
                  controller: "loginCtrl"
              })
            .state('home', {
                url: "/admin",
                parent: 'base',
                templateUrl: "/app/components/home/index.html",
                controller: "homeCtrl"
            })
         
            
           

       
    }

    function configSecurity($httpProvider) {
        $httpProvider.interceptors.push(function ($q, $location) {
            return {
                request: function (config) {

                    return config;
                },
                requestError: function (rejection) {

                    return $q.reject(rejection);
                },
                response: function (response) {
                    if (response.status == "401") {
                        $location.path('/login');
                    }
                    //the same response/modified/or a new one need to be returned.
                    return response;
                },
                responseError: function (rejection) {

                    if (rejection.status == "401") {
                        $location.path('/login');
                    }
                    return $q.reject(rejection);
                }
            };
        });
    }

    function run() {
        $(document).ready(function () {
            $('[data-toggle=offcanvas]').click(function () {
                $('.row-offcanvas').toggleClass('active');
            });
        });
    }

})();