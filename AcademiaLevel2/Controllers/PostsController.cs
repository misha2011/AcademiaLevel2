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
using System.Reflection.Emit;

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

      

        [HttpPost]
        public JsonResult GetPost(int index = 0, int count = 10)
        {
            var currentUserId = User.Identity.GetUserId();
            var data = db.Post.Include(p => p.IdUser).Include(p => p.likes)
                .OrderByDescending(p => p.Date).ToList()
               .Skip(index * count)
               .Take(count).ToList();

            foreach (var post in data)
            {
                foreach (var Likes in post.likes)
                {
                    if (Likes.iduser.Id == currentUserId)
                    {
                        post.isLike = true;
                    }
                };

            };
            return new JsonResult() { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        // GET: Post/CreatуLikes create Likes
        public void CreateLike(int idPost)
        {
            var currentUserId = User.Identity.GetUserId();
            Likes like = new Likes();
            like.iduser = db.Users.FirstOrDefault(x => x.Id == currentUserId);
            like.idPost = idPost;
            if (ModelState.IsValid)
            {
                db.Likes.Add(like);
                db.SaveChanges();
            }

        }

        // GET: Post/CreatуLikes create Likes
        public void DeleteLike(int idPost)
        {
            Post Post = db.Post.FirstOrDefault(x => x.Id == idPost);
            db.Post.Remove(Post);
            db.SaveChanges();

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
     
        // POST: Post/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]

        public void Edit(Post Post)
        {
            Post.Date = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(Post).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        // GET: Post/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Post Post = db.Post.Find(id);
        //    if (Post == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(Post);
        //}

        // POST: Post/Delete/5
        [HttpPost]
        public void DeleteConfirmed(int postId)
        {
            Post Post = db.Post.FirstOrDefault(x => x.Id == postId);
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
