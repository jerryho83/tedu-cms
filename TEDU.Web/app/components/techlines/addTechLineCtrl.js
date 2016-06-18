(function (app) {
    'use strict';

    app.controller('addTechLineCtrl', addTechLineCtrl);

    addTechLineCtrl.$inject = ['$scope', 'apiService', 'notificationService', '$location', 'commonService'];

    function addTechLineCtrl($scope, apiService, notificationService, $location, commonService) {
        $scope.techline = {
            ID:0
        }

        $scope.addTechLine = addTechLine;

        function addTechLine() {
            apiService.post('/api/techLine/add', $scope.techline, addSuccessed, addFailed);
        }

        function addSuccessed() {
            notificationService.displaySuccess($scope.techline.Name + ' đã được thêm mới.');

            $location.url('techlines');
        }
        function addFailed(response) {
            notificationService.displayError(response.data.Message);
            notificationService.displayErrorValidation(response);
        }
    }
})(angular.module('TEDU.techlines'));