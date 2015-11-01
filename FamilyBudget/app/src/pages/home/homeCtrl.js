(function() {
    'use strcit';

    angular.module('App').controller('HomeCtrl', [
        '$scope', '$http',
        function ($scope, $http) {
            $scope.title = 'Hello';

            $scope.sendRequest = function() {
                $http({
                    method: 'GET',
                    url: '/service/test'
                }).then(function(response) {
                    alert(response.data.someData);
                });
            };
        }
    ]);
})();