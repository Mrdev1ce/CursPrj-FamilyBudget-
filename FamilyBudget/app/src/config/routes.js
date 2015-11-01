(function() {
    'use strict';

    angular.module('App').constant('Routes', {
        HomeRoute: {
            name: 'home',
            url: '/home',
            controller: 'HomeCtrl',
            templateUrl: '../app/src/pages/home/home.html'
        }
    });
})();