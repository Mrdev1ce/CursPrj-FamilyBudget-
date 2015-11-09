(function () {
    'use strict';

    angular.module('App').service('Wallets', wallets);

    wallets.$inject = ['$http'];

    function wallets($http) {
        this.getUserWallets = getUserWallets;

        function getUserWallets() {
            return $http.get('/service/getuserwallets');
        }
    }
})();