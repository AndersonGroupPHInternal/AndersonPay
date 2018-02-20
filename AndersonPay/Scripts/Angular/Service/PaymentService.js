(function () {
    'use strict';

    angular
        .module('App')
        .factory('PaymentService', PaymentService);

    PaymentService.$inject = ['$http'];

    function PaymentService($http) {
        return {
            Read: Read,
            Delete: Delete
        }

        function Read() {
            return $http({
                method: 'POST',
                url: '/Payment/Read',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function Delete(payment) {
            return $http({
                method: 'DELETE',
                url: '/Payment/Delete',
                data: $.param(payment),
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }
    }
})();