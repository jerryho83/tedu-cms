(function (app) {
    'use strict';

    app.directive('topBar', function() {
        return {
            templateUrl: '/app/layout/topBar.html'
        }
    });
})(angular.module('common.ui'));