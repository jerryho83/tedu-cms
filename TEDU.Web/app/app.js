(function () {
    'use strict';
    angular.module('TEDU', ['common.core', 'common.ui'])
    .config(configRoute)
    .config(configSecurity)
    .run(run);
    function configRoute($stateProvider, $urlRouterProvider, $httpProvider) {
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
             })
           //category
             .state('course_categories', {
                 url: '/course_categories',
                 parent: 'base',
                 templateUrl: "/app/components/course_categories/listCourseCategories.html",
                 controller: "courseCategoryCtrl"
             })
             .state('edit_course_category', {
                 url: '/edit_course_category/:id',
                 parent: 'base',
                 templateUrl: "/app/components/course_categories/editCourseCategory.html",
                 controller: "editCourseCategoryCtrl"
             })
             .state('add_course_category', {
                 url: '/add_course_category',
                 parent: 'base',
                 templateUrl: "/app/components/course_categories/addCourseCategory.html",
                 controller: "addCourseCategoryCtrl"
             })
            //course
            .state('courses', {
                url: '/courses',
                parent: 'base',
                templateUrl: "/app/components/courses/listCourses.html",
                controller: "courseCtrl"
            })
            .state('edit_course', {
                url: '/edit_course/:id',
                parent: 'base',
                templateUrl: "/app/components/courses/editCourse.html",
                controller: "editCourseCategoryCtrl"
            })
            .state('add_course', {
                url: '/add_course',
                parent: 'base',
                templateUrl: "/app/components/courses/addCourse.html",
                controller: "addCourseCtrl"
            })
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
        })
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

    function configSecurity($httpProvider) {
        $httpProvider.interceptors.push(function ($q, $location) {
            return {
                request: function (config) {

                    return config;
                },
                requestError: function (rejection) {

                    return $q.reject(rejection);
                },
                response: function (response) {
                    if (response.status == "401") {
                        $location.path('/login');
                    }
                    //the same response/modified/or a new one need to be returned.
                    return response;
                },
                responseError: function (rejection) {

                    if (rejection.status == "401") {
                        $location.path('/login');
                    }
                    return $q.reject(rejection);
                }
            };
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