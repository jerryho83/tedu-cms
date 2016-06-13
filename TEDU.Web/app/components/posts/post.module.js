(function () {
    'use strict';
    angular.module('TEDU.posts', ['common.core', 'common.ui'])
        .config(configRoute);
    function configRoute($stateProvider) {
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
            });
    }

})();