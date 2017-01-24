(function () {
    angular.module('app.home', [])
        .config(['$stateProvider', function ($stateProvider) {
            $stateProvider.state('home', {
                url: "/Posts",
                template: '<home-component></home-component>',
                data: {
                    pageTitle: 'Posts',
                }
            });

        }]);
})();
