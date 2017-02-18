(function () {
    'use strict';
    function realtimeService($rootScope) {
        var userActivity = $.connection.likeHub;
        $.connection.hub.start()
        .done(function () {
            userActivity.invoke("joinRoom", "online");
            console.log('Connected to Realtime hub !!!');
        })
        .fail(function () { console.log('Could not Connect!'); });
        return {
            on: function (eventName, callback) {
                userActivity.on(eventName, function (result) {
                    $rootScope.$apply(function () {
                        if (callback) {
                            callback(result);
                        }
                    });
                });
            },
            off: function (eventName, callback) {
                userActivity.off(eventName)//, function (result) { 
                // console.log('done - off'); 
                //$rootScope.$apply(function () { 
                // if (callback) { 
                // callback(result); 
                // } 
                //}); 
                //}); 
            },
            invoke: function (methodName, args, callback) {
                $.connection.hub.start().done(function () {
                    userActivity.invoke(methodName, args)
                    .done(function (result) {
                        $rootScope.$apply(function () {
                            if (callback) {
                                callback(result);
                            }
                        });
                    });
                });
            }
        };
    };
    realtimeService.$inject = ['$rootScope'];
    angular
        .module('RealTime', [])
        .factory('realtimeService', realtimeService);
})();