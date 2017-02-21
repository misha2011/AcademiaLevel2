(function () {
    'use strict';
    function postController(postService, $scope, $uibModal, realtimeService) {
        var vm = this;

        vm.send = function () {
            vm.post = {
                title : $scope.inputTitle,
                description : $scope.inputDescription
            };
            var regex = /^[ a-zA-Z0-9@]+$/;            
            if (vm.post.title == null || vm.post.description == null || regex.test(vm.post.title) !== true || regex.test(vm.post.description) !== true) {
                alert("complete the form");
               
            } else {
                postService.postSend(vm.post);
                postService.newPost += 1;
                $scope.inputTitle = null;
                $scope.inputDescription = null;
            };
           
        };
        realtimeService.on("like", function (data) {
            postService.postResults.forEach(function (item, i) {
                if (item.Id===data) {
                    item.likes.length += 1;
                }
            });
        });
        realtimeService.on("disLike", function (data) {
            postService.postResults.forEach(function (item, i) {
                if (item.Id === data) {
                    item.likes.length -= 1;
                }
            });
        });
        realtimeService.on("isLike", function (data) {
            postService.postResults.forEach(function (item, i) {
            if (item.Id === data) {
                    item.isLike = true;
                }
            });
        });
        realtimeService.on("notLike", function (data) {
            postService.postResults.forEach(function (item, i) {
                if (item.Id === data) {
                    item.isLike = false;
                }
            });
        });

        vm.like = function (idPost) {
            realtimeService.invoke("Like", idPost);
        };
        vm.disLike = function (idPost) {
            realtimeService.invoke("disLike", idPost);
        };



        vm.servis = postService;
        vm.getResults = function () {
            postService.getpostResults();
        };
        vm.deleteResults = function (Id) {
            postService.deletePost(Id);
            postService.newPost -= 1;
        };        
        vm.animationsEnabled = true;
        vm.open = function (Id) {
            vm.postOld = {
                postId: Id,
                title: $('#title-' + Id).text(),
                description: $('#description-' + Id).text()
            };
            var modalInstance = $uibModal.open({
                animation: vm.animationsEnabled,
                ariaLabelledBy: 'modal-title',
                ariaDescribedBy: 'modal-body',
                templateUrl: 'myModalContent.html',
                controller: 'ModalInstanceCtrl',
                controllerAs: 'vm',
                size: 'sm',
                resolve: {
                    postOld: function () {
                        return vm.postOld;
                    }
                }
            });

        };
        vm.editResults = function (Id, Title, Content) {
            console.log(Id);
            postService.editPost(Id, Title, Content);
        };
        vm.getResults();
    }
   
    postController.$inject = ['postService', '$scope', '$uibModal', 'realtimeService'];
   
    angular
        .module('postApp', [])
        .component('postComponent', {
            templateUrl: '/Scripts/Post/Template/topPost.html',
            controller: postController,
            bindings: {

            }
        });
})();



angular.module('postApp').controller('ModalInstanceCtrl', function ($uibModalInstance, postOld, $scope, postService) {
    var vm = this;
    $scope.title = postOld.title;
    $scope.description = postOld.description;
    vm.ok = function () {
        vm.post = {
            Id: postOld.postId,
            Title: $scope.title,
            Description: $scope.description
        };
        var regex = /^[ a-zA-Z0-9@]+$/;            
        if (vm.post.Title == null || vm.post.Description == null || regex.test(vm.post.Title) !== true || regex.test(vm.post.Description) !== true) {
            alert("complete the form");

        } else {
            postService.editPost(vm.post);
            $uibModalInstance.close();
        }
    };

    vm.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
});