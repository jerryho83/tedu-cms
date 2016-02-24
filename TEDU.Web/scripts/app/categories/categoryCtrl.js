(function (app) {
    'use strict'

    app.controller('categoryCtrl', categoryCtrl);
    categoryCtrl.$inject = ['$scope', 'apiService', 'notificationService'];
    function categoryCtrl($scope, apiService, notificationService) {
        $scope.loading = true;
        $scope.listCategories = [];
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

            apiService.get('/admin/api/category/GetListCategories')
        }
    }

}
)(angular.module('TEDU'));