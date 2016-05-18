(function (app) {
    'use strict'

    app.controller('addCategoryCtrl', addCategoryCtrl);

    addCategoryCtrl.$inject = ['$scope', 'apiService', 'notificationService', '$location', 'commonService'];

    function addCategoryCtrl($scope, apiService, notificationService, $location, commonService) {
        $scope.category = {
            CreatedDate: new Date(),
            Status: true,
            ShowHome: false
        }
        $scope.CreateAlias = CreateAlias;

        $scope.categories = [];

        function LoadListParents() {
            apiService.get('/api/admin/category/getlistparent', null, function (result) {
                $scope.categories = result.data;
            });
        }

        $scope.AddCategory = AddCategory;

        function CreateAlias() {
            $scope.category.Alias = commonService.makeSeoTitle($scope.category.Name);
        }
        function AddCategory() {
            apiService.post('/api/admin/category/add', $scope.category, addSuccessed, addFailed);
        }

        function addSuccessed() {
            notificationService.displaySuccess($scope.category.Name + ' đã được thêm mới.');

            $location.url('categories');
        }
        function addFailed() {
            notificationService.displayError(response.statusText);
        }

        LoadListParents();
    }
})(angular.module('TEDU'));