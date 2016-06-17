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
        $scope.levels = [
            { ID: 1, Name: "Level 1" },
            { ID: 2, Name: "Level 2" },
            { ID: 3, Name: "Level 3" },
        ];
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
        function loadLisTrainer() {
            apiService.get('/api/trainer/getlistparent', null, function (result) {
                $scope.trainers = result.data;
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

        $scope.updateCourse = updateCourse;

        function createAlias() {
            $scope.course.Alias = commonService.makeSeoTitle($scope.course.Name);
        }
        function updateCourse() {
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
        loadLisTrainer();
        loadDetail();
    }
})(angular.module('TEDU.courses'));