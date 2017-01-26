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
                    console.log(data.data);                   
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
            console.log(Id);
            return $http.post("/Posts/Delete", { postId: Id }).then(function (data) {
                $('#' + Id).detach();

            });
        };

        factory.editPost = function (Id) {
            console.log(Id);
            return $http.post("/Posts/Edit", { postId: Id, postTitle: Title, postContent: Content }).then(function (data) {

            });
        };

        return factory;
    }


    postService.$inject = ['$http'];
    angular.module('post.service', [])
        .factory('postService', postService);
})();