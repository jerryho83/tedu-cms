(function (app) {
    'use strict'

    app.controller('addPostCtrl', addPostCtrl);

    addPostCtrl.$inject = ['$scope', 'apiService', 'notificationService', '$location', 'commonService'];

    function addPostCtrl($scope, apiService, notificationService, $location, commonService) {

        $scope.post = {
            CreatedDate: new Date(),
            Status: "Published"
        }
        // setup editor options
        $scope.editorOptions = {
            language: 'vi',
            uiColor: '#000000'
        };
        $scope.CreateAlias = CreateAlias;

        $scope.categories = [];

        function LoadListParents() {
            apiService.get('/api/admin/category', null, function (result) {
                $scope.categories = result.data;
            });
        }



        $scope.AddCategory = AddCategory;

        function CreateAlias() {
            $scope.category.Alias = commonService.makeSeoTitle($scope.post.Name);
        }
        function AddCategory() {
            apiService.post('/api/admin/post/add', $scope.post, addSuccessed, addFailed);
        }

        function addSuccessed() {
            notificationService.displaySuccess($scope.post.Name + ' đã được thêm mới.');

            $location.url('posts');

        }
        function addFailed() {
            notificationService.displayError(response.statusText);

        }

        LoadListParents();
    }

})(angular.module('TEDU'));