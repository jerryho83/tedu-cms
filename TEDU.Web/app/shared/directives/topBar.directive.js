(function (app) {
    'use strict';

    app.directive('topBar', function () {
        return {
            templateUrl: '/app/shared/directives/topBar.html'
        }
    });
})(angular.module('tedu.common'));