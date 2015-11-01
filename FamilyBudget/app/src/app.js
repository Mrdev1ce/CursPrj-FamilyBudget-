(function () {
    'use strict';

    angular.module('App', [
    'ui.router'
    ]).config(function ($stateProvider, $urlRouterProvider, Routes) {
        $urlRouterProvider.otherwise('/home');
        $stateProvider.state(Routes.HomeRoute);
    });
})();

