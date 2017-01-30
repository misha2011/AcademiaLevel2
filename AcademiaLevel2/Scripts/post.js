$(function () {
    $("#send").click(function () {
        var post =
        {
            Title: $("#Title").val(),
            Description: $("#Description").val()
        };
        $.ajax(
         {
             type: "POST",
             url: "/Posts/Create",
             data: post,
             success: function (data) {
                 $("#addNewPost").append(data)
             }
         });
    });


    $("body").on('click', '.button-del', function () {
        var test = $(this).attr("id");
        test = test.replace("delete-", "");
        var post =
       {
           postId: parseInt(test),
       };
        $.ajax(
         {
             type: "POST",
             url: "/Posts/DeleteConfirmed",
             data: post,
             success: function () {
                 $("#" + test).remove();
             }
         });

    });
    var idPost = null;
    $("body").on('click', '.button-edit', function () {
        $("#popup1").show();
        idPost = $(this).attr("id");
        idPost = idPost.replace("edit-", "");
        var title = $('#title-' + idPost).text();
        var description = $('#description-' + idPost).text();
        $('#title-edit').val(title);
        $('#description-edit').val(description);

    })
    $("#edit").click(function () {
        var post = {
            Title: $('#title-edit').val(),
            Description: $('#description-edit').val(),
            Id: idPost,

        }
        $.ajax(
           {
               type: "POST",
               url: "/Posts/Edit",
               data: post,
               success: function (data) {
                   var title = $('#title-edit').val();
                   var description = $('#description-edit').val();
                   $("#popup1").hide();
                   $('#title-' + idPost).text(title);
                   $('#description-' + idPost).text(description);
               }
           });
    })

});


