(function () {
    'use strict';

    angular.module('App').controller('ManageDataCtrl', ManageDataCtrl);

    ManageDataCtrl.$inject = ['$scope', 'wallets', 'operations', 'categories', '$uibModal', 'Wallets', 'Operations', '$state'];

    function ManageDataCtrl($scope, wallets, operations, categories, $uibModal, Wallets, Operations, $state) {
        var dataRegex = /^\/Date\((\d+)\)\/$/;

        $scope.wallets = wallets.data;
        $scope.categories = categories.data;
        $scope.operations = _.sortBy(_.forEach(operations.data, function (value) {
            value.Date = new Date(+dataRegex.exec(value.Date)[1]);
        }), 'Date').reverse();

        $scope.showConfirmModal = function (item, type, $event) {
            $event.preventDefault();
            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: '../app/src/blocks/confirm-delete-modal/modal.html',
                controller: 'DeleteModalInstanceCtrl',
                size: 'sm',
                resolve: {
                    item: function () {
                        return item;
                    }
                }
            });

            modalInstance.result.then(function () {
                switch (type) {
                    case 'wallet':
                        Wallets.removeWallet(item.ID).then(refreshData);
                        break;
                    case 'operation':
                        Operations.removeOperation(item.ID).then(refreshData);
                        break;
                }

                function refreshData() {
                    $state.go('manageData', {}, {
                        reload: true
                    });
                }
            });
        };
    }
})();