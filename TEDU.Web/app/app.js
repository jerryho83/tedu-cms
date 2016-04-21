(function () {
    'use strict'
    angular.module('TEDU', ['common.core', 'common.ui'])
    .config(config)
    .run(run);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

        $urlRouterProvider.otherwise("/admin");

        $stateProvider
            .state('home', {
                url: "/admin",
                templateUrl: "/app/home/index.html",
                controller: "homeCtrl"
            })
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
            })
             .state('posts', {
                 url: '/posts',
                 templateUrl: "/app/posts/listPosts.html",
                 controller: "postCtrl"
             })
             .state('edit_post', {
                 url: '/edit_post/:id',
                 templateUrl: "/app/posts/editPost.html",
                 controller: "editPostCtrl"
             })
            .state('add_post', {
                url: '/add_post',
                templateUrl: "/app/posts/addPost.html",
                controller: "addPostCtrl"
            });
    }

    function run() {
        $(document).ready(function () {
            $('[data-toggle=offcanvas]').click(function () {
                $('.row-offcanvas').toggleClass('active');
            });
        });
    }
})();