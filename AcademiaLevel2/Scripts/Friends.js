$(function () {
    $("body").on('click', '.btn-add', function ()    
    {
        var idUserFull = $(this).attr("id");
        var idFrend = idUserFull.replace("add-", "");
        var friends =
       {
           idFrend: idFrend,
           status: "friend",
       };
        $.ajax(
           {
               type: "POST",
               url: "/Friends/Update",
               data: friends,
               success: function () {
                   $("#" + idUserFull).replaceWith("<button type='submit' id='delete-" + idFrend + "' class='btn-delete btn btn-default button'>Delete friend</button>");
               }
           });        
    });
    $("body").on('click', '.btn-delete', function ()  
    {
        var idUserFull = $(this).attr("id");
        var idFriend = idUserFull.replace("delete-", "");
        var friends =
       {
           idFriend: idFriend
       };
        $.ajax(
           {
               type: "POST",
               url: "/Friends/Delete",
               data: friends,
               success: function (userAnother_id) {
                   $("#" + idUserFull).replaceWith("<button type='submit' id='follow-" + userAnother_id + "' class='btn-follow btn btn-default button'>Follow</button>");
               }
           });
    });
    $("body").on('click', '.btn-follow', function ()        
        {
        var idUserFull = $(this).attr("id");        
        var userAnother_id = idUserFull.replace("follow-", "");
        var friends =
       {
           userAnother_id: userAnother_id
       };
        $.ajax(
           {
               type: "POST",
               url: "/Friends/Create",
               data: friends,
               success: function (idFriends) {                   
                   $("#" + idUserFull).replaceWith("<button type='submit' id='delete-" + idFriends + "' class='btn-delete btn btn-default button'>Unfollow</button>");
               }
           });
    });
});
