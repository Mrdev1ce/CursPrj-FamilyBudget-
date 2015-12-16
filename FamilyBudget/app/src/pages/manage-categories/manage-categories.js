(function () {
    'use strcit';

    angular.module('App').controller('ManageCategoriesCtrl', ManageCategoriesCtrl);

    ManageCategoriesCtrl.$inject = ['$scope', 'categories', 'Categories', '$uibModal'];

    function ManageCategoriesCtrl($scope, categories, Categories, $uibModal) {
        $scope.categories = categories.data;
        $scope.isEditing = [];
        $scope.isCreating = false;
        $scope.editing = {
            value: ''
        };
        $scope.creating = {
            value: ''
        };

        $scope.startEditing = function (index) {
            $scope.cancelCreating();
            _.fill($scope.isEditing, false, 0, $scope.isEditing.length);
            $scope.isEditing[index] = true;
            $scope.editing.value = $scope.categories[index] ? $scope.categories[index].Name : '';
        };

        $scope.cancelEditing = function(index) {
            $scope.isEditing[index] = false;
            $scope.editing.value = '';
        };

        $scope.applyEditing = function(index) {
            var category = $scope.categories[index];
            if (category && _.isString($scope.editing.value) && $scope.editing.value.length > 1) {
                category.Name = $scope.editing.value;
                $scope.editing.value = '';
                $scope.isEditing[index] = false;
                Categories.addOrEditCategory(category);
            }
        };

        $scope.deleteCategory = function(index) {
            if (index >= 0 && index < $scope.categories.length) {
                var category = $scope.categories[index];
                var modalInstance = $uibModal.open({
                    animation: true,
                    templateUrl: '../app/src/blocks/confirm-delete-modal/modal.html',
                    controller: 'DeleteModalInstanceCtrl',
                    size: 'sm',
                    resolve: {
                        item: function () {
                            return category;
                        }
                    }
                });

                modalInstance.result.then(function () {
                    Categories.removeCategory(category.ID).then(function (response) {
                        if (response.data && response.data.success) {
                            $scope.categories.splice(index, 1);
                        }
                    });
                });
            }
        };

        $scope.startCreatingNewCategory = function () {
            if (!$scope.isCreating) {
                init();
                $scope.isCreating = true;
            }
        };

        $scope.applyCreating = function() {
            if ($scope.creating.value && $scope.creating.value.length > 1) {
                var category = {
                    ID: -1,
                    Name: $scope.creating.value
                };
                Categories.addOrEditCategory(category).then(function(response) {
                    if (response.data && response.data.success) {
                        $scope.isCreating = false;
                        $scope.creating.value = '';
                        refreshCategories();
                    }
                });   
            }
        };

        $scope.cancelCreating = function() {
            $scope.isCreating = false;
            $scope.creating.value = '';
        };

        init();

        function init() {
            if (_.isArray($scope.categories)) {
                _.fill($scope.isEditing, false, 0, $scope.categories.length);
            }
        }

        function refreshCategories() {
            Categories.getAllCategories().then(function (response) {
                var categories = response.data;
                if (categories) {
                    $scope.categories.length = 0;
                    if (_.isArray(categories)) {
                        _.forEach(categories, function (category) {
                            $scope.categories.push(category);
                        });
                    }
                }
            });
        }
    }
})();