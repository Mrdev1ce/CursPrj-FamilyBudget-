(function () {
    'use strcit';

    angular.module('App').controller('ManageCategoriesCtrl', ManageCategoriesCtrl);

    ManageCategoriesCtrl.$inject = ['$scope', 'categories'];

    function ManageCategoriesCtrl($scope, categories) {
        $scope.categories = categories.data;
    }
})();