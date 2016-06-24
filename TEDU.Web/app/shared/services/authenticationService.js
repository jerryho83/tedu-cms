(function (app) {
    'use strict';
    app.service('authenticationService', ['$http', 'localStorageService', 'authData', '$q', '$window',
        function ($http, localStorageService, authData, $q, $window) {
            var tokenInfo;

            this.setTokenInfo = function (data) {
                tokenInfo = data;
                localStorageService.set("TokenInfo", JSON.stringify(tokenInfo));
            }

            this.getTokenInfo = function () {
                return tokenInfo;
            }

            this.removeToken = function () {
                tokenInfo = null;
                localStorageService.set("TokenInfo", null);
            }

            this.init = function () {
                if (localStorageService.get("TokenInfo")) {
                    tokenInfo = JSON.parse(localStorageService.get("TokenInfo"));
                    authData.authenticationData.IsAuthenticated = true;
                    authData.authenticationData.userName = tokenInfo.userName;
                }
            }

            this.setHeader = function () {
                delete $http.defaults.headers.common['X-Requested-With'];
                if ((tokenInfo != undefined) && (tokenInfo.accessToken != undefined) && (tokenInfo.accessToken != null) && (tokenInfo.accessToken != "")) {
                    $http.defaults.headers.common['Authorization'] = 'Bearer ' + tokenInfo.accessToken;
                    $http.defaults.headers.common['Content-Type'] = 'application/x-www-form-urlencoded;charset=utf-8';
                }
            }

            this.init();
        }
    ]);
})(angular.module('common.core'));