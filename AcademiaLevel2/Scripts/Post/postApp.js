(function () {
    angular.module('postApp', [])
        .config(['$stateProvider', function ($stateProvider) {
            $stateProvider.state('postApp', {
                url: "/Posts",
                template: '<post-component></post-component>',
                data: {
                    pageTitle: 'Posts',
                }
            });

        }]);
})();
