(function () {
    'use strict';

    angular.module('App').controller('ChangePassModalInstanceCtrl', ChangePassModalInstanceCtrl);

    ChangePassModalInstanceCtrl.$inject = ['$scope', '$uibModalInstance', 'User'];

    function ChangePassModalInstanceCtrl($scope, $uibModalInstance, User) {

        $scope.save = function () {
            if ($scope.pass && $scope.pass.OldPass && $scope.pass.NewPass) {
                User.changePassword($scope.pass.OldPass, $scope.pass.NewPass).then(function (response) {
                    if (response.data.isSuccess) {
                        $uibModalInstance.close();
                    } else {
                        if ($scope.alerts.length === 0) {
                            $scope.alerts.push({ type: 'danger', msg: 'Looks like something goes wrong' });
                        }
                    }
                });
            }
        };

        $scope.cancel = function () {
            $uibModalInstance.dismiss('cancel');
        };

        $scope.closeAlert = function() {
            $scope.alerts.length = 0;
        };

        $scope.alerts = [];
    }
})();