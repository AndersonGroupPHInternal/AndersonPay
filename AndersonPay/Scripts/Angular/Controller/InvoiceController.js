(function () {
    'use strict';

    angular
        .module('App')
        .controller('InvoiceController', InvoiceController);

    InvoiceController.$inject = ['$filter', '$window', 'InvoiceService', 'ClientService', 'TypeOfServiceService', 'ServiceService'];

    function InvoiceController($filter, $window, InvoiceService, ClientService, TypeOfServiceService, ServiceService) {
        var vm = this;

        vm.ClientId;
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

        vm.TryS = 123;
        vm.AmountDueValue = 0;
        vm.WithholdingTaxValue;

        //array
        vm.Invoices = [];
        vm.TypeOfServices = [];
        vm.Services = [];

        //read
        vm.ReadForClients = ReadForClients;
        vm.ReadForTypeOfService = ReadForTypeOfService;
        vm.GoToUpdatePage = GoToUpdatePage;
        vm.PDF = PDF;

        vm.Initialise = Initialise;
        vm.InitialiseCrud = InitialiseCrud;
        vm.Clients;
        vm.Delete = Delete;

        //function create
        vm.CreateInvoiceService = CreateInvoiceService;
        //function delete
        vm.deleteRow = deleteRow;
        //function compute subtotal
        vm.Subtotal = Subtotal;
        //function compute Total
        vm.TotalSales = TotalSales;
        //function compute SalesTax
        vm.SalesTax = SalesTax;
        //function compute withholdingTax
        vm.WithholdingTax = WithholdingTax;
        //compute Amount Due
        vm.AmountDue = AmountDue;
        //function others
        vm.InitialiseTypeOfService = InitialiseTypeOfService;
        //function SINo
        vm.SINo = SINo;
        vm.TryF = TryF;

        function GoToUpdatePage(invoiceId) {
            $window.location.href = '../Invoice/Update/' + invoiceId;
        }

        function TryF(taxu) {
            console.log(vm.Services);
            console.log(vm.Invoices);
            vm.TryS = 10;
        }

        function Initialise(invoiceId) {
            Read();
            ReadForClients();
        }

        function InitialiseCrud(clientId, invoiceId, address) {
            vm.ClientId = clientId;
            vm.InvoiceId = invoiceId;
            vm.Address = address;
            ReadForClients();
            vm.AmountDueValue = 21;
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

        //create row and column for computation of subtotal
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

        //SIno
        function SINo(SINoCode) {
            var SINoCode = "";
            return SINoCode;
        }

        function CompanyBranch(BranchCode) {
            var BranchCode = "BCode";
            return BranchCode;
        }

        //PFD get data
        function PDF(invoiceId) {
            $window.location.href = '../Invoice/InvoiceSummary/' + invoiceId;
            //$window.href = '..("InvoiceSummary", "Invoice")';
            //$window.location.href = '@Url.Action("InvoiceSummary", "Invoice")';
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
    }
})();