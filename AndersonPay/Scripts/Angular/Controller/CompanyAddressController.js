(function () {
    'use strict';

    angular
        .module('App')
        .controller('CompanyAddressController', CompanyAddressController);

    CompanyAddressController.$inject = ['$filter', '$window', 'CompanyAddressService'];

    function CompanyAddressController($filter, $window, CompanyAddressService) {
        var vm = this;

        vm.CompanyAddresses;
        vm.CompanyAddressId;
        vm.Initialise = Initialise;

        function Initialise(companyAddressId) {
            Read();
            vm.CompanyAddressId = companyAddressId;
        }

        function Read() {
            CompanyAddressService.Read()
                .then(function (response) {
                    vm.CompanyAddresses = response.data;
                    var companyAddress = $filter('filter')(vm.CompanyAddresses, { CompanyAddressId: vm.CompanyAddressId })[0];
                    if (companyAddress)
                        vm.CompanyAddress = companyAddress;
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