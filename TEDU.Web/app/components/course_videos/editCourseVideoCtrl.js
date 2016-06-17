(function (app) {
    'use strict';

    app.controller('editCourseVideoCtrl', editCourseVideoCtrl);

    editCourseVideoCtrl.$inject = ['$scope', 'apiService', '$stateParams', 'notificationService', '$location', 'commonService'];

    function editCourseVideoCtrl($scope, apiService, $stateParams, notificationService, $location, commonService) {
        $scope.video = {
            Status: 1
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


        $scope.updateVideo = updateVideo;

        function createAlias() {
            $scope.video.Alias = commonService.makeSeoTitle($scope.video.Name);
        }
        function updateVideo() {
            apiService.put('/api/courseVideo/update', $scope.video, addSuccessed, addFailed);
        }
        function loadDetail() {
            apiService.get('/api/courseVideo/GetDetails/' + $stateParams.id, null,
            function (result) {
                $scope.video = result.data;
            },
            function (result) {
                notificationService.displayError(result.data);
            });
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
        loadDetail();
    }
})(angular.module('TEDU.course_videos'));