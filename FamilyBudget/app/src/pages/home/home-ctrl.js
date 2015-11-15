(function() {
    'use strcit';

    angular.module('App').controller('HomeCtrl', homeCtrl);

    homeCtrl.$inject = ['$scope', 'wallets', 'operations'];

    function homeCtrl($scope, wallets, operations) {
        var dataRegex = /^\/Date\((\d+)\)\/$/;
        $scope.wallets = wallets.data;
        $scope.totalFunds = _.reduce(wallets.data, function (total, num) {
            total = angular.isObject(total) ? total.Funds : total;
            return total + num.Funds;
        });
        $scope.operations = _.sortBy(_.forEach(operations.data, function (value) {
            value.Date = new Date(+dataRegex.exec(value.Date)[1]);
        }), 'Date').reverse();
    }
})();