(function () {
    'use strict';

    angular
        .module('App')
        .factory('CompanyAddressService', CompanyAddressService);

    CompanyAddressService.$inject = ['$http'];

    function CompanyAddressService($http) {
        return {
            Read: Read
        }

        function Read() {
            return $http({
                method: 'POST',
                url: '/CompanyAddress/Read',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }
    }
})();