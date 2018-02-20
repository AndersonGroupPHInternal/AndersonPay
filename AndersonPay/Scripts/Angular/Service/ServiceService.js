(function () {
    'use strict';

    angular
        .module('App')
        .factory('ServiceService', ServiceService);

    ServiceService.$inject = ['$http'];

    function ServiceService($http) {
        return {
            Read: Read,
            ReadId: ReadId
        }

        function Read() {
            return $http({
                method: 'POST',
                url: '/Service/Read',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function ReadId(id) {
            return $http({
                method: 'POST',
                url: '/Service/ReadId/' + id,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }
    }
})();