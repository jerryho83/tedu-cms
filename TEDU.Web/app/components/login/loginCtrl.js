(function (app) {
    'use strict';
    app.controller('loginCtrl', function ($scope, loginService, $injector,notificationService) {

        $scope.loginData = {
            userName: "",
            password: ""
        };

        $scope.login = function () {
            loginService.login($scope.loginData.userName, $scope.loginData.password).then(function (response) {
                if (response != null && response.error != undefined) {
                    notificationService.displayError(response.error);
                }
                else {
                    var stateService = $injector.get('$state');
                    stateService.go('home');
                }
            });
        }
    });
})(angular.module('TEDU'));