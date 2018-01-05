﻿(function () {
    'use strict';

    angular
        .module('App')
        .factory('PaymentService', PaymentService);

    PaymentService.$inject = ['$http'];

    function PaymentService($http) {
        return {
            Read: Read,
            ReadPaymentForPaymentinee: ReadPaymentForPaymentinee,
            ReadPaymentForPosition: ReadPaymentForPosition,
            Delete: Delete
        }

        function Read() {
            return $http({
                method: 'POST',
                url: '/ReceivePayment/Read',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function ReadPaymentForPaymentinee(paymentineeId) {
            return $http({
                method: 'POST',
                url: '/ReceivePayment/ReadPaymentForPaymentinee/' + paymentineeId,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function ReadPaymentForPosition(positionId) {
            return $http({
                method: 'POST',
                url: '/ReceivePayment/ReadPaymentForPosition/' + positionId,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function Delete(payment) {
            return $http({
                method: 'DELETE',
                url: '/ReceivePayment/Delete',
                data: $.param(payment),
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }
    }
})();