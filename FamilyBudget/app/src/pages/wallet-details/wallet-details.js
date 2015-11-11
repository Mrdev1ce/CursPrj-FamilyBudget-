(function () {
    'use strict';

    angular.module('App').controller('WalletDetailsCtrl', WalletDetailsCtrl);

    WalletDetailsCtrl.$inject = ['$scope', 'wallet', 'operations'];

    function WalletDetailsCtrl($scope, wallet, operations) {
        var dataRegex = /^\/Date\((\d+)\)\/$/;
        $scope.wallet = wallet.data;
        $scope.operations =  $scope.wallet ? _.sortBy(_.forEach(operations.data, function (value) {
            value.Date = new Date(+dataRegex.exec(value.Date)[1]);
        }), 'Date').reverse() : [];
    }
})();