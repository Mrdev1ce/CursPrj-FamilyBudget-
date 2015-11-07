(function() {
    'use strict';

    angular.module('App').controller('MainCtrl', mainCtrl);

    mainCtrl.$inject = ['$scope', 'userInfo'];

    function mainCtrl($scope, userInfo) {
        $scope.userInfo = userInfo.data;
    }
})();