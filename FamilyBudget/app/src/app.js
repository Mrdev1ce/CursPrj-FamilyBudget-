(function () {
    'use strict';

    angular.module('App', [
    'ui.router'
    ]).config(function ($stateProvider, $urlRouterProvider, Routes) {
        $urlRouterProvider.otherwise('/home');
        $urlRouterProvider.when('/', '/home');
        $stateProvider.state(Routes.MainRoute);
        $stateProvider.state(Routes.HomeRoute);
    });
})();

