(function (app) {
    'use strict';

    app.controller('rootCtrl', rootCtrl);

    rootCtrl.$inject = ['$state', 'authData', 'loginService', '$scope','authenticationService'];
    function rootCtrl($state, authData, loginService, $scope, authenticationService) {
        $scope.logOut = function () {
            loginService.logOut();
            $state.go('login');
        }
        $scope.authentication = authData.authenticationData;
        authenticationService.setHeader();
    }
})(angular.module('tedu'));