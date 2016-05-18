(function() {
    angular.module('tedu.categories', []).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider) {
        $stateProvider
            //category
            .state('categories', {
                url: '/categories',
                templateUrl: "/app/categories/listCategories.html",
                controller: "categoryCtrl"
            })
            .state('edit_category', {
                url: '/edit_category/:id',
                templateUrl: "/app/categories/editCategory.html",
                controller: "editCategoryCtrl"
            })
            .state('add_category', {
                url: '/add_category',
                templateUrl: "/app/categories/addCategory.html",
                controller: "addCategoryCtrl"
            });
    }
});