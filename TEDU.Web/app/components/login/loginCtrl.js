(function () {
    'use strict';
    app.controller('loginCtrl', ['$scope', 'loginService', '$location', function ($scope, loginService, $state) {

        $scope.loginData = {
            userName: "",
            password: ""
        };

        $scope.login = function () {
            loginService.login($scope.loginData.userName, $scope.loginData.password).then(function (response) {
                if (response != null && response.error != undefined) {
                    $scope.message = response.error_description;
                }
                else {
                    $state.go('home');
                }
            });
        }
    }]);
})();