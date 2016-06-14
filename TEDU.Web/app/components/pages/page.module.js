  (function () {
    'use strict';
    angular.module('TEDU.pages', ['common.core', 'common.ui'])
        .config(configRoute);
    function configRoute($stateProvider) {
        $stateProvider
            .state('pages', {
                url: '/pages',
                parent: 'base',
                templateUrl: "/app/components/pages/listPages.html",
                controller: "pageCtrl"
            })
            .state('edit_page', {
                url: '/edit_page/:id',
                parent: 'base',
                templateUrl: "/app/components/pages/editPage.html",
                controller: "editPageCtrl"
            })
            .state('add_page', {
                url: '/add_page',
                parent: 'base',
                templateUrl: "/app/components/pages/addPage.html",
                controller: "addPageCtrl"
            });
    }

})();