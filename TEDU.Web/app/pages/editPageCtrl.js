(function (app) {
    'use strict';

    app.controller('editPageCtrl', editPageCtrl);

    editPageCtrl.$inject = ['$scope', 'apiService', '$stateParams', 'notificationService', '$location', 'commonService'];

    function editPageCtrl($scope, apiService, $stateParams, notificationService, $location, commonService) {

        $scope.page = {};
        $scope.CreateAlias = CreateAlias;
          // setup editor options
        $scope.editorOptions = {
            language: 'vi',
            height:'200px'
        };


        function LoadDetail() {
            apiService.get('/api/admin/page/GetDetails/' + $stateParams.id, null,
            function (result) {
                $scope.page = result.data;
            },
            function (result) {
                notificationService.displayError(result.data);
            });
        }


        $scope.UpdatePage = UpdatePage;

        function CreateAlias() {
            $scope.post.Alias = commonService.makeSeoTitle($scope.page.Name);
        }
        function UpdatePage() {
            apiService.put('/api/admin/page/update', $scope.page, addSuccessed, addFailed);
        }

        function addSuccessed() {
            notificationService.displaySuccess($scope.page.Name + ' đã được cập nhật.');

            $location.url('pages');

        }
        function addFailed() {
            notificationService.displayError(response.statusText);

        }
        LoadDetail();
    }

})(angular.module('TEDU'));