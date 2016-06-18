(function (app) {
    'use strict';

    app.controller('editTechLineCtrl', editTechLineCtrl);

    editTechLineCtrl.$inject = ['$scope', 'apiService', 'notificationService', '$location', '$stateParams'];

    function editTechLineCtrl($scope, apiService, notificationService, $location, $stateParams) {
        $scope.techline = {}


        $scope.updateTechLine = updateTechLine;

        function updateTechLine() {
            apiService.put('/api/techLine/update', $scope.techline, addSuccessed, addFailed);
        }
        function loadDetail() {
            apiService.get('/api/techLine/detail/' + $stateParams.id, null,
            function (result) {
                $scope.techline = result.data;
            },
            function (result) {
                notificationService.displayError(result.data);
            });
        }

        function addSuccessed() {
            notificationService.displaySuccess($scope.techline.Name + ' đã được cập nhật thành công.');

            $location.url('techlines');
        }
        function addFailed(response) {
            notificationService.displayError(response.data.Message);
            notificationService.displayErrorValidation(response);
        }
        loadDetail();
    }
})(angular.module('TEDU.techlines'));