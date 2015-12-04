(function () {
    'use strict';

    angular.module('App').controller('UserInfoCtrl', UserInfoCtrl);

    UserInfoCtrl.$inject = ['$scope', 'userInfo', 'User'];

    function UserInfoCtrl($scope, userInfo, User) {
        var dataRegex = /^\/Date\((\d+)\)\/$/;

        //$scope.user = userInfo.data.user;
        $scope.user = {
            IsAdmin: true
        };
        changeBtnTitle();

        //init();

        $scope.changeUserRole = function () {
            User.changeUserRole($scope.user.Login, !$scope.user.IsAdmin).then(
                function (data) {
                    $scope.user.IsAdmin = !$scope.user.IsAdmin;
                    changeBtnTitle();
                }, function () {
                    $scope.error = 'You can\'t do this';
                });
        };

        function changeBtnTitle() {
            $scope.btnChangeRoleTitle = $scope.user.IsAdmin ? 'Demote to user' : 'Increased to admin';
        }

        function init() {
            $scope.user.RegistrationDate = new Date(+dataRegex.exec($scope.user.RegistrationDate)[1]);
            $scope.user.Role = $scope.user.IsAdmin ? 'Administrator' : 'User';

            if ($scope.user.IsAdmin) {
                $scope.users = userInfo.data.users;
                _.forEach($scope.users, function (user) {
                    user.RegistrationDate = new Date(+dataRegex.exec(user.RegistrationDate)[1]);
                    user.Role = user.IsAdmin ? 'Administrator' : 'User';
                });
            }
        }
    }
})();