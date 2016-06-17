(function () {
    'use strict';
    angular.module('TEDU.course_videos', ['common.core', 'common.ui'])
        .config(configRoute);
    function configRoute($stateProvider) {
        $stateProvider
            .state('course_videos', {
                url: '/course_videos',
                parent: 'base',
                templateUrl: "/app/components/course_videos/listCourseVideos.html",
                controller: "courseVideoCtrl"
            })
            .state('edit_course_video', {
                url: '/edit_course_video/:id',
                parent: 'base',
                templateUrl: "/app/components/course_videos/editCourseVideo.html",
                controller: "editCourseVideoCtrl"
            })
            .state('add_course_video', {
                url: '/add_course_video',
                parent: 'base',
                templateUrl: "/app/components/course_videos/addCourseVideo.html",
                controller: "addCourseVideoCtrl"
            });
    }

})();