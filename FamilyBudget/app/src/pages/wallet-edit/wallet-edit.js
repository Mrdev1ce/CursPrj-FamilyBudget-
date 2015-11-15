(function () {
    'use strict';

    angular.module('App').controller('WalletEditCtrl', WalletEditCtrl);

    WalletEditCtrl.$inject = ['$scope'];

    function WalletEditCtrl($scope) {
        $scope.submit = function () {
            console.log($scope);
        }
    }
})();