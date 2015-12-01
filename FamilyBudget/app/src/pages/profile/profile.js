(function () {
    'use strict';

    angular.module('App').controller('ProfileCtrl', ProfileCtrl);

    ProfileCtrl.$inject = ['$scope', '$uibModal', 'userInfo'];

    function ProfileCtrl($scope, $uibModal, userInfo) {
        var dataRegex = /^\/Date\((\d+)\)\/$/;

        $scope.user = userInfo.data.user;

        init();

        $scope.showChangePassModal = function ($event) {
            $event.preventDefault();
            $uibModal.open({
                animation: true,
                templateUrl: '../app/src/blocks/change-pass-modal/modal.html',
                controller: 'ChangePassModalInstanceCtrl',
                size: 'md'
            });
        };

        function init() {
            $scope.user.RegistrationDate = new Date(+dataRegex.exec($scope.user.RegistrationDate)[1]);
            $scope.user.Role = $scope.user.IsAdmin ? 'Administrator' : 'User';

            if ($scope.user.IsAdmin) {
                $scope.users = userInfo.data.users;
                _.forEach($scope.users, function(user) {
                    user.RegistrationDate = new Date(+dataRegex.exec(user.RegistrationDate)[1]);
                    user.Role = user.IsAdmin ? 'Administrator' : 'User';
                });
            }
        }
    }
})();