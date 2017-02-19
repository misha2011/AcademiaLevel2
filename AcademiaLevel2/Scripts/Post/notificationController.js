angular.module('postApp').controller('notificationController', function (realtimeService, postService) {
    $('span.noti').click(function (e) {
        e.stopPropagation();
        var count = 0;
        count = parseInt($('span.count').html()) || 0;
        if (count > 0) {
            $('.noti-content').show();
        }                
    })
  
    $('html').click(function () {           
            $('.noti-content').hide();

    })
    $('.noti-content').click(function () {
        var count = 0;
        $('#notiContent').empty();
        $('span.count').html(count);
    });
    realtimeService.on("updateNotification", function (notif) {
        var count = 0;
            count = parseInt($('span.count').html()) || 0;
            count++;
            $('span.count').html(count);
            var title;           
            postService.postResults.forEach(function (item, i) {
                if (item.Id === notif.idPost) {
                    $('#notiContent').append($('<li>' + notif.userName + ' like "' + item.Title + '"</li>'));
               }
            });
           
           
        });
});