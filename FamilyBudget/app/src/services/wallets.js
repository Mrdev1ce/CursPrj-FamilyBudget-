(function () {
    'use strict';

    angular.module('App').service('Wallets', wallets);

    wallets.$inject = ['$http'];

    function wallets($http) {
        this.getUserWallets = getUserWallets;
        this.getUserWalletsByID = getUserWalletsByID;

        function getUserWallets() {
            return $http.get('/service/getUserWallets');
        }

        function getUserWalletsByID(id) {
            return $http({
                url: '/service/GetUserWalletByID', 
                method: 'GET',
                params: { walletID: id }
            });
        }
    }
})();