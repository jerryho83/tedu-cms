(function (app) {
    'use strict';

    app.controller('addCourseCtrl', addCourseCtrl);

    addCourseCtrl.$inject = ['$scope', 'apiService', 'notificationService', '$location', 'commonService'];

    function addCourseCtrl($scope, apiService, notificationService, $location, commonService) {
        $scope.course = {
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
            apiService.get('/api/coursecategory/getlistparent', null, function (result) {
                $scope.categories = commonService.getTree(result.data, 'ID', 'ParentID');
            });
        }

        $scope.Addcourse = addcourse;

        function createAlias() {
            $scope.course.Alias = commonService.makeSeoTitle($scope.course.Name);
        }
        function chooseImage() {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function() {
                    $scope.course.Image = fileUrl;
                });

            };
            finder.popup();
        }
        function addcourse() {
            apiService.course('/api/course/add', $scope.course, addSuccessed, addFailed);
        }

        function addSuccessed(response) {
            notificationService.displaySuccess($scope.course.Name + ' đã được thêm mới.');
            $location.url('courses');
        }
        function addFailed(response) {
            notificationService.displayError(response.statusText);
        }

        loadListParents();
    }
})(angular.module('TEDU'));