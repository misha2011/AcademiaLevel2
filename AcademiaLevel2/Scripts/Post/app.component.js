(function () {
    'use strict';

    function homeController(homeService) {
        var vm = this;
        vm.text = "test";
        vm.users = homeService.gethomeResults();

        vm.getResults = function () {
            homeService.gethomeResults().success(function (data) {
                vm.users = data;
                console.log("get users");
            });
        }

        vm.getResults();
    }

    homeController.$inject = ['homeService'];

    angular
        .module('app.home', [])
        .component('homeComponent', {
            templateUrl: '/Scripts/Angular/Home/homeTest.html',
            controller: homeController,
            bindings: {

            }
        });
})()