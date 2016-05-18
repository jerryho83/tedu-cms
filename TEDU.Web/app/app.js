(function () {
    'use strict';
    angular.module('TEDU', ['common.core', 'common.ui'])
    .config(config)
    .run(run);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

        $urlRouterProvider.otherwise("login");

        $stateProvider
              .state('base', {
                  url: "",
                  templateUrl: "/app/shared/views/base.html",
                  abstract: true
              })
              .state('login', {
                  url: "/login",
                  templateUrl: "/app/components/login/login.html",
                  controller: "loginCtrl"
              })
            .state('home', {
                url: "/admin",
                parent: 'base',
                templateUrl: "/app/components/home/index.html",
                controller: "homeCtrl"
            })
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
            })
             .state('posts', {
                 url: '/posts',
                 parent: 'base',
                 templateUrl: "/app/components/posts/listPosts.html",
                 controller: "postCtrl"
             })
             .state('edit_post', {
                 url: '/edit_post/:id',
                 parent: 'base',
                 templateUrl: "/app/components/posts/editPost.html",
                 controller: "editPostCtrl"
             })
            .state('add_post', {
                url: '/add_post',
                parent: 'base',
                templateUrl: "/app/components/posts/addPost.html",
                controller: "addPostCtrl"
            })
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
    run.$inject = ['$rootScope', '$location', '$cookieStore', '$http'];
    function run($rootScope, $location, $cookieStore, $http) {
        $rootScope.repository = $cookieStore.get('repository') || {};
        if ($rootScope.repository.loggedUser) {
            $http.defaults.headers.common['Authorization'] = $rootScope.repository.loggedUser.authdata;
        }

        $(document).ready(function () {
            $('[data-toggle=offcanvas]').click(function () {
                $('.row-offcanvas').toggleClass('active');
            });
        });
    }

    isAuthenticated.$inject = ['membershipService', '$rootScope', '$location', '$state'];

    function isAuthenticated(membershipService, $rootScope, $location, $state) {
        if (!membershipService.isUserLoggedIn()) {
            $rootScope.previousState = $location.path();
            $state.go('login');
        }
    }
})();