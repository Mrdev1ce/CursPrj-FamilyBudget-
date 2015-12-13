(function () {
    'use strict';

    angular.module('App').service('Categories', categories);

    categories.$inject = ['$http'];

    function categories($http) {
        this.getAllCategories = getAllCategories;
        this.addOrEditCategory = addOrEditCategory;
        this.removeCategory = removeCategory;

        function getAllCategories() {
            return $http.get('/service/GetAllCategories');
        }

        function addOrEditCategory(category) {
            return $http.post('/service/AddOrEditCategory', category);
        }

        function removeCategory(id) {
            return $http.post('/service/removeCategory', { categoryId: id });
        }
    }
})();