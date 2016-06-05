(function (app) {
    'use strict'

    app.factory('apiService', apiService);

    apiService.$inject = ['$http', '$location', 'notificationService', '$rootScope','authenticationService'];

    function apiService($http, $location, notificationService, $rootScope, authenticationService) {
        var service = {
            get: get,
            post: post,
            del: del,
            put: put
        }
        function get(url, config, success, failure) {
            authenticationService.setHeader();
            return $http.get(url, config)
                    .then(function (result) {
                        success(result);
                    }, function (error) {
                        if (error.status == '401') {
                            notificationService.displayError('Authentication required.');
                            $rootScope.previousState = $location.path();
                            $location.path('login');
                        }
                        else if (failure != null) {
                            failure(error);
                        }
                    });
        }

        function post(url, data, success, failure) {
            authenticationService.setHeader();
            return $http.post(url, data)
                    .then(function (result) {
                        success(result);
                    }, function (error) {
                        if (error.status == '401') {
                            notificationService.displayError('Authentication required.');
                            $rootScope.previousState = $location.path();
                            $location.path('/login');
                        }
                        else if (failure != null) {
                            failure(error);
                        }
                    });
        }

        function put(url, data, success, failure) {
            authenticationService.setHeader();
            return $http.put(url, data)
                    .then(function (result) {
                        success(result);
                    }, function (error) {
                        if (error.status == '401') {
                            notificationService.displayError('Authentication required.');
                            $rootScope.previousState = $location.path();
                            $location.path('/login');
                        }
                        else if (failure != null) {
                            failure(error);
                        }
                    });
        }

        function del(url, data, success, failure) {
            authenticationService.setHeader();
            return $http.delete(url, data)
                    .then(function (result) {
                        success(result);
                    }, function (error) {
                        if (error.status == '401') {
                            notificationService.displayError('Authentication required.');
                            $rootScope.previousState = $location.path();
                            $location.path('/login');
                        }
                        else if (failure != null) {
                            failure(error);
                        }
                    });
        }

        return service;
    }
})(angular.module('common.core'));