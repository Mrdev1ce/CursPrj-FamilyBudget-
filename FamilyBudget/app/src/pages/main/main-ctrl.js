(function() {
    'use strict';

    angular.module('App').controller('MainCtrl', mainCtrl);

    mainCtrl.$inject = ['$scope', 'userInfo', '$state', 'Camelize'];

    function mainCtrl($scope, userInfo, $state, Camelize) {
        $scope.userInfo = userInfo.data;

        $scope.$on('$stateChangeSuccess', function (event, toState) {
            $scope.currentTitle = Camelize.decamelize(toState.name);
        });
    }
})();