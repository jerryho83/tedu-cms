(function () {
    'use strict';
    angular.module('TEDU.categories', ['common.core', 'common.ui'])
        .config(configRoute);
    function configRoute($stateProvider) {
        $stateProvider
            //category
            .state('categories', {
                url: '/categories',
                parent: 'base',
                templateUrl: "/app/components/categories/listCategories.html",
                controller: "categoryCtrl"
            })
            .state('edit_category', {
                url: '/edit_category/:id',
                parent: 'base',
                templateUrl: "/app/components/categories/editCategory.html",
                controller: "editCategoryCtrl"
            })
            .state('add_category', {
                url: '/add_category',
                parent: 'base',
                templateUrl: "/app/components/categories/addCategory.html",
                controller: "addCategoryCtrl"
            });
    }

})();