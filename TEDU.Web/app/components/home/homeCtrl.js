(function (app) {
    'use strict';
    app.controller('homeCtrl', homeCtrl);
    function homeCtrl(authenticationService) {
        authenticationService.setHeader();
        authenticationService.validateRequest();
    }
}
)(angular.module('TEDU'));