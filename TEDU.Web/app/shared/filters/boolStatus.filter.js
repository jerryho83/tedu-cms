(function () {
    'use strict';

    angular.module('tedu.common', []).filter('boolStatus',function(){
        return function (input) {
             return input ? 'Kích hoạt' : 'Khóa';
        }
    });
})();