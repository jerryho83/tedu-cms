(function () {
    'use strict';
    angular.module('TEDU.app_groups', ['common.core', 'common.ui'])
        .config(configRoute);
    function configRoute($stateProvider) {
        $stateProvider
            //app_group
            .state('app_groups', {
                url: '/app_groups',
                parent: 'base',
                templateUrl: "/app/components/app_groups/app_groups.html",
                controller: "appGroupCtrl"
            })
            .state('edit_app_group', {
                url: '/edit_app_group/:id',
                parent: 'base',
                templateUrl: "/app/components/app_groups/editAppGroup.html",
                controller: "editAppGroupCtrl"
            })
            .state('add_app_group', {
                url: '/add_app_group',
                parent: 'base',
                templateUrl: "/app/components/app_groups/addAppGroup.html",
                controller: "addAppGroupCtrl"
            });
    }

})();