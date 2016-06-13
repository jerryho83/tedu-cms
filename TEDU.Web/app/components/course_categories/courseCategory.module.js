(function () {
    'use strict';
    angular.module('TEDU.course_categories', ['common.core', 'common.ui'])
        .config(configRoute);
    function configRoute($stateProvider) {
        $stateProvider
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
            });
    }

})();