(function () {
    'use strict';

    angular.module('App').controller('ManageDataCtrl', ManageDataCtrl);

    ManageDataCtrl.$inject = ['$scope', 'wallets'];

    function ManageDataCtrl($scope, wallets) {
        $scope.wallets = wallets.data;
    }
})();