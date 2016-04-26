(function (app) {
    'use strict'

    app.controller('editCategoryCtrl', editCategoryCtrl);

    editCategoryCtrl.$inject = ['$scope', 'apiService', '$stateParams', 'notificationService', '$location', 'commonService'];

    function editCategoryCtrl($scope, apiService, $stateParams, notificationService, $location, commonService) {

        $scope.category = {};
        $scope.CreateAlias = createAlias;
        $scope.categories = [];

        function loadListParents() {
            apiService.get('/api/admin/category/getlistparent', null, function (result) {
                $scope.categories = result.data;
            });
        }
        function loadDetail() {
            apiService.get('/api/admin/category/GetDetails/' + $stateParams.id, null,
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
            apiService.put('/api/admin/category/update', $scope.category, addSuccessed, addFailed);
        }

        function addSuccessed() {
            notificationService.displaySuccess($scope.category.Name + ' đã được cập nhật.');

            $location.url('categories');

        }
        function addFailed() {
            notificationService.displayError(response.statusText);

        }

        loadListParents();
        loadDetail();
    }

})(angular.module('TEDU'));