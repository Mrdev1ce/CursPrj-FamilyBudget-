(function() {
    'use strcit';

    angular.module('App').controller('HomeCtrl', homeCtrl);

    homeCtrl.$inject = ['$scope'];

    function homeCtrl($scope) {
        $scope.title = 'HOME';
    }
})();