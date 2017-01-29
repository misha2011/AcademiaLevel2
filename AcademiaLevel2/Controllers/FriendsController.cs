using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AcademiaLevel2.Models;
using Microsoft.AspNet.Identity;

namespace AcademiaLevel2.Controllers
{
    public class FriendsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //POST: Friends/Update
        [HttpPost]
        public void Update (string idFrend, string status)
        {
            Friends friend = new Friends();
            friend.idFriends = idFrend;
            friend.status = status;
            if (ModelState.IsValid)
            {
                db.Entry(friend).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        // POST: Friends/Create      
        [HttpPost]      
        public string Create(string userAnother_id)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-_";
            var stringChars = new char[30];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);

            Friends friends = new Friends();
            friends.status = "follow";
            friends.idFriends = finalString;
            var userThis_id = User.Identity.GetUserId();
            friends.userThis = db.Users.FirstOrDefault(x => x.Id == userThis_id);
            friends.userAnother = db.Users.FirstOrDefault(x => x.Id == userAnother_id);
            if (ModelState.IsValid)
            {
                db.Friends.Add(friends);
                db.SaveChanges();
            }
            return finalString;
        }

        // POST: Friends/Delete/5
        [HttpPost]        
        public string Delete(string idFriend)
        {
            List<Friends> friend = db.Friends.Where(v => v.idFriends == idFriend)
                .Include(u => u.userAnother).ToList();
            Friends friends = friend.ElementAt(0);
            var userAnother_id = friends.userAnother.Id;
            db.Friends.Remove(friends);
            db.SaveChanges();
            return userAnother_id;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
