(function (app) {
    'use strict';

    app.controller('addCourseVideoCtrl', addCourseVideoCtrl);

    addCourseVideoCtrl.$inject = ['$scope', 'apiService', '$stateParams', 'notificationService', '$location', 'commonService'];

    function addCourseVideoCtrl($scope, apiService, $stateParams, notificationService, $location, commonService) {
        $scope.video = {
            Status: 1,
            CourseId: parseInt($stateParams.courseId)
        };
        $scope.createAlias = createAlias;
        $scope.chooseImage = chooseImage;
        $scope.courses = [];
        // setup editor options
        $scope.editorOptions = {
            language: 'vi',
            height: '200px',
            extraPlugins: 'codesnippet',
            codeSnippet_theme: 'monokai_sublime'
        };

        $scope.chooseSource = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.video.SourceCodePath = fileUrl;
                });
            };
            finder.popup();
        }

        $scope.chooseSlide = function chooseSlide() {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.video.SlidePath = fileUrl;
                });
            };
            finder.popup();
        }
        function chooseImage() {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.video.Image = fileUrl;
                });
            };
            finder.popup();
        }

        function loadListParents() {
            apiService.get('/api/course/getall', null, function (result) {
                $scope.courses = result.data;
            });
        }


        $scope.addVideo = addVideo;

        function createAlias() {
            $scope.video.Alias = commonService.makeSeoTitle($scope.video.Name);
        }
        function addVideo() {
            apiService.post('/api/courseVideo/add', $scope.video, addSuccessed, addFailed);
        }

        function addSuccessed() {
            notificationService.displaySuccess($scope.video.Name + ' đã được cập nhật.');

            $location.url('course_videos');
        }
        function addFailed(response) {
            notificationService.displayError(response.statusText);
            notificationService.displayErrorValidation(response);
        }

        loadListParents();
    }
})(angular.module('TEDU.course_videos'));