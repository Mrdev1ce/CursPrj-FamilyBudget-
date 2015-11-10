(function () {
    'use strict';

    angular.module('App').service('Operations', operations);

    operations.$inject = ['$http'];

    function operations($http) {
        this.getUserOperations = getUserOperations;

        function getUserOperations() {
            return $http.get('/service/GetOperationsByLogin');
        }
    }
})();