(function (app) {
    'use strict';

    app.controller('addAppGroupCtrl', addAppGroupCtrl);

    addAppGroupCtrl.$inject = ['$scope', 'apiService', 'notificationService', '$location', 'commonService'];

    function addAppGroupCtrl($scope, apiService, notificationService, $location, commonService) {
        $scope.group = {
            Id:0
        }

        $scope.addAppGroup = addAppGroup;

        function addAppGroup() {
            apiService.post('/api/appGroup/add', $scope.group, addSuccessed, addFailed);
        }

        function addSuccessed() {
            notificationService.displaySuccess($scope.group.Name + ' đã được thêm mới.');

            $location.url('app_groups');
        }
        function addFailed(response) {
            notificationService.displayError(response.data.Message);
            notificationService.displayErrorValidation(response);
        }
    }
})(angular.module('TEDU'));