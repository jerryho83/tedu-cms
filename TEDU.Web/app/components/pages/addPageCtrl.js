(function (app) {
    'use strict';

    app.controller('addPageCtrl', addPageCtrl);

    addPageCtrl.$inject = ['$scope', 'apiService', 'notificationService', '$location', 'commonService'];

    function addPageCtrl($scope, apiService, notificationService, $location, commonService) {
        $scope.page = {
            CreatedDate: new Date(),
            Status: true
        }
        // setup editor options
        $scope.editorOptions = {
            language: 'vi',
            height: '200px'
        };
        $scope.CreateAlias = createAlias;

        $scope.AddPage = addPage;

        function createAlias() {
            $scope.page.Alias = commonService.makeSeoTitle($scope.page.Name);
        }
        function addPage() {
            apiService.post('/api/page/add', $scope.page, addSuccessed, addFailed);
        }

        function addSuccessed() {
            notificationService.displaySuccess($scope.page.Name + ' đã được thêm mới.');

            $location.url('pages');
        }
        function addFailed() {
            notificationService.displayError(response.statusText);
        }
    }
})(angular.module('TEDU'));