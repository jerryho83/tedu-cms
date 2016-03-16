(function (app) {
    'use strict'

    app.controller('addCategoryCtrl', addCategoryCtrl);

    addCategoryCtrl.$inject = ['$scope', 'apiService', 'notificationService'];

    function addCategoryCtrl($scope, apiService, notificationService) {

        $scope.item = { CreatedDate: new Date() }
        $scope.categories = [{
            ID: 1,
            Name:"Abc"
        }];
        $scope.AddCategory = AddCategory;

        function AddCategory() {
            apiService.post('/api/admin/category/add', $scope.item, addSuccessed, addFailed);
        }

        function addSuccessed() {
            notificationService.displaySuccess($scope.item.Name + ' đã được thêm mới.');

        }
        function addFailed() {
            notificationService.displayError(response.statusText);

        }
    }

})(angular.module('TEDU'));