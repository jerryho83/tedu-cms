(function (app) {
    'use strict'

    app.controller('categoryCtrl', categoryCtrl);
    categoryCtrl.$inject = ['$scope'];
    function categoryCtrl($scope) {
        $scope.data = 1;
    }

}
)(angular.module('TEDU'));