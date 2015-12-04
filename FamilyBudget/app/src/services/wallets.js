(function () {
    'use strict';

    angular.module('App').service('Wallets', wallets);

    wallets.$inject = ['$http'];

    function wallets($http) {
        this.getUserWallets = getUserWallets;
        this.getUserWalletsByID = getUserWalletsByID;
        this.addOrEditWallet = addOrEditWallet;
        this.removeWallet = removeWallet;
        this.getUserWalletsAbout = getUserWalletsAbout;

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

        function getUserWalletsAbout(userId) {
            return $http({
                url: '/service/GetUserWalletsAbout',
                method: 'GET',
                params: { userId: userId }
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