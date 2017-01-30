(function () {
    'use strict';
    function postService($http) {
        var factory = {};
        factory.noResults = false;
        factory.skipPost = 0;
        factory.postResults = [];

        factory.getpostResults = function () {
            if (!factory.noResults)
                return $http.post("/Posts/GetPost", { index: factory.skipPost, count: 10 }).then(function (data) {                                    
                    if (data.data.length === 0) {
                        factory.noResults = true;
                        return;
                    }
                    data.data.forEach(function (elem, index, array) {
                        var date = elem.Date;
                        var res = date.replace(/[A-z]/g, "").replace('/', "").replace("(", "").replace(")", "").replace('/', "");
                        elem.Date = res;
                    });
                    factory.postResults.push.apply(factory.postResults, data.data);

                });
        };

        factory.deletePost = function (Id) {
            return $http.post("/Posts/DeleteConfirmed", { postId: Id }).then(function (data) {
                $('#' + Id).detach();
            });
        };

        factory.editPost = function (post) {
            return $http.post("/Posts/Edit", { Post: post }).then(function () {
                $('#title-' + post.Id).text(post.Title);
                $('#description-' + post.Id).text(post.Description);
            });
        };

        return factory;
    }


    postService.$inject = ['$http'];
    angular.module('post.service', [])
        .factory('postService', postService);
})();