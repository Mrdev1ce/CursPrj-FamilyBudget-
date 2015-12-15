(function() {
    'use strcit';

    angular.module('App').controller('HomeCtrl', homeCtrl);

    homeCtrl.$inject = ['$scope', 'wallets', 'operations'];

    function homeCtrl($scope, wallets, operations) {
        var dataRegex = /^\/Date\((\d+)\)\/$/;
        $scope.wallets = wallets.data;
        $scope.totalFunds = calculateTotalOnAccounts($scope.wallets);
        $scope.operations = _.sortBy(_.forEach(operations.data, function (value) {
            value.Date = new Date(+dataRegex.exec(value.Date)[1]);
        }), 'Date').reverse();
        $scope.limitOperations = 10;

        function calculateTotalOnAccounts(accounts) {
            var total = 0;
            if (accounts && _.isArray(accounts)) {
                _.each(accounts, function (account) {
                    total += account.Funds;
                });
            }
            return total;
        }
    }
})();