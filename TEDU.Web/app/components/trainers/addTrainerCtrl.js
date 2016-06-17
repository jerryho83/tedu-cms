(function (app) {
    'use strict';

    app.controller('addTrainerCtrl', addTrainerCtrl);

    addTrainerCtrl.$inject = ['$scope', 'apiService', '$stateParams', 'notificationService', '$location', 'commonService'];

    function addTrainerCtrl($scope, apiService, $stateParams, notificationService, $location, commonService) {
        $scope.trainer = {};
        $scope.chooseImage = chooseImage;

        function chooseImage() {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.trainer.Image = fileUrl;
                });

            };
            finder.popup();
        }

        $scope.addTrainer = addTrainer;

        function addTrainer() {
            apiService.post('/api/trainer/add', $scope.trainer, addSuccessed, addFailed);
        }

        function addSuccessed() {
            notificationService.displaySuccess($scope.trainer.Name + ' đã được cập nhật.');

            $location.url('trainers');
        }
        function addFailed(response) {
            notificationService.displayError(response.statusText);
            notificationService.displayErrorValidation(response);
        }

    }
})(angular.module('TEDU.trainers'));