(function (app) {
    'use strict';
    app.directive('treegrid', treegrid);

    function treegrid() {
        var directive = {
            link: link,
            restrict: 'A'
        };
        return directive;

        function link(scope, element, attrs) {
           $(element).treegrid();
        }
    }

})(angular.module('common.ui'));