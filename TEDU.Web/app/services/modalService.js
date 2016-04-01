(function (app) {
    'use strict';

    app.factory('modalService', modalService);

    modalService.$inject = ['$http'];

    function modalService($http) {
        var service = {
            showAlert: showAlert,
            showConfirm: showConfirm,
            showDialog: showDialog

        };

        return service;
        function showAlert(message) {
            bootbox.alert(message);
        }

        function showConfirm(message, callback) {
            bootbox.confirm(message, callback);
        }

        function showDialog(title, message, okCallback, cancelCallback) {
            bootbox.dialog({
                message: message,
                title: title,
                buttons: {
                    success: {
                        label: "OK",
                        className: "btn-success",
                        callback: function () {
                            okCallback();
                        }
                    },
                    danger: {
                        label: "Cancel",
                        className: "btn-danger",
                        callback: function () {
                            cancelCallback();
                        }
                    }
                }
            });
        }

    }
})(angular.module('common.core'));