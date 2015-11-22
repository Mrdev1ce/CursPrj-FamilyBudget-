(function () {
    'use strict';

    angular.module('App').service('Operations', operations);

    operations.$inject = ['$http'];

    function operations($http) {
        this.getUserOperations = getUserOperations;
        this.getOperationsByWalletID = getOperationsByWalletID;
        this.addOperation = addOperation;
        this.removeOperation = removeOperation;

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

        function addOperation(operation) {
            return $http({
                url: 'service/AddOperation',
                method: 'POST',
                data: operation
            });
        }

        function removeOperation(id) {
            return $http({
                url: 'service/RemoveOperation',
                method: 'POST',
                data: {
                    operationId: id
                }
            });
        }
    }
})();