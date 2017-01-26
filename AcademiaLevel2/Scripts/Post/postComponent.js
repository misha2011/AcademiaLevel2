(function () {
    'use strict';

    function postController(postService, $scope) {
        //, $uibModal
        var vm = this;
        vm.servis = postService;
        vm.getResults = function () {
            postService.getpostResults();
        };


        vm.deleteResults = function (Id) {
            console.log(Id);
            postService.deletePost(Id);
        };


        //vm.open = function () {
        //    var modalInstance = $uibModal.open({
        //        animation: vm.animationsEnabled,
        //        templateUrl: '/Scripts/Post/Template/editPost.html',
        //        controller: 'PostsController',
        //        resolve: {

        //        }

        //    });
        //};

        vm.editResults = function (Id, Title, Content) {
            console.log(Id);
            postService.editPost(Id, Title, Content);
        };
        vm.getResults();
        // vm.deleteResults();
    }

    postController.$inject = ['postService', '$scope'];
    // '$uibModal',
    //modalInstance.$inject = ['postService', ' $uibModal', '$scope'];

    angular
        .module('postApp', [])
        .component('postComponent', {
            templateUrl: '/Scripts/Post/Template/topPost.html',
            controller: postController,
            bindings: {

            }
        });
})();


//(function () {
//    'use strict';

//    function homeController(homeService) {
//        var vm = this;
//        vm.text = "test";
//        vm.users = homeService.gethomeResults();

//        vm.getResults = function () {
//            homeService.gethomeResults().success(function (data) {
//                vm.users = data;
//                console.log("get users");
//            });
//        }

//        vm.getResults();
//    }

//    homeController.$inject = ['homeService'];

//    angular
//        .module('app.home', [])
//        .component('homeComponent', {
//            templateUrl: '/Scripts/Angular/Home/homeTest.html',
//            controller: homeController,
//            bindings: {

//            }
//        });
//})()