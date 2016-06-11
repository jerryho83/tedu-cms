(function (app) {
    'use strict';

    app.controller('addAccountCtrl', addAccountCtrl);

    addAccountCtrl.$inject = ['$scope', 'apiService', 'notificationService', '$location', 'commonService'];

    function addAccountCtrl($scope, apiService, notificationService, $location, commonService) {
        $scope.account = {
            AppGroups: []
        }

        $scope.addAccount = addAccount;

        function addAccount() {
            apiService.post('/api/account/add', $scope.account, addSuccessed, addFailed);
        }

        function addSuccessed() {
            notificationService.displaySuccess($scope.account.Name + ' đã được thêm mới.');

            $location.url('accounts');
        }
        function addFailed(response) {
            notificationService.displayError(response.data.Message);
            notificationService.displayErrorValidation(response);
        }

        function loadGroups() {
            apiService.get('/api/appGroup/getlistall',
                null,
                function (response) {
                    $scope.groups = response.data;
                }, function (response) {
                    notificationService.displayError('Không tải được danh sách nhóm.');
                });

        }

        loadGroups();
    }
})(angular.module('TEDU'));