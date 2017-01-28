using AcademiaLevel2.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;



namespace AcademiaLevel2.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {

            var id = User.Identity.GetUserId();
            string query = "SELECT  Friends.UserThis_Id, AspNetUsers.Id ,AspNetUsers.FirstName, AspNetUsers.LastName,AspNetUsers.Email,Friends.status, Friends.idFriends" +
                " FROM AspNetUsers" +
                " LEFT JOIN Friends " +
                " ON ((UserThis_Id = '" + id + "'  and UserAnother_Id = AspNetUsers.Id ) or (UserAnother_Id = '" + id + "' and UserThis_Id = AspNetUsers.Id)) where AspNetUsers.Id not like" + "'%" + id + "%'";
            //string query = "select u.Id ,u.FirstName,u.LastName,u.Email, f.status, f.id from AspNetUsers as u Left join Friends as f on(f.UserThis_Id = " + "'" + id + "'" + "and f.UserAnother_Id = u.Id) where u.Id not like" + "'%" + id + "%'";
            var data = db.Database.SqlQuery<FriendView>(query).ToList();
            string x = null;
            var d = 1;
            //var id = User.Identity.GetUserId();
            //ViewBag.id = id;
            //var friends = db.Friends.Where(v => v.userThis.Id == id || v.userAnother.Id == id)                
            //    .Include(u => u.userThis).Include(x => x.userAnother);
            return View(data);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}