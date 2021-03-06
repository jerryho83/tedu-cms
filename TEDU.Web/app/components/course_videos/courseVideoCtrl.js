﻿(function (app) {
    'use strict';

    app.controller('courseVideoCtrl', courseVideoCtrl);

    courseVideoCtrl.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox'];

    function courseVideoCtrl($scope, apiService, notificationService, $ngBootbox) {
        $scope.loading = true;
        $scope.data = [];
        $scope.page = 0;
        $scope.pageCount = 0;
        $scope.searchCourseId = 0   ;
        $scope.search = search;
        $scope.clearSearch = clearSearch;

        $scope.deleteItem = deleteItem;
        $scope.showOnSlide = showOnSlide;
        $scope.showHot = showHot;
        $scope.courses = [];

        function deleteItem(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?')
                .then(function () {
                    var config = {
                        params: {
                            id: id
                        }
                    }
                    apiService.del('/api/courseVideo/delete', config, function () {
                        notificationService.displaySuccess('Đã xóa thành công.');
                        search();
                    },
                    function () {
                        notificationService.displayError('Xóa không thành công.');
                    });
                });
        }
        function search(page) {
            page = page || 0;

            $scope.loading = true;
            var config = {
                params: {
                    courseId: $scope.searchCourseId,
                    page: page,
                    pageSize: 10,
                    filter: $scope.filterExpression
                }
            }

            apiService.get('/api/courseVideo/getlistpaging', config, dataLoadCompleted, dataLoadFailed);
        }
        function showOnSlide(id) {
            notificationService.displayError('Xóa không thành công.' + id);
        }
        function showHot(id) {
            notificationService.displayError('Xóa không thành công.');
        }
        function dataLoadCompleted(result) {
            $scope.data = result.data.Items;
            $scope.page = result.data.Page;
            $scope.pagesCount = result.data.TotalPages;
            $scope.totalCount = result.data.TotalCount;
            $scope.loading = false;

            if ($scope.filterExpression && $scope.filterExpression.length) {
                notificationService.displayInfo(result.data.Items.length + ' items found');
            }
        }
        function dataLoadFailed(response) {
            notificationService.displayError(response.data);
        }

        function clearSearch() {
            $scope.filterExpression = '';
            search();
        }

        function loadCourseSearch() {
            apiService.get('/api/course/getall', null, function (result) {
                $scope.courses = result.data;
            });
        }
        loadCourseSearch();
        $scope.search();
    }
}
)(angular.module('TEDU.course_videos'));