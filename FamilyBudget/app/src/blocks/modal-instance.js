(function () {
    'use strict';

    angular.module('App').controller('ModalInstanceCtrl', ModalInstanceCtrl);

    ModalInstanceCtrl.$inject = ['$scope', '$uibModalInstance', 'item'];

    function ModalInstanceCtrl($scope, $uibModalInstance, item) {
        $scope.item = item;

        $scope.ok = function () {
            $uibModalInstance.close();
        };

        $scope.cancel = function () {
            $uibModalInstance.dismiss('cancel');
        };
    }
})();