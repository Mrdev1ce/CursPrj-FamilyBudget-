(function() {
    'use strcit';

    angular.module('App').controller('HomeCtrl', homeCtrl);

    homeCtrl.$inject = ['$scope', 'wallets'];

    function homeCtrl($scope, wallets) {
        $scope.title = 'HOME';
        $scope.wallets = wallets.data;
        $scope.totalFunds = _.reduce(wallets.data, function (total, num) {
            total = angular.isObject(total) ? total.Funds : total;
            return total + num.Funds;
        });
    }
})();