(function () {
    'use strict';

    angular
        .module('App')
        .factory('InvoiceService', InvoiceService);

    InvoiceService.$inject = ['$http'];

    function InvoiceService($http) {
        return {
            Read: Read,
            ReadId: ReadId,
            Delete: Delete,
            List: List
        }

        function Read() {
            return $http({
                method: 'POST',
                url: '/Invoice/Read',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function ReadId(id) {
            return $http({
                method: 'POST',
                url: '/Invoice/ReadClientId/' + id,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function Delete(invoiceId) {
            return $http({
                method: 'DELETE',
                url: '/Invoice/Delete/' + invoiceId,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function List() {
            return $http({
                method: 'POST',
                url: '../AndersonPay/TypeOfServices',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function PDF(InvoiceId) {
            return $http({
                method: 'POST',
                url: '/Invoice/Read',
                data: $.param(InvoiceId),
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }
    }
})();