(function () {
    'use strict';
    function postService($http) {
        var factory = {};
        factory.noResults = false;
        factory.skipPost = 0;
        factory.newPost = 0;
        factory.postResults = [];

        factory.getpostResults = function () {
            if (!factory.noResults)
                return $http.post("/Posts/GetPost", { index: factory.skipPost, count: factory.count, newPost: factory.newPost }).then(function (data) {
                    if (data.data.length === 0) {
                        factory.noResults = true;
                       
                    }
                    data.data.forEach(function (elem, index, array) {
                        var date = elem.Date;
                        var res = date.replace(/[A-z]/g, "").replace('/', "").replace("(", "").replace(")", "").replace('/', "");
                        elem.Date = res;
                    });
                    factory.postResults.push.apply(factory.postResults, data.data);

                });
        };

        factory.postSend = function (post) {
            return $http.post("/Posts/Create", { post: post }).then(function (data) {
                console.log(data);
                data.data.Date = data.data.Date.replace(/[A-z]/g, "").replace('/', "").replace("(", "").replace(")", "").replace('/', "");
                factory.postResults.unshift(data.data);
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

        factory.createLike = function (idPost) {
            return $http.post("/Posts/CreateLike", { idPost: idPost }).then(function (data) {
                console.log("Likenuto");
            });
        };

        factory.deleteLike = function (idPost) {
            return $http.post("/Posts/DeleteLike", { idPost: idPost }).then(function (data) {
                console.log("Likenuto");
            });
        };

        return factory;
    }

    postService.$inject = ['$http'];
    angular.module('post.service', [])
        .factory('postService', postService);
})();