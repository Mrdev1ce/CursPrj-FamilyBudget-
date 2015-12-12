(function () {
    'use strict';

    angular.module('App').service('Categories', categories);

    categories.$inject = ['$http'];

    function categories($http) {
        this.getAllCategories = getAllCategories;
        this.addOrEditCategory = addOrEditCategory;

        function getAllCategories() {
            return $http.get('/service/GetAllCategories');
        }

        function addOrEditCategory(category) {
            return $http.post('/service/AddOrEditCategory', category);
        }
    }
})();