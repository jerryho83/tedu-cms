(function (app) {
    'use strict';

    app.controller('homeCtrl', homeCtrl);
    homeCtrl.$inject = ['$scope'];
    function homeCtrl($scope) {
        $scope.data = 1;
    }
}
)(angular.module('TEDU'));