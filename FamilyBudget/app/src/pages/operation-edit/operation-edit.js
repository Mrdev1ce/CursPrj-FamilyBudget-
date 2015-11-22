(function () {
    'use strict';

    angular.module('App').controller('OperationEditCtrl', OperationEditCtrl);

    OperationEditCtrl.$inject = ['$scope', 'wallets', 'Operations', 'categories', '$state'];

    function OperationEditCtrl($scope, wallets, Operations, categories, $state) {
        $scope.operation = {
            Type: '1'
        };

        $scope.wallets = wallets.data;
        $scope.categories = categories.data;

        $scope.submit = function () {
            if ($scope.form.$valid) {
                $scope.operation.Type = $scope.operation.Type === '1';
                Operations.addOperation($scope.operation).then(function (response) {
                    if (response.data && response.data.success) {
                        $state.go('home');
                    }
                });
            }
        };

        $scope.$watch('operation.WalletID', function (newV) {
            var wallet = _.find($scope.wallets, {
                ID: +newV
            });
            if (wallet) {
                $scope.walletName = wallet.Name;
            }
        });
    }
})();