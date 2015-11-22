(function () {
    'use strict';

    angular.module('App').service('Wallets', wallets);

    wallets.$inject = ['$http'];

    function wallets($http) {
        this.getUserWallets = getUserWallets;
        this.getUserWalletsByID = getUserWalletsByID;
        this.addOrEditWallet = addOrEditWallet;
        this.removeWallet = removeWallet;

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

        function addOrEditWallet(wallet) {
            return $http({
                url: '/service/AddOrEditWallet',
                method: 'POST',
                data: wallet
            });
        }

        function removeWallet(id) {
            return $http({
                url: '/service/RemoveWallet',
                method: 'POST',
                data: {
                    walletId: id
                }
            });
        }
    }
})();