(function (app) {
    'use strict'

    app.controller('editPostCtrl', editPostCtrl);

    editPostCtrl.$inject = ['$scope', 'apiService', '$stateParams', 'notificationService', '$location', 'commonService'];

    function editPostCtrl($scope, apiService, $stateParams, notificationService, $location, commonService) {

        $scope.category = {};
        $scope.CreateAlias = CreateAlias;
        $scope.categories = [];

        function LoadListParents() {
            apiService.get('/api/admin/category', null, function (result) {
                $scope.categories = result.data;
            });
        }
        function LoadDetail() {
            apiService.get('/api/admin/category/' + $stateParams.id, null,
            function (result) {
                $scope.category = result.data;
            },
            function (result) {
                notificationService.displayError(result.data);
            });
        }


        $scope.UpdateCategory = UpdateCategory;

        function CreateAlias() {
            $scope.category.Alias = commonService.makeSeoTitle($scope.category.Name);
        }
        function UpdateCategory() {
            apiService.put('/api/admin/category/update', $scope.category, addSuccessed, addFailed);
        }

        function addSuccessed() {
            notificationService.displaySuccess($scope.category.Name + ' đã được cập nhật.');

            $location.url('categories');

        }
        function addFailed() {
            notificationService.displayError(response.statusText);

        }

        LoadListParents();
        LoadDetail();
    }

})(angular.module('TEDU'));