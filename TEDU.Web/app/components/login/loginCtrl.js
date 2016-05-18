(function (app) {
    'use strict';

    app.controller('loginCtrl', loginCtrl);

    loginCtrl.$inject = ['$scope', 'membershipService', 'notificationService', '$rootScope', '$state'];

    function loginCtrl($scope, membershipService, notificationService, $rootScope, $state) {
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
                notificationService.displaySuccess('Chào mừng ' + $scope.user.UserName);
                if ($rootScope.previousState)
                    $state.go($rootScope.previousState);
                else
                    $state.go('home');
            }
            else {
                notificationService.displayError('Đăng nhập không thành công. Vui lòng thử lại.');
            }
        }
    }
})(angular.module('TEDU'));