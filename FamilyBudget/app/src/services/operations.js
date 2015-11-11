(function () {
    'use strict';

    angular.module('App').service('Operations', operations);

    operations.$inject = ['$http'];

    function operations($http) {
        this.getUserOperations = getUserOperations;
        this.getOperationsByWalletID = getOperationsByWalletID;

        function getUserOperations() {
            return $http.get('/service/GetOperationsByLogin');
        }

        function getOperationsByWalletID(id) {
            return $http({
                url: '/service/GetOperationsByWalletID',
                method: 'GET',
                params: { walletID: id }
            });
        }
    }
})();