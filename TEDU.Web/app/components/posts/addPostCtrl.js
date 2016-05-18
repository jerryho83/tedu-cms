(function (app) {
    'use strict';

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
        $scope.CreateAlias = createAlias;
        $scope.ChooseImage = chooseImage;
        $scope.categories = [];

        function loadListParents() {
            apiService.get('/api/category/getlistparent', null, function (result) {
                $scope.categories = commonService.getTree(result.data, 'ID', 'ParentID');
            });
        }
        this.collection1 = [
                {
                    id: 1,
                    name: 'item1',
                    children: [
                        {
                            id: 2,
                            name: 'item1_1'
                        },
                        {
                            id: 3,
                            name: 'item2_2'
                        }
                    ]
                },
                {
                    id: 4,
                    name: 'item2',
                    children: [
                        {
                            id: 5,
                            name: 'item2_1'
                        },
                        {
                            id: 6,
                            name: 'item2_2',
                            children: [
                                {
                                    id: 7,
                                    name: 'item2_2_1'
                                },
                                {
                                    id: 8,
                                    name: 'item2_2_2',
                                    children: [
                                        {
                                            id: 9,
                                            name: 'item2_2_2_1',
                                            children: [
                                                {
                                                    id: 10,
                                                    name: 'item2_2_2_1_1'
                                                },
                                                {
                                                    id: 11,
                                                    name: 'item2_2_2_1_2',
                                                    children: [

                                                    ]
                                                }
                                            ]
                                        }

                                    ]
                                }
                            ]
                        }
                    ]
                }
        ];

        this.isDisabled = false;

        this.collection = this.collection1;

        this.changeItem = function (value) {
            that.selectedItem = value;
        }

        this.activeItem = {
            id: 8
        }
        $scope.AddPost = addPost;

        function createAlias() {
            $scope.post.Alias = commonService.makeSeoTitle($scope.post.Name);
        }
        function chooseImage() {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.post.Image = fileUrl;
            };
            finder.popup();
        }
        function addPost() {
            apiService.post('/api/post/add', $scope.post, addSuccessed, addFailed);
        }

        function addSuccessed() {
            notificationService.displaySuccess($scope.post.Name + ' đã được thêm mới.');

            $location.url('posts');
        }
        function addFailed() {
            notificationService.displayError(response.statusText);
        }

        loadListParents();
    }
})(angular.module('TEDU'));