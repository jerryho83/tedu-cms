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
            height: '200px'
        };
        $scope.CreateAlias = CreateAlias;
        $scope.ChooseImage = ChooseImage;
        $scope.categories = [];

        function LoadListParents() {
            apiService.get('/api/admin/category/getlistparent', null, function (result) {
                $scope.categories = result.data;
            });
        }



        $scope.AddPost = AddPost;

        function CreateAlias() {
            $scope.post.Alias = commonService.makeSeoTitle($scope.post.Name);
        }
        function ChooseImage() {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.post.Image = fileUrl;
            };
            finder.popup();
        }
        function AddPost() {
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