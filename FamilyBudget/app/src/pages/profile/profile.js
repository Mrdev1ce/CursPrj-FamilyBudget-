(function () {
    'use strict';

    angular.module('App').controller('ProfileCtrl', ProfileCtrl);

    ProfileCtrl.$inject = ['$scope', '$uibModal'];

    function ProfileCtrl($scope, $uibModal) {
        $scope.users = [
            {
                Login: 'maksim',
                Mail: 'maksim@epam.com',
                RegistrationDate: new Date(2013, 6, 5),
                Role: 'Administrator'
            },
            {
                Login: 'account 1',
                Mail: 'account1@mail.com',
                RegistrationDate: new Date(2014, 4, 22),
                Role: 'User'
            }
        ];

        $scope.showChangePassModal = function ($event) {
            $event.preventDefault();
            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: '../app/src/blocks/change-pass-modal/modal.html',
                controller: 'ChangePassModalInstanceCtrl',
                size: 'md'
            });

            modalInstance.result.then(function (data) {
            });
        };
    }
})();