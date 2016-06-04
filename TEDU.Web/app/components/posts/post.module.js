/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('tedu.posts', ['tedu.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
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
    }
})();