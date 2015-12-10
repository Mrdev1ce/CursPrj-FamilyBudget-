(function () {
    'use strcit';

    angular.module('App').controller('ManageCategoriesCtrl', ManageCategoriesCtrl);

    ManageCategoriesCtrl.$inject = ['$scope', 'categories', '$timeout'];

    function ManageCategoriesCtrl($scope, categories, $timeout) {
        $scope.categories = categories.data;
        $scope.isEditing = [];
        $scope.editing = {
            value: ''
        };
        $scope.startEditing = function (index) {
            $scope.isEditing[index] = true;
            $scope.editing.value = $scope.categories[index] ? $scope.categories[index].Name : '';
        };

        $scope.cancelEditing = function (index) {
            $scope.isEditing[index] = false;
            $scope.editing.value = '';
        };

        $scope.applyEditing = function (index) {
            var category = $scope.categories[index];
            if (category && _.isString($scope.editing.value) && $scope.editing.value.length > 1) {
                category.Name = $scope.editing.value;
                $scope.editing.value = '';
                $scope.isEditing[index] = false;
            }
        }

        $scope.deleteCategory = function (index) {
            if (index >= 0 && index < $scope.categories.length) {
                $scope.categories.splice(index, 1);
            }
        }

        function init() {
            if (_.isArray($scope.categories)) {
                _.fill($scope.isEditing, false, 0, $scope.categories.length);
            }
        }
    }
})();