$(function () {
    $("body").on('click', '.btn-add', function ()    
    {
        var idUserFull = $(this).attr("id");
        var idUser = idUserFull.replace("add-", "");
        var friends =
       {
           id: parseInt(idUser),
           status: "friend",
       };
        $.ajax(
           {
               type: "POST",
               url: "/Friends/Update",
               data: friends,
               success: function () {
                   $("#" + idUserFull).replaceWith("<button type='submit' id='delete-" + idUser + "' class='btn-delete btn btn-default button'>Delete friend</button>");
               }
           });        
    });
    $("body").on('click', '.btn-delete', function ()  
    {
        var idUserFull = $(this).attr("id");
        var idUser = idUserFull.replace("delete-", "");
        var friends =
       {
           id: parseInt(idUser),
           status: "unknown",
       };
        $.ajax(
           {
               type: "POST",
               url: "/Friends/Update",
               data: friends,
               success: function () {
                   $("#" + idUserFull).replaceWith("<button type='submit' id='follow-" + idUser + "' class='btn-follow btn btn-default button'>Follow</button>");
               }
           });
    });
    $("body").on('click', '.btn-follow', function ()        
        {
        var idUserFull = $(this).attr("id");        
        var userAnother_id = idUserFull.replace("follow-", "");
        alert(userAnother_id);
        var friends =
       {
           userAnother_id: userAnother_id
       };
        $.ajax(
           {
               type: "POST",
               url: "/Friends/Create",
               data: friends,
               success: function () {
                   $("#" + idUserFull).replaceWith("<button type='submit' id='delete-" + userAnother_id + "' class='btn-delete btn btn-default button'>Unfollow</button>");
               }
           });
    });
    $("body").on('click', '.btn-followIn', function () {
        var idUserFull = $(this).attr("id");
        var idUser = idUserFull.replace("followIn-", "");
        var friends =
       {
           id: parseInt(idUser),
           status: "followIn",
       };
        $.ajax(
           {
               type: "POST",
               url: "/Friends/Update",
               data: friends,
               success: function () {
                   $("#" + idUserFull).replaceWith("<button type='submit' id='delete-" + idUser + "' class='btn-delete btn btn-default button'>Unfollow</button>");
               }
           });
    });

});


//$("body").on('click', '.btn-follow', function () {
//    var idUserFull = $(this).attr("id");
//    var idUser = idUserFull.replace("follow-", "");
//    var friends =
//   {
//       id: parseInt(idUser),
//       status: "followOut",
//   };
//    $.ajax(
//       {
//           type: "POST",
//           url: "/Friends/Update",
//           data: friends,
//           success: function () {
//               $("#" + idUserFull).replaceWith("<button type='submit' id='delete-" + idUser + "' class='btn-delete btn btn-default button'>Unfollow</button>");
//           }
//       });
//});