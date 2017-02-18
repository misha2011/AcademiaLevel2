(function () {
    'use strict';
    function postLike(postService, realtimeService) {
        return {
            link: function (scope, element, attrs) {
                var idPost = attrs.id;
                element.bind('click', function () {
                    if (scope.isLike) {
                        realtimeService.invoke("disLike", idPost);
                        //postService.deleteLike(idPost);
                        //scope.isLike = false;
                        //scope.count -= 1;
                    } else {
                        realtimeService.invoke("Like", idPost);
                        //postService.createLike(idPost);
                        //scope.count += 1;
                        //scope.isLike = true;

                    }
                });
            }
        };
    }
    postLike.$inject = ['postService', 'realtimeService'];
    angular.module('post.directiveLike', [])
    .directive('postLike', postLike);
})();