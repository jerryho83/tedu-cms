(function () {
    'use strict';
    angular.module('TEDU.accounts', ['common.core', 'common.ui'])
        .config(configRoute);
    function configRoute($stateProvider) {
        $stateProvider
         //account
        .state('accounts', {
            url: '/accounts',
            parent: 'base',
            templateUrl: "/app/components/accounts/accounts.html",
            controller: "accountCtrl"
        })
        .state('edit_account', {
            url: '/edit_account/:id',
            parent: 'base',
            templateUrl: "/app/components/accounts/editAccount.html",
            controller: "editAccountCtrl"
        })
        .state('add_account', {
            url: '/add_account',
            parent: 'base',
            templateUrl: "/app/components/accounts/addAccount.html",
            controller: "addAccountCtrl"
        });
    }

})();