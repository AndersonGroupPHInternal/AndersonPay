(function () {
    'use strict';

    angular
        .module('App')
        .controller('TaxTypeController', TaxTypeController);

    TaxTypeController.$inject = ['$filter', '$window', 'TaxTypeService'];

    function TaxTypeController($filter, $window, TaxTypeService) {
        var vm = this;

        vm.TaxTypes;
        vm.TaxTypeId;
        vm.TaxTypeName;
        vm.Initialise = Initialise;

        function Initialise(taxTypeId) {
            Read();
            vm.TaxTypeId = taxTypeId;
        }

        function Read() {
            TaxTypeService.Read()
                .then(function (response) {
                    vm.TaxTypes = response.data;
                    var taxType = $filter('filter')(vm.TaxTypes, { TaxTypeId: vm.TaxTypeId })[0];
                    if (taxType)
                        vm.TaxType = taxType;
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