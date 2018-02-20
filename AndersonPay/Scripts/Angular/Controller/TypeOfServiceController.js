(function () {
    'use strict';

    angular
        .module('App')
        .controller('TypeOfServiceController', TypeOfServiceController);

    TypeOfServiceController.$inject = ['$filter', '$window', 'TypeOfServiceService', 'ServiceService'];

    function TypeOfServiceController($filter, $window, TypeOfServiceService, ServiceService) {
        var vm = this;

        vm.TypeOfServices = [];
        vm.Services = [];

        vm.GoToUpdatePage = GoToUpdatePage;
        vm.Initialise = Initialise;
        vm.UpdateService = UpdateService;

        vm.Delete = Delete;

        function GoToUpdatePage(typeOfServiceId) {
            $window.location.href = '../TypeOfService/Update/' + typeOfServiceId;
        }

        function Initialise() {

            Read();
        }

        function Read() {
            TypeOfServiceService.Read()
                .then(function (response) {
                    vm.TypeOfServices = response.data;
                    ReadForService();
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

        function Delete(typeOfService) {
            TypeOfServiceService.Delete(typeOfService)
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
                    UpdateService();
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

        function UpdateService()
        {
            angular.forEach(vm.TypeOfServices, function (typeOfService) {
                typeOfService.Service = $filter('filter')(vm.TypeOfServices, { TypeOfServiceId: typeOfService.TypeOfServiceId })[0];
            });
        }

    }
})();