(function () {
    'use strict';

    angular.module('App').controller('WalletEditCtrl', WalletEditCtrl);

    WalletEditCtrl.$inject = ['$scope', '$stateParams', 'Wallets', '$state'];

    function WalletEditCtrl($scope, $stateParams, Wallets, $state) {
        init();
        
        $scope.submit = function () {
            if ($scope.form.$valid) {
                Wallets.addOrEditWallet($scope.wallet).then(function(response) {
                   if (response.data && response.data.success) {
                       $state.go('home');
                   }
                });
            }
        };

        function init() {
            if ($stateParams.id === 'new') {
                $scope.title = 'New';
            } else if (/^[0-9]+$/.test($stateParams.id)) {
                $scope.title = 'Edit';
                Wallets.getUserWalletsByID(+$stateParams.id)
                    .then(function (response) {
                        if (response.data) {
                            $scope.wallet = response.data;
                        }
                    });
            }
        }
    }
})();