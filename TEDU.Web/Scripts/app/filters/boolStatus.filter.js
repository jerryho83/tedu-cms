(function () {
    'use strict';

    angular.module('common.ui', []).filter('boolStatus',function(){
        return function (input) {
             return input ? 'Kích hoạt' : 'Khóa';
        }
    });
})();