(function (app) {
    'use strict';

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
            apiService.get('/api/category/getlistparent', null, function (result) {
                $scope.categories = result.data;
            });
        }

        $scope.AddCategory = AddCategory;

        function CreateAlias() {
            $scope.category.Alias = commonService.makeSeoTitle($scope.category.Name);
        }
        function AddCategory() {
            apiService.post('/api/category/add', $scope.category, addSuccessed, addFailed);
        }

        function addSuccessed() {
            notificationService.displaySuccess($scope.category.Name + ' đã được thêm mới.');

            $location.url('categories');
        }
        function addFailed(response) {
            notificationService.displayError(response.statusText);
            notificationService.displayErrorValidation(response);
        }

        LoadListParents();
    }
})(angular.module('tedu.categories'));