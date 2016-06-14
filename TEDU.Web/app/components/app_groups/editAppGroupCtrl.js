(function (app) {
    'use strict';

    app.controller('editAppGroupCtrl', editAppGroupCtrl);

    editAppGroupCtrl.$inject = ['$scope', 'apiService', 'notificationService', '$location', '$stateParams'];

    function editAppGroupCtrl($scope, apiService, notificationService, $location,$stateParams) {
        $scope.group = {}


        $scope.updateAppGroup = updateAppGroup;

        function updateAppGroup() {
            apiService.put('/api/appGroup/update', $scope.group, addSuccessed, addFailed);
        }
        function loadDetail() {
            apiService.get('/api/appGroup/detail/' + $stateParams.id, null,
            function (result) {
                $scope.group = result.data;
            },
            function (result) {
                notificationService.displayError(result.data);
            });
        }

        function addSuccessed() {
            notificationService.displaySuccess($scope.group.Name + ' đã được cập nhật thành công.');

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
        loadDetail();
    }
})(angular.module('TEDU.app_groups'));