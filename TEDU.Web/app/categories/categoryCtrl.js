(function (app) {
    'use strict'

    app.controller('categoryCtrl', categoryCtrl);

    categoryCtrl.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', 'commonService'];

    function categoryCtrl($scope, apiService, notificationService, $ngBootbox, commonService) {
        var tree;
        $scope.loading = true;
        $scope.data = [];
        $scope.my_tree = tree = {};
        $scope.col_defs = [
              { field: "Name", displayName:"Tên chuyên mục" },
              { field: "CreatedDate", displayName: "Ngày tạo" }

        ];

        $scope.search = search;

        $scope.clearSearch = clearSearch;

        $scope.deleteItem = deleteItem;

        function deleteItem(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?')
                .then(function () {
                    var config = {
                        params: {
                            id: id
                        }
                    }
                    apiService.del('/api/admin/category', config, function () {
                        notificationService.displaySuccess('Đã xóa thành công.');
                        search();
                    },
                    function () {
                        notificationService.displayError('Xóa không thành công.');
                    });
                });
        }

        function search(page) {
            $scope.loading = true;
            apiService.get('/api/admin/category', null, dataLoadCompleted, dataLoadFailed);

        }

        function dataLoadCompleted(result) {
            var myTreeData = commonService.getTree(result.data, 'ID', 'ParentID');

            $scope.data = myTreeData;
            $scope.loading = false;
            if ($scope.filterExpression && $scope.filterExpression.length) {
                notificationService.displayInfo(result.data.length + ' items found');
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