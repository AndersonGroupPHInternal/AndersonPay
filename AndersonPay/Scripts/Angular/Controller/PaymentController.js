(function () {
    'use strict';

    angular
        .module('App')
        .controller('PaymentController', PaymentController);

    PaymentController.$inject = ['$window', '$filter', 'PaymentService', 'ServiceService', 'TypeOfServiceService', 'InvoiceService', 'ClientService'];

    function PaymentController($window, $filter, PaymentService, ServiceService, TypeOfServiceService, InvoiceService, ClientService) {
        var vm = this;

        vm.Client;
        vm.Invoice = {
            Payment: 0,
            Discount: 0
        };
        vm.Payments;
        vm.ClientId;

        vm.TypeOfServices = [];
        vm.Services = [];
        vm.Invoices = [];
        vm.Clients = [];
        vm.isAllSelected = [];

        vm.GoToUpdatePage = GoToUpdatePage;
        vm.Initialise = Initialise;
        //vm.ReadForTypeOfService = ReadForTypeOfService;

        vm.Delete = Delete;
        vm.ClientChange = ClientChange;
        vm.TotalAmountReceived = TotalAmountReceived;
        vm.Balance = Balance;
        vm.TotalBalance = TotalBalance;
        vm.AmountDue = AmountDue;
        vm.Amount_Due = Amount_Due;
        vm.Change = Change;
        vm.TotalChange = TotalChange;
        vm.CheckboxToggled = CheckboxToggled;
        vm.ToggleAll = ToggleAll;
        
        function GoToUpdatePage(paymentId) {
            $window.location.href = '../Payment/Update/' + paymentId;
        }

        function Initialise() {
            Read();
            ReadForClient();
        }

        function ClientChange() {
            ReadForInvoice();
            var invoice = angular.copy(vm.Invoice);
            vm.Invoices.push(invoice);
        }

        function Read() {
            PaymentService.Read()
                .then(function (response) {
                    vm.Payments = response.data;
                })
                .catch(function (data, status) {
                    new PNotify({
                        title: status,
                        text: data,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });
                });
        }

        function Delete(payment) {
            PaymentService.Delete(payment)
                .then(function (response) {
                    Read();
                })
                .catch(function (data, status) {

                });
        }

        function ReadForService() {
            ServiceService.Read()
                .then(function (response) {
                    vm.Services = response.data;
                    ReadForTypeOfService();
                })
                .catch(function (data, status) {
                    new PNotify({
                        title: status,
                        text: data,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });
                });
        }

        function ReadForTypeOfService() {
            TypeOfServiceService.Read()
                .then(function (response) {
                    vm.TypeOfServices = response.data;
                    angular.forEach(vm.Services, function (service) {
                        service.TypeOfService = $filter('filter')(vm.TypeOfServices, { TypeOfServiceId: service.TypeOfServiceId })[0];
                    });
                })
                .catch(function (data, status) {
                    new PNotify({
                        title: status,
                        text: data,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });
                });
        }

        function ReadForInvoice() {
            InvoiceService.ReadId(vm.Client.ClientId)
                .then(function (response) {
                    vm.Invoices = response.data;
                })
                .catch(function (data, status) {
                    new PNotify({
                        title: status,
                        text: data,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });
                });
        }

        function ReadForClient() {
            ClientService.Read()
                .then(function (response) {
                    vm.Clients = response.data;
                    var client = $filter('filter')(vm.Clients, { ClientId: vm.ClientId })[0];
                    if (client)
                        vm.Client = client;
                    ReadForInvoice();
                })
                .catch(function (data, status) {
                    new PNotify({
                        title: status,
                        text: data,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });

                });
        }

        function Payment(invoice) {
            if (invoice.Selected == true) {
                if (invoice.Payment != undefined)
                    return invoice.Payment;
                else
                    return 0;
            }
            else
                return 0;
        }

        //AMOUNT DUE
        function AmountD(invoice) {
            if (invoice.Selected == true) {
                if (invoice.AmountDue != undefined)
                    return invoice.AmountDue;
                else
                    return 0;
            }
            else
                return 0;
        }

        function AmountDue(invoiceAmountDue, invoice) { //table
            var amountDue = 0;
            angular.forEach(vm.Invoices, function (invoice) {
                amountDue += AmountD(invoice);
            });
            if (!amountDue)
                amountDue;
            return amountDue.toFixed(2);
        }

        function Amount_Due(invoiceAmountDue, invoice) { //table
            var amountDue = 0;
            amountDue = invoiceAmountDue;
            return amountDue;
        }

        //AMOUNT RECEIVED
        function TotalAmountReceived(invoice) {
            var total = 0;
            angular.forEach(vm.Invoices, function (invoice) {
                total += Payment(invoice);
            });
            if (!total)
                total = 0;
            return total;
        }

        //BALANCE
        function Balance(invoiceAmountDue, invoice) { //table
            var balance = 0;
            balance = invoiceAmountDue - Payment(invoice);
            if (balance < 0) {
                balance = 0;
            }
            return balance;
        }

        function TotalBalance() { 
            var balance = 0;
            angular.forEach(vm.Invoices, function (invoiceAmountDue, invoice) {
                balance = AmountDue(invoiceAmountDue, invoice) - TotalAmountReceived(invoice);
            });
            if (balance < 0) {
                balance = 0;
            }
            return balance;
        }

        //CHANGE
        function Change(invoiceAmountDue, invoice) { //table
            var change = 0;
            change = invoiceAmountDue - Payment(invoice);
            if (change > 0) {
                change = 0;
            }
            if (change < 0) {
                change = change * -1;
            }
            return change.toFixed(2);
        }

        function TotalChange(invoiceAmountDue, invoice) {
            var change = 0;
            angular.forEach(vm.Invoices, function (invoiceAmountDue, invoice) {
                change = TotalAmountReceived(invoice) - AmountDue(invoiceAmountDue, invoice);
            });
            if (change < 0)
                change = 0;

            return change.toFixed(2);
        }

        function ToggleAll() {
            var toggleStatus = vm.isAllSelected;
            angular.forEach(vm.Invoices, function (invoice) {
                invoice.Selected = toggleStatus;
            });
        }

        function CheckboxToggled() {
            vm.isAllSelected = vm.Invoices.every(function (invoice) {
                return invoice.Selected;
            });
        }
    }
})();