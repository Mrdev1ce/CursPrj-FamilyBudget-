﻿(function () {
    'use strict';

    angular.module('App').constant('Routes', {
        MainRoute: {
            name: 'main',
            url: '/',
            controller: 'MainCtrl',
            templateUrl: '../app/src/pages/main/main.html',
            resolve: {
                userInfo: [
                    'User',
                    function (User) {
                        return User.getUserInfo();
                    }
                ]
            }
        },
        HomeRoute: {
            name: 'home',
            parent: 'main',
            url: 'home',
            controller: 'HomeCtrl',
            templateUrl: '../app/src/pages/home/home.html',
            resolve: {
                wallets: [
                    'Wallets',
                    function (Wallets) {
                        return Wallets.getUserWallets();
                    }
                ],
                operations: [
                    'Operations',
                    function (Operations) {
                        return Operations.getUserOperations();
                    }
                ]
            }
        },
        WalletDetailsRoute: {
            name: 'walletDetails',
            parent: 'main',
            url: 'wallet-details/{id:[0-9]+}',
            controller: 'WalletDetailsCtrl',
            templateUrl: '../app/src/pages/wallet-details/wallet-details.html',
            resolve: {
                wallet: [
                    'Wallets', '$stateParams',
                    function (Wallets, $stateParams) {
                        return Wallets.getUserWalletsByID(+$stateParams.id);
                    }
                ],
                operations: [
                    'Operations', '$stateParams',
                    function (Operations, $stateParams) {
                        return Operations.getOperationsByWalletID(+$stateParams.id);
                    }
                ]
            }
        },
        WalletEditRoute: {
            name: 'walletEdit',
            parent: 'main',
            url: 'wallet-edit/{id:[0-9]+|new}',
            controller: 'WalletEditCtrl',
            templateUrl: '../app/src/pages/wallet-edit/wallet-edit.html'
        },
        ManageDataRoute: {
            name: 'manageData',
            parent: 'main',
            url: 'manage-data',
            controller: 'ManageDataCtrl',
            templateUrl: '../app/src/pages/manage-data/manage-data.html'
        }
    });
})();