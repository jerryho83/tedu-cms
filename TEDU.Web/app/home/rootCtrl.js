(function (app) {
    'use strict';

    app.controller('rootCtrl', rootCtrl);

    rootCtrl.$inject = ['$scope', '$location', 'membershipService', '$rootScope'];
    function rootCtrl($scope, $location, membershipService, $rootScope) {

        $scope.userData = {};

        $scope.userData.displayUserInfo = displayUserInfo;
        $scope.logout = logout;


        function displayUserInfo() {
            $scope.userData.isUserLoggedIn = membershipService.isUserLoggedIn();

            if ($scope.userData.isUserLoggedIn) {
                $scope.username = $rootScope.repository.loggedUser.username;
            }
            else {
                window.location.href = '/admin/login';
            }
        }

        function logout() {

            membershipService.removeCredentials();
            window.location.href = '/admin/login';
            $scope.userData.displayUserInfo();


        }

        $scope.userData.displayUserInfo();
    }

})(angular.module('TEDU'));