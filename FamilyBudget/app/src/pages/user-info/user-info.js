(function () {
    'use strict';

    angular.module('App').controller('UserInfoCtrl', UserInfoCtrl);

    UserInfoCtrl.$inject = ['$scope', 'userInfo', 'User', 'userWallets'];

    function UserInfoCtrl($scope, userInfo, User, userWallets) {
        var dataRegex = /^\/Date\((\d+)\)\/$/;

        $scope.user = userInfo.data;
        $scope.userWallets = userWallets.data;

        $scope.changeUserRole = function () {
            User.changeUserRole($scope.user.Login, !$scope.user.IsAdmin).then(
                function (response) {
                    if (response && response.data.isSuccess) {
                        $scope.user.IsAdmin = !$scope.user.IsAdmin;
                        $scope.user.Role = $scope.user.IsAdmin ? 'Administrator' : 'User';
                        changeBtnTitle();
                    } else {
                        $scope.error = 'You can\'t do this';
                    }
                });
        };

        init();

        function changeBtnTitle() {
            $scope.btnChangeRoleTitle = $scope.user.IsAdmin ? 'Demote to user' : 'Increased to admin';
        }

        function init() {
            $scope.user.RegistrationDate = new Date(+dataRegex.exec($scope.user.RegistrationDate)[1]);
            $scope.user.Role = $scope.user.IsAdmin ? 'Administrator' : 'User';
            changeBtnTitle();
        }
    }
})();