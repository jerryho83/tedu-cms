(function (app) {
    'use strict'

    app.controller('categoryCtrl', categoryCtrl);

    categoryCtrl.$inject = ['$scope', 'apiService', 'notificationService'];

    function categoryCtrl($scope, apiService, notificationService) {
        $scope.loading = true;
        $scope.data = [];
        $scope.page = 0;
        $scope.pageCount = 0;

        $scope.search = search;
        $scope.clearSearch = clearSearch;

        function search(page) {
            page = page || 0;

            $scope.loading = true;
            var config = {
                param: {
                    page: page,
                    pageSize: 20,
                    filter: $scope.filterExpression
                }
            }

            apiService.get('/admin/api/category/GetListCategories/1', dataLoadCompleted, dataLoadFailed);

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

        $scope.search();
    }

}
)(angular.module('TEDU'));