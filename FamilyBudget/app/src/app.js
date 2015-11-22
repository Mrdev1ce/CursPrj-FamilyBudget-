(function () {
    'use strict';

    angular.module('App', [
    'ui.router',
    'ui.bootstrap',
    'ngMessages'
    ]).config(function ($stateProvider, $urlRouterProvider, Routes) {
        $urlRouterProvider.otherwise('/home');
        $urlRouterProvider.when('/', '/home');
        $stateProvider.state(Routes.MainRoute);
        $stateProvider.state(Routes.HomeRoute);
        $stateProvider.state(Routes.WalletDetailsRoute);
        $stateProvider.state(Routes.WalletEditRoute);
        $stateProvider.state(Routes.ManageDataRoute);
        $stateProvider.state(Routes.OperationEditRoute);
    });
})();

