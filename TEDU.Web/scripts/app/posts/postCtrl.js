(function (app) {
    'use strict'

    app.controller('postCtrl', postCtrl);
    postCtrl.$inject = ['$scope'];
    function postCtrl($scope) {
        $scope.data = 1;
    }

}
)(angular.module('TEDU'));