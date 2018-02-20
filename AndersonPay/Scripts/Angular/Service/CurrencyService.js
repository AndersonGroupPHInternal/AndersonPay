(function () {
    'use strict';

    angular
        .module('App')
        .factory('CurrencyService', CurrencyService);

    CurrencyService.$inject = ['$http'];

    function CurrencyService($http) {
        return {
            Read: Read
        }

        function Read() {
            return $http({
                method: 'POST',
                url: '/Currency/Read',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }
    }
})();