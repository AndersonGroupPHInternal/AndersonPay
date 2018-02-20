(function () {
    'use strict';

    angular
        .module('App')
        .controller('ClientController', ClientController);

    ClientController.$inject = ['$filter', '$window', 'ClientService', 'CurrencyService', 'TaxTypeService'];

    function ClientController($filter, $window, ClientService, CurrencyService, TaxTypeService) {
        var vm = this;

        vm.Client;
        vm.ClientId;

        vm.Clients = [];
        vm.Currencies = [];
        vm.TaxTypes = [];

        vm.GoToUpdatePage = GoToUpdatePage;

        vm.Initialise = Initialise;

        vm.Delete = Delete;
        vm.ReadForCurrency = ReadForCurrency;
        vm.UpdateCurrency = UpdateCurrency;
        vm.ReadForTaxType = ReadForTaxType;
        vm.UpdateTaxType = UpdateTaxType;


        function GoToUpdatePage(clientId) {
            $window.location.href = '../Client/Update/' + clientId;
        }

        function Initialise() {
            Read();
        }

        function Read() {
            ClientService.Read()
                .then(function (response) {
                    vm.Clients = response.data;
                    ReadForCurrency();
                    ReadForTaxType();
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

        function Delete(client) {
            ClientService.Delete(client)
                .then(function (response) {
                    Read();
                })
                .catch(function (data, status) {
                });
        }

        function ReadForCurrency() {
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
            angular.forEach(vm.Clients, function (client) {
                client.Currency = $filter('filter')(vm.Currencies, { CurrencyId: client.CurrencyCodeId })[0];
            });
        }

        function ReadForTaxType() {
            TaxTypeService.Read()
                .then(function (response) {
                    vm.TaxTypes = response.data;
                    UpdateTaxType();
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

        function UpdateTaxType() {
            angular.forEach(vm.Clients, function (taxType) {
                taxType.TaxType = $filter('filter')(vm.TaxTypes, { TaxTypeId: taxType.TaxTypeId })[0];
            });
        }
    }
})();