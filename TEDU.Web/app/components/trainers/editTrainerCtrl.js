(function (app) {
    'use strict';

    app.controller('editTrainerCtrl', editTrainerCtrl);

    editTrainerCtrl.$inject = ['$scope', 'apiService', '$stateParams', 'notificationService', '$location', 'commonService'];

    function editTrainerCtrl($scope, apiService, $stateParams, notificationService, $location, commonService) {
        $scope.trainer = {};
        $scope.chooseImage = chooseImage;

        function chooseImage() {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.post.Image = fileUrl;
                });

            };
            finder.popup();
        }
        function loadDetail() {
            apiService.get('/api/trainer/GetDetails/' + $stateParams.id, null,
            function (result) {
                $scope.trainer = result.data;
            },
            function (result) {
                notificationService.displayError(result.data);
            });
        }

        $scope.updateTrainer = updateTrainer;

        function updateTrainer() {
            apiService.put('/api/trainer/update', $scope.trainer, addSuccessed, addFailed);
        }

        function addSuccessed() {
            notificationService.displaySuccess($scope.trainer.Name + ' đã được cập nhật.');

            $location.url('trainers');
        }
        function addFailed(response) {
            notificationService.displayError(response.statusText);
             notificationService.displayErrorValidation(response);
        }

        loadDetail();
    }
})(angular.module('TEDU.trainers'));