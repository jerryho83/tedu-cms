(function (app) {
    'use strict';
    app.controller('homeCtrl', homeCtrl);
    function homeCtrl(authenticationService) {
        authenticationService.setHeader();
    }
}
)(angular.module('TEDU'));