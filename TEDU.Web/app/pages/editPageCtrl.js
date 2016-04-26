(function (app) {
    'use strict';

    app.controller('editPageCtrl', editPageCtrl);

    editPageCtrl.$inject = ['$scope', 'apiService', '$stateParams', 'notificationService', '$location', 'commonService'];

    function editPageCtrl($scope, apiService, $stateParams, notificationService, $location, commonService) {

        $scope.page = {};
        $scope.CreateAlias = createAlias;
          // setup editor options
        $scope.editorOptions = {
            language: 'vi',
            height:'200px'
        };


        function loadDetail() {
            apiService.get('/api/admin/page/GetDetails/' + $stateParams.id, null,
            function (result) {
                $scope.page = result.data;
            },
            function (result) {
                notificationService.displayError(result.data);
            });
        }


        $scope.UpdatePage = updatePage;

        function createAlias() {
            $scope.page.Alias = commonService.makeSeoTitle($scope.page.Name);
        }
        function updatePage() {
            apiService.put('/api/admin/page/update', $scope.page, addSuccessed, addFailed);
        }

        function addSuccessed() {
            notificationService.displaySuccess($scope.page.Name + ' đã được cập nhật.');

            $location.url('pages');

        }
        function addFailed() {
            notificationService.displayError(response.statusText);
            
        }
        loadDetail();
    }

})(angular.module('TEDU'));