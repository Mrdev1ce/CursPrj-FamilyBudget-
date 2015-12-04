(function () {
    'use strict';

    angular.module('App').service('User', user);

    user.$inject = ['$http', '$q'];

    function user($http, $q) {

        this.getUserLogin = getUserLogin;
        this.getUserInfo = getUserInfo;
        this.getAllUsersInfo = getAllUsersInfo;
        this.changePassword = changePassword;
        this.changeUserRole = changeUserRole;
        this.getUserInfoAbout = getUserInfoAbout;

        function getUserLogin() {
            return $http.get('/service/getUserLogin');
        }

        function getUserInfo() {
            return $http.get('/service/getUserInfo');
        }

        function getUserInfoAbout(userId) {
            return $http({
                method: 'GET',
                url: '/service/GetUserInfoAbout',
                params: {
                    userId: userId
                }
            });
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

        function changeUserRole(userLogin, roleIsAdmin) {
            return $http({
                method: 'POST',
                url: '/service/changeUserRole',
                data: {
                    UserForChangeLogin: userLogin,
                    IsAdmin: roleIsAdmin
                }
            });
        }
    }
})();