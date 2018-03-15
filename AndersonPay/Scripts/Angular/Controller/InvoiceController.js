(function () {
    'use strict';

    angular
        .module('App')
        .controller('InvoiceController', InvoiceController);

    InvoiceController.$inject = ['$filter', '$window', 'InvoiceService', 'ClientService', 'TypeOfServiceService', 'ServiceService', 'CurrencyService', 'CompanyAddressService'];

    function InvoiceController($filter, $window, InvoiceService, ClientService, TypeOfServiceService, ServiceService, CurrencyService, CompanyAddressService) {
        var vm = this;

        vm.ClientId;
        vm.ClientName;
        vm.InvoiceId;
        vm.Address;

        //object
        vm.Service = {
            TypeOfService: null,
            Description: '',
            Rate: 0,
            Quantity: 1,
            subtotalholder: 0,
            tax: 0,
            totaltax: 0,
            clientWithholdingTax: 0
        }

        //array
        vm.Invoices = [];
        vm.TypeOfServices = [];
        vm.Services = [];
        vm.Clients = [];
        vm.Currencies = [];

        //read
        vm.ReadForClients = ReadForClients;
        vm.ReadForTypeOfService = ReadForTypeOfService;
        vm.GoToUpdatePage = GoToUpdatePage;
        vm.ReadForCurrencies = ReadForCurrencies;

        vm.Initialise = Initialise;
        vm.InitialiseCrud = InitialiseCrud;
        vm.Clients;
        vm.Delete = Delete;

        vm.CreateInvoiceService = CreateInvoiceService;
        vm.deleteRow = deleteRow;
        vm.Subtotal = Subtotal;
        vm.TotalSales = TotalSales;
        vm.SalesTax = SalesTax;
        vm.WithholdingTax = WithholdingTax;
        vm.AmountDue = AmountDue;
        vm.InitialiseTypeOfService = InitialiseTypeOfService;

        function GoToUpdatePage(invoiceId) {
            $window.location.href = '../Invoice/Update/' + invoiceId;
        }

        function Initialise() {
            Read();
            ReadForClients();
        }
        function InitialiseCrud(clientId, invoiceId, address) {
            vm.ClientId = clientId;
            vm.InvoiceId = invoiceId;
            vm.Address = address;
            ReadForClients();
            ReadCompanyBranch();
            ReadForService(invoiceId);
        }

        function Read() {
            InvoiceService.Read()
                .then(function (response) {
                    vm.Invoices = response.data;
                    ////////////////////////////////////////
                    var invoice = $filter('filter')(vm.Invoices, { InvoiceId: vm.InvoiceId })[0];
                    if (invoice)
                        vm.Invoice = invoice;
                    ///////////////////////////////////////
                    ReadForCurrencies();
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

        function Delete(invoiceId) {
            InvoiceService.Delete(invoiceId)
                .then(function (response) {
                    Read();
                })
                .catch(function (data, status) {

                });
        }

        function ReadForClients() {
            ClientService.Read()
                .then(function (response) {
                    vm.Clients = response.data;
                    var client = $filter('filter')(vm.Clients, { ClientId: vm.ClientId })[0];
                    ReadForCurrencies();
                    if (client)
                        vm.Client = client;
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

        function CreateInvoiceService() {
            var service = angular.copy(vm.Service);
            vm.Services.push(service);
        }

        function InitialiseTypeOfService(typeOfServices) {
            InvoiceService.List()
                .then(function (response) {
                    vm.TypeOfService = response.data;
                })
        }

        //compute subtotal
        function Subtotal(service) {
            if (!service.Quantity)
                service.Quantity = 0;

            if (!service.Quantity)
                service.Quantity = 0;

            return (service.Quantity * service.Rate);
        }

        //compute Total
        function TotalSales() {
            var total = 0.00;
            angular.forEach(vm.Services, function (service) {
                total += Subtotal(service);
            });
            return total;
        }

        //compute Sales Tax
        function SalesTax() {
            var salesTax = 0.00;

            salesTax += 12 * TotalSales() / 100;

            return salesTax;
        }

        //compute Withholding Tax
        function WithholdingTax(whTax) {
            if (whTax != undefined && whTax != NaN)
                return whTax * TotalSales() / 100;
            else
                return 0;
        }

        //compute Amount Due
        function AmountDue(whTax) {
            if (whTax != undefined && whTax != NaN)
                return TotalSales() + SalesTax() - WithholdingTax(whTax);
            else
                return 0;
        }

        //delete row of computation on adding service
        function deleteRow(index) {
            vm.Services.splice(index, 1);
        }

        //read for Type Of Service
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
        
        function ReadCompanyBranch() {
            CompanyAddressService.Read()
                .then(function (response) {
                    vm.CompanyBranches = response.data;
                    var companyBranch = $filter('filter')(vm.CompanyBranches, { Address: vm.Address })[0];
                    if (companyBranch)
                        vm.CompanyBranch = companyBranch;
                })
                .catch(function (data, status) {
                    new PNotify({
                        title: status,
                        text: data,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });

                })
        }

        function ReadForService(invoiceId) {
            ServiceService.ReadId(invoiceId)
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

        function ReadForCurrencies() {
            CurrencyService.Read()
                .then(function (response) {
                    vm.Currencies = response.data;
                    UpdateCurrency();
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

        function UpdateCurrency() {
            angular.forEach(vm.Invoices, function (invoice) {
                invoice.Currency = $filter('filter')(vm.Currencies, { CurrencyId: invoice.CurrencyId })[0];
            });

            angular.forEach(vm.Clients, function (client) {
                client.Currency = $filter('filter')(vm.Currencies, { CurrencyId: client.CurrencyCodeId })[0];
            });
        }
    }
})();