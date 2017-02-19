using System.Linq;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.Identity;
using AcademiaLevel2.Models;
using System.Web.ModelBinding;
using AcademiaLevel2.Controllers;
using System.Threading.Tasks;

namespace SignalRMvc.Hubs
{
    public class LikeHub : Hub
    {
        public Task JoinRoom(string groupName)
        {
            return Groups.Add(Context.ConnectionId, groupName);
        }

        public Task LeaveRoom(string groupName)
        {
            return Groups.Remove(Context.ConnectionId, groupName);
        }

        public void Like(int idPost)
        {
           
            PostsController post = new PostsController();
            Notification notif = new Notification();
            notif.idPost = idPost;
            notif.userName = Context.User.Identity.GetUserName(); 

            var currentUserId =  Context.User.Identity.GetUserId();
            post.CreateLike(idPost, currentUserId);

            Clients.Client(Context.ConnectionId).isLike(idPost);
            Clients.Group("online").Like(idPost);
            Clients.Group("online", Context.ConnectionId).updateNotification(notif);
            //Clients.All.Like(idPost);
        }
        public struct Notification
        {
            public int idPost;
            public string userName;
        };
        public void DisLike(int idPost)
        {
            PostsController post = new PostsController();
            var currentUserId = Context.User.Identity.GetUserId();
            post.DeleteLike(idPost, currentUserId);
            Clients.Client(Context.ConnectionId).notLike(idPost);
            Clients.Group("online").DisLike(idPost);
            //Clients.All.DisLike(idPost);
        }
    }
}