(function () {
    'use strict';

    angular
        .module('App')
        .factory('TaxTypeService', TaxTypeService);

    TaxTypeService.$inject = ['$http'];

    function TaxTypeService($http) {
        return {
            Read: Read
        }

        function Read() {
            return $http({
                method: 'POST',
                url: '/TaxType/Read',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }
    }
})();