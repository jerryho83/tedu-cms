(function (app) {
    'use strict';

    app.controller('editTrainerCtrl', editTrainerCtrl);

    editTrainerCtrl.$inject = ['$scope', 'apiService', '$stateParams', 'notificationService', '$location', 'commonService'];

    function editTrainerCtrl($scope, apiService, $stateParams, notificationService, $location, commonService) {
        $scope.category = {};
        $scope.CreateAlias = createAlias;
        $scope.categories = [];

        function loadDetail() {
            apiService.get('/api/trainer/GetDetails/' + $stateParams.id, null,
            function (result) {
                $scope.category = result.data;
            },
            function (result) {
                notificationService.displayError(result.data);
            });
        }

        $scope.UpdateCategory = updateCategory;

        function createAlias() {
            $scope.category.Alias = commonService.makeSeoTitle($scope.category.Name);
        }
        function updateCategory() {
            apiService.put('/api/trainer/update', $scope.category, addSuccessed, addFailed);
        }

        function addSuccessed() {
            notificationService.displaySuccess($scope.category.Name + ' đã được cập nhật.');

            $location.url('trainers');
        }
        function addFailed(response) {
            notificationService.displayError(response.statusText);
             notificationService.displayErrorValidation(response);
        }

        loadDetail();
    }
})(angular.module('TEDU'));