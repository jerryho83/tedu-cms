(function () {
    'use strict';
    angular.module('TEDU.course_users', ['common.core', 'common.ui'])
        .config(configRoute);
    function configRoute($stateProvider) {
        $stateProvider
         //account
        .state('course_users', {
            url: '/course_users',
            parent: 'base',
            templateUrl: "/app/components/course_users/courseUsers.html",
            controller: "courseUserCtrl"
        });
    }

})();