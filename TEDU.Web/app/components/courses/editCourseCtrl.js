(function (app) {
    'use strict';

    app.controller('editCourseCtrl', editCourseCtrl);

    editCourseCtrl.$inject = ['$scope', 'apiService', '$stateParams', 'notificationService', '$location', 'commonService'];

    function editCourseCtrl($scope, apiService, $stateParams, notificationService, $location, commonService) {
        $scope.course = {};
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
                $scope.$apply(function () {
                    $scope.course.Image = fileUrl;
                });
            };
            finder.popup();
        }

        function loadListParents() {
            apiService.get('/api/coursecategory/getlistparent', null, function (result) {
                $scope.categories = result.data;
            });
        }
        function loadDetail() {
            apiService.get('/api/course/GetDetails/' + $stateParams.id, null,
            function (result) {
                $scope.course = result.data;
            },
            function (result) {
                notificationService.displayError(result.data);
            });
        }

        $scope.Updatecourse = updatecourse;

        function createAlias() {
            $scope.course.Alias = commonService.makeSeoTitle($scope.course.Name);
        }
        function updatecourse() {
            apiService.put('/api/course/update', $scope.course, addSuccessed, addFailed);
        }

        function addSuccessed() {
            notificationService.displaySuccess($scope.course.Name + ' đã được cập nhật.');

            $location.url('courses');
        }
        function addFailed(response) {
            notificationService.displayError(response.statusText);
            notificationService.displayErrorValidation(response);
        }

        loadListParents();
        loadDetail();
    }
})(angular.module('TEDU.courses'));