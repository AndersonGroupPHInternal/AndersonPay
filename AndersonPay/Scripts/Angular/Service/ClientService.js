(function () {
    'use strict';

    angular
        .module('App')
        .factory('ClientService', ClientService);

    ClientService.$inject = ['$http'];

    function ClientService($http) {
        return {
            Read: Read,
            ReadId: ReadId,
            Delete: Delete
        }

        function Read() {
            return $http({
                method: 'POST',
                url: '/Client/Read',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function ReadId(id) {
            return $http({
                method: 'POST',
                url: '/Client/ReadClientId/' + id,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function Delete(client) {
            return $http({
                method: 'DELETE',
                url: '/Client/Delete',
                data: $.param(client),
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }
    }
})();   