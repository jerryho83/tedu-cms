(function (app) {
    'use strict';

    app.controller('loginCtrl', loginCtrl);

    loginCtrl.$inject = ['$scope', 'membershipService', 'notificationService', '$rootScope', '$location'];

    function loginCtrl($scope, membershipService, notificationService, $rootScope, $location) {
        $scope.pageClass = 'page-login';
        $scope.login = login;
        $scope.user = {};
        $scope.message = "toanbn";
        function login() {
            membershipService.login($scope.user, loginCompleted);
        }

        function loginCompleted(result) {
            if (result.data.success) {
                membershipService.saveCredentials($scope.user);
                notificationService.displaySuccess('Hello ' + $scope.user.UserName);
                //$scope.userData.displayUserInfo();
                if ($rootScope.previousState)
                    window.location.href = $rootScope.previousState;
                else
                    window.location.href = "/admin";
            }
            else {
                notificationService.displayError('Đăng nhập không thành công. Vui lòng thử lại.');
            }
        }
    }

})(angular.module('TEDU'));