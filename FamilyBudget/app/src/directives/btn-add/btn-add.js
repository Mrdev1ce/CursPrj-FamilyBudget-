﻿(function () {
    'use strict';

    angular.module('App').directive('btnAdd', btnAdd);

    function btnAdd() {
        return {
            restrcit: 'E',
            replace: true,
            controller: function ($scope) {
                $scope.isShow = false;
                $scope.toggle = function () {
                    $scope.isShow = !$scope.isShow;
                };
            },
            templateUrl: 'app/src/directives/btn-add/btn-add.html'
        };
    }
})();