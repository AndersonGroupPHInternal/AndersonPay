(function () {
    'use strict';

    angular
        .module('App')
        .controller('CurrencyController', CurrencyController);

    CurrencyController.$inject = ['$filter', '$window', 'CurrencyService'];

    function CurrencyController($filter ,$window, CurrencyService) {
        var vm = this;

        vm.Currencies;
        vm.CurrencyId;
        vm.CurrencyCodes;
        vm.Initialise = Initialise;

        function Initialise() {
            Read();
        }

        function Read() {
            CurrencyService.Read()
                .then(function (response) {
                    vm.Currencies = response.data;
                    var currency = $filter('filter')(vm.Currencies, { CurrencyId: vm.CurrencyId })[0];
                    if (currency)
                        vm.Currency = currency;
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