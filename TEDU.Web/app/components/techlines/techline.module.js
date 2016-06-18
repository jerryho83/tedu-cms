(function () {
    'use strict';
    angular.module('TEDU.techlines', ['common.core', 'common.ui'])
        .config(configRoute);
    function configRoute($stateProvider) {
        $stateProvider
            //app_group
            .state('techlines', {
                url: '/techlines',
                parent: 'base',
                templateUrl: "/app/components/techlines/techLines.html",
                controller: "techLineCtrl"
            })
            .state('edit_tech_line', {
                url: '/edit_tech_line/:id',
                parent: 'base',
                templateUrl: "/app/components/techlines/editTechLine.html",
                controller: "editTechLineCtrl"
            })
            .state('add_tech_line', {
                url: '/add_tech_line',
                parent: 'base',
                templateUrl: "/app/components/techlines/addTechLine.html",
                controller: "addTechLineCtrl"
            });
    }

})();