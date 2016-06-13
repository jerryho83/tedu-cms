(function (app) {
    'use strict';

    app.controller('addAppRoleCtrl', addAppRoleCtrl);

    addAppRoleCtrl.$inject = ['$scope', 'apiService', 'notificationService', '$location', 'commonService'];

    function addAppRoleCtrl($scope, apiService, notificationService, $location, commonService) {
        $scope.role = {
            Id:0
        }

        $scope.addAppRole = addAppRole;

        function addAppRole() {
            apiService.post('/api/appRole/add', $scope.role, addSuccessed, addFailed);
        }

        function addSuccessed() {
            notificationService.displaySuccess($scope.role.Name + ' đã được thêm mới.');

            $location.url('app_roles');
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
})(angular.module('TEDU.app_roles'));