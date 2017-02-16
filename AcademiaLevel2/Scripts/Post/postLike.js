(function () {
    'use strict';
    function postLike(postService) {
        return {

            link: function (scope, element, attrs) {
                var idPost = attrs.id;
                element.bind('click', function () {
                    if (scope.isLike) {
                        postService.deleteLike(idPost);
                        scope.isLike = false;
                        scope.count -= 1;
                    } else {
                        postService.createLike(idPost);
                        scope.count += 1;
                        scope.isLike = true;

                    }
                });
            }
        };
    }
    postLike.$inject = ['postService'];
    angular.module('post.directiveLike', [])
    .directive('postLike', postLike);
})();