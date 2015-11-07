(function () {
    'use strict';

    angular.module('App').service('User', user);

    user.$inject = ['$http'];

    function user($http) {

        this.getUserInfo = getUserInfo;

        function getUserInfo() {
            return $http.get('/service/getuserinfo');
        }
    }
})();