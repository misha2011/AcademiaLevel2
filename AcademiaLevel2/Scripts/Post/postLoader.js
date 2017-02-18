(function () {    
    'use strict'; 
    function postLoader(postService) {
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
    postLoader.$inject = ['postService'];
    angular.module('post.directives', [])
    .directive('postLoader', postLoader);
})();