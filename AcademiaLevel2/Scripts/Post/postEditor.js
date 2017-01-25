(function () {
    'use strict';
    function postEditor(postService) {
        return {
            restrict: 'AE',
            scope: true,
            link: function (element, attrs, ngModel) {
                window.onscroll = function () {
                    if (!postService.noResults) {
                        if ($(window).scrollTop() + $(window).height() == $(document).height()) {
                            postService.skipPost += 1;
                            postService.getpostResults();
                        }
                    }
                };

            }
        };
    }
    postEditor.$inject = ['postService'];
    angular.module('post.directive', [])
    .directive('postEditor', postEditor);
})();