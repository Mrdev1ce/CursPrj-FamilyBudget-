(function () {
    'use strict';

    angular.module('App').service('User', user);

    user.$inject = ['$http'];

    function user($http) {

        this.getUserLogin = getUserLogin;
        this.getUserInfo = getUserInfo;
        this.getAllUsersInfo = getAllUsersInfo;
        this.changePassword = changePassword;

        function getUserLogin() {
            return $http.get('/service/getUserLogin');
        }

        function getUserInfo() {
            return $http.get('/service/getUserInfo');
        }

        function getAllUsersInfo() {
            return $http.get('/service/getAllUsersInfo');
        }

        function changePassword(oldPass, newPass) {
            return $http({
                method: 'POST',
                url: '/service/changeUserPassword',
                data: {
                    OldPass: oldPass,
                    NewPass: newPass
                }
            });
        }
    }
})();