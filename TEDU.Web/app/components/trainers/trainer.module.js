(function () {
    'use strict';
    angular.module('TEDU.trainers', ['common.core', 'common.ui'])
        .config(configRoute);
    function configRoute($stateProvider) {
        $stateProvider
            //category
            .state('trainers', {
                url: '/trainers',
                parent: 'base',
                templateUrl: "/app/components/trainers/listTrainers.html",
                controller: "trainerCtrl"
            })
            .state('edit_trainer', {
                url: '/edit_trainer/:id',
                parent: 'base',
                templateUrl: "/app/components/trainers/editTrainer.html",
                controller: "editTrainerCtrl"
            })
            .state('add_trainer', {
                url: '/add_trainer',
                parent: 'base',
                templateUrl: "/app/components/trainers/addTrainer.html",
                controller: "addTrainerCtrl"
            });
    }

})();