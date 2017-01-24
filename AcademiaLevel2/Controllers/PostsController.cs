using Microsoft.AspNet.Identity;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AcademiaLevel2.Models;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace AcademiaLevel2.Controllers
{

    public class PostsController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Post
        public ActionResult Index()
        {
            return View(db.Post.ToList());
        }


        // GET: Post/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post Post = db.Post.Find(id);
            if (Post == null)
            {
                return HttpNotFound();
            }
            return View(Post);
        }

        // GET: Post/Create
       
        // GET: Post/Create create Post
        public ActionResult Create()
        {
            var id = User.Identity.GetUserId();
            var Post = db.Post.Where(v => v.IdUser.Id == id)
                .Include(u => u.IdUser);
            return View(Post);
        }
        public JsonResult Test()
        { 
            var results = db.Post.Include(u => u.IdUser).ToList();

            return new JsonResult() { Data = results, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        // POST: Post/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]        
        public ActionResult Create(Post Post)
        {
            var id = User.Identity.GetUserId();
            Post.IdUser = db.Users.FirstOrDefault(x => x.Id == id);
            Post.Date = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Post.Add(Post);
                db.SaveChanges();
            }
            return PartialView("PartialView", Post);
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post Post = db.Post.Find(id);
            if (Post == null)
            {
                return HttpNotFound();
            }
            return View(Post);
        }

        // POST: Post/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]

        public ActionResult Edit(Post Post)
        {
            Post.Date = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(Post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(Post);
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post Post = db.Post.Find(id);
            if (Post == null)
            {
                return HttpNotFound();
            }
            return View(Post);
        }

        // POST: Post/Delete/5
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public void DeleteConfirmed(int Id)
        {
            Post Post = db.Post.FirstOrDefault(x => x.Id == Id);
            db.Post.Remove(Post);
            db.SaveChanges();
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
