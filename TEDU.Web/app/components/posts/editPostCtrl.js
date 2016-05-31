(function (app) {
    'use strict';

    app.controller('editPostCtrl', editPostCtrl);

    editPostCtrl.$inject = ['$scope', 'apiService', '$stateParams', 'notificationService', '$location', 'commonService'];

    function editPostCtrl($scope, apiService, $stateParams, notificationService, $location, commonService) {
        $scope.post = {};
        $scope.CreateAlias = createAlias;
        $scope.ChooseImage = chooseImage;
        $scope.categories = [];
        // setup editor options
        $scope.editorOptions = {
            language: 'vi',
            height: '200px'
        };

        function chooseImage() {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.post.Image = fileUrl;
            };
            finder.popup();
        }

        function loadListParents() {
            apiService.get('/api/category/getlistparent', null, function (result) {
                $scope.categories = result.data;
            });
        }
        function loadDetail() {
            apiService.get('/api/post/GetDetails/' + $stateParams.id, null,
            function (result) {
                $scope.post = result.data;
            },
            function (result) {
                notificationService.displayError(result.data);
            });
        }

        $scope.UpdatePost = updatePost;

        function createAlias() {
            $scope.post.Alias = commonService.makeSeoTitle($scope.post.Name);
        }
        function updatePost() {
            apiService.put('/api/post/update', $scope.post, addSuccessed, addFailed);
        }

        function addSuccessed() {
            notificationService.displaySuccess($scope.post.Name + ' đã được cập nhật.');

            $location.url('posts');
        }
        function addFailed(response) {
            notificationService.displayError(response.statusText);
            notificationService.displayErrorValidation(response);
        }
        
        loadListParents();
        loadDetail();
    }
})(angular.module('TEDU'));