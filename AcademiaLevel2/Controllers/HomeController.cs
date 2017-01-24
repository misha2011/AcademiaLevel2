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
            ViewBag.id = id;
            var friends = db.Friends.Where(v => v.userThis.Id == id || v.userAnother.Id == id)                
                .Include(u => u.userThis).Include(x => x.userAnother);
            return View(friends);
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