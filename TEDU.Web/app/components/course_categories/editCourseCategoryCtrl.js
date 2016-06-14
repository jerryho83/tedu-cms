(function (app) {
    'use strict';

    app.controller('editCourseCategoryCtrl', editCourseCategoryCtrl);

    editCourseCategoryCtrl.$inject = ['$scope', 'apiService', '$stateParams', 'notificationService', '$location', 'commonService'];

    function editCourseCategoryCtrl($scope, apiService, $stateParams, notificationService, $location, commonService) {
        $scope.category = {};
        $scope.CreateAlias = createAlias;
        $scope.categories = [];

        function loadListParents() {
            apiService.get('/api/coursecategory/getlistparent', null, function (result) {
                $scope.categories = result.data;
            });
        }
        function loadDetail() {
            apiService.get('/api/coursecategory/GetDetails/' + $stateParams.id, null,
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
            apiService.put('/api/coursecategory/update', $scope.category, addSuccessed, addFailed);
        }

        function addSuccessed() {
            notificationService.displaySuccess($scope.category.Name + ' đã được cập nhật.');

            $location.url('course_categories');
        }
        function addFailed(response) {
            notificationService.displayError(response.statusText);
             notificationService.displayErrorValidation(response);
        }

        loadListParents();
        loadDetail();
    }
})(angular.module('TEDU.course_categories'));