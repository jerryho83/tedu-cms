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
        function loadRoles() {
            apiService.get('/api/appRole/getlistall',
                null,
                function (response) {
                    $scope.roles = response.data;
                }, function (response) {
                    notificationService.displayError('Không tải được danh sách quyền.');
                });

        }

        loadRoles();
    }
})(angular.module('TEDU'));