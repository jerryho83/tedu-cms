(function () {
    'use strict';
    angular.module('TEDU.courses', ['common.core', 'common.ui'])
        .config(configRoute);
    function configRoute($stateProvider) {
        $stateProvider
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
            });
    }

})();