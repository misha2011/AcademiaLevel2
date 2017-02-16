angular.module('app', [
    'postApp',
    'post.service',
    'post.directives',
    'post.directiveLike',
    'ngAnimate', 
    'ui.bootstrap'
])




//var app = angular.module('app', []);
//app.controller('DemoCtrl', function ($scope, $http) {

//    $http.get('/Posts/Test').then(successCallback, errorCallback);
//    function successCallback(data) {
//        console.log('this', data);
//        $scope.posts = data;
//    }
//    function errorCallback(error) {
//        console.log('this', error);
//    }

//    //Filter
//    var date = new Date();
//    $scope.today = date;
//});




