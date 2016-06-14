(function () {
    'use strict';
    angular.module('TEDU.app_roles', ['common.core', 'common.ui'])
        .config(configRoute);
    function configRoute($stateProvider) {
        $stateProvider
            //app_role
            .state('app_roles', {
                url: '/app_roles',
                parent: 'base',
                templateUrl: "/app/components/app_roles/app_roles.html",
                controller: "appRoleCtrl"
            })
            .state('edit_app_role', {
                url: '/edit_app_role/:id',
                parent: 'base',
                templateUrl: "/app/components/app_roles/editAppRole.html",
                controller: "editAppRoleCtrl"
            })
            .state('add_app_role', {
                url: '/add_app_role',
                parent: 'base',
                templateUrl: "/app/components/app_roles/addAppRole.html",
                controller: "addAppRoleCtrl"
            });
    }

})();