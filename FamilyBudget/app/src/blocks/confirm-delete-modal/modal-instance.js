(function () {
    'use strict';

    angular.module('App').controller('DeleteModalInstanceCtrl', DeleteModalInstanceCtrl);

    DeleteModalInstanceCtrl.$inject = ['$scope', '$uibModalInstance', 'item'];

    function DeleteModalInstanceCtrl($scope, $uibModalInstance, item) {
        $scope.item = item;

        $scope.ok = function () {
            $uibModalInstance.close();
        };

        $scope.cancel = function () {
            $uibModalInstance.dismiss('cancel');
        };
    }
})();