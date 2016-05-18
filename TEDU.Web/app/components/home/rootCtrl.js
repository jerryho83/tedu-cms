(function (app) {
    'use strict';

    app.controller('rootCtrl', rootCtrl);

    rootCtrl.$inject = ['$scope', '$location', 'membershipService', '$rootScope','$state'];
    function rootCtrl($scope, $location, membershipService, $rootScope,$state) {

        $scope.userData = {};

        $scope.userData.displayUserInfo = displayUserInfo;
        $scope.logout = logout;


        function displayUserInfo() {
            $scope.userData.isUserLoggedIn = membershipService.isUserLoggedIn();

            if ($scope.userData.isUserLoggedIn) {
                $scope.username = $rootScope.repository.loggedUser.username;
            }
            else {
                $state.go('login');
            }
        }

        function logout() {

            membershipService.removeCredentials();
            $state.go('login');
            $scope.userData.displayUserInfo();


        }

        $scope.userData.displayUserInfo();
    }

})(angular.module('TEDU'));