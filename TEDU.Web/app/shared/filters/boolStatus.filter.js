(function (app) {
    'use strict';

    app.filter('boolStatus',function(){
        return function (input) {
             return input ? 'Kích hoạt' : 'Khóa';
        }
    });
})(angular.module('common.ui'));