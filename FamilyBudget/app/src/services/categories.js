(function () {
    'use strict';

    angular.module('App').service('Categories', categories);

    categories.$inject = ['$http'];

    function categories($http) {
        this.getAllCategories = getAllCategories;

        function getAllCategories() {
            return $http.get('/service/GetAllCategories');
        }
    }
})();