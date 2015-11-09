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
                    'User', '$q',
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
                    'Wallets', '$q',
                    function (Wallets) {
                        return Wallets.getUserWallets();
                    }
                ]
            }
        }
    });
})();