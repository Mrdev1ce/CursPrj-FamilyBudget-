(function () {
    'use strict';

    angular.module('App').controller('ChangePassModalInstanceCtrl', ChangePassModalInstanceCtrl);

    ChangePassModalInstanceCtrl.$inject = ['$scope', '$uibModalInstance'];

    function ChangePassModalInstanceCtrl($scope, $uibModalInstance) {

        $scope.save = function () {
            $uibModalInstance.close($scope.pass);
        };

        $scope.cancel = function () {
            $uibModalInstance.dismiss('cancel');
        };
    }
})();