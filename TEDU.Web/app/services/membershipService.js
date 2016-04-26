(function(app) {
    'use strict';
    app.factory('membershipService', membershipService);

    membershipService.$inject = ['apiService', 'notificationService', '$http', '$base64', '$cookieStore', '$rootScope'];

    function membershipService(apiService, notificationService, $http, $base64, $cookieStore, $rootScope) {
        var service = {
            login: login,
            saveCredentials: saveCredentials,
            removeCredentials: removeCredentials,
            isUserLoggedIn: isUserLoggedIn
        }

        function login(user, completed) {
            apiService.post('/api/admin/account/Login', user,
            completed,
            loginFailed);
        }


        function saveCredentials(user) {
            var membershipData = $base64.encode(user.UserName + ':' + user.Password);

            $rootScope.repository = {
                loggedUser: {
                    username: user.UserName,
                    authdata: membershipData
                }
            };

            $http.defaults.headers.common['Authorization'] = 'Basic ' + membershipData;
            $cookieStore.put('repository', $rootScope.repository);
        }

        function removeCredentials() {
            $rootScope.repository = {};
            $cookieStore.remove('repository');
            $http.defaults.headers.common.Authorization = '';
        };

        function loginFailed(response) {
            notificationService.displayError(response.data);
        }


        function isUserLoggedIn() {
            return $rootScope.repository.loggedUser != null;
        }

        return service;
    }

})(angular.module('common.core'));