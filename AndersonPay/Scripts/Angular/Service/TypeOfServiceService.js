(function () {
    'use strict';

    angular
        .module('App')
        .factory('TypeOfServiceService', TypeOfServiceService);

    TypeOfServiceService.$inject = ['$http'];

    function TypeOfServiceService($http) {
        return {
            Read: Read,
            Delete: Delete
        }

        function Read() {
            return $http({
                method: 'POST',
                url: '/TypeOfService/Read',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function Delete(typeOfService) {
            return $http({
                method: 'DELETE',
                url: '/TypeOfService/Delete',
                data: $.param(typeOfService),
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }
    }
})();