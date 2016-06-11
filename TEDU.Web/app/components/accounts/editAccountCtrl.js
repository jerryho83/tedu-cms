(function (app) {
    'use strict';

    app.controller('editAccountCtrl', editAccountCtrl);

    editAccountCtrl.$inject = ['$scope', 'apiService', 'notificationService', '$location', '$stateParams'];

    function editAccountCtrl($scope, apiService, notificationService, $location, $stateParams) {
        $scope.account = {}


        $scope.updateAccount = updateAccount;

        function updateAccount() {
            apiService.put('/api/account/update', $scope.account, addSuccessed, addFailed);
        }
        function loadDetail() {
            apiService.get('/api/account/detail/' + $stateParams.id, null,
            function (result) {
                $scope.account = result.data.Result;
            },
            function (result) {
                notificationService.displayError(result.data);
            });
        }

        function addSuccessed() {
            notificationService.displaySuccess($scope.account.Name + ' đã được cập nhật thành công.');

            $location.url('accounts');
        }
        function addFailed(response) {
            notificationService.displayError(response.data.Message);
            notificationService.displayErrorValidation(response);
        }
        loadDetail();
    }
})(angular.module('TEDU'));