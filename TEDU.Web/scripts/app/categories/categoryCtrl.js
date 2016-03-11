(function (app) {
    'use strict'

    app.controller('categoryCtrl', categoryCtrl);

    categoryCtrl.$inject = ['$scope', 'apiService', 'notificationService', 'modalService'];

    function categoryCtrl($scope, apiService, notificationService, modalService) {
        $scope.loading = true;
        $scope.data = [];
        $scope.page = 0;
        $scope.pageCount = 0;

        $scope.search = search;
        $scope.clearSearch = clearSearch;

        $scope.deleteItem = deleteItem;

        function deleteItem(id) {
            modalService.showConfirm('Bạn có chắc muốn xóa?', deleteSubmit);
        }
        function deleteSubmit(id) {
            var config = {
                params: {
                    id: id
                }
            }
            apiService.post('/admin/api/category/Delete', config, function () {
                notificationService.displaySuccess('Đã xóa thành công.');
                search();
            },
            function () {
                notificationService.displayError('Xóa không thành công.');
            });
        }
        function search(page) {
            page = page || 0;

            $scope.loading = true;
            var config = {
                params: {
                    page: page,
                    pageSize: 10,
                    filter: $scope.filterExpression
                }
            }

            apiService.get('/admin/api/category/Get/1', config, dataLoadCompleted, dataLoadFailed);

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