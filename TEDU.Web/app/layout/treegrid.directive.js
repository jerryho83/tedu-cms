(function() {
    'use strict';

    angular
        .module('common.ui')
        .directive('treeGrid', treeGrid);
    function treeGrid () {
        // Usage:
        //     <treeGrid></treeGrid>
        // Creates:
        // 
        var directive = {
            link: link,
            restrict: 'E'
        };
        return directive;

        function link(scope, element, attrs) {
            angular.element(document).ready(function () {
                $(element).treegrid();
            });
        }
    }

})();