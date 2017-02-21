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
using Microsoft.Ajax.Utilities;
using System.Collections.Generic;

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
        public JsonResult GetPost(int index = 0, int count = 10, int newPost = 0)
        {
            var currentUserId = User.Identity.GetUserId();
            var data = db.Post.Include(p => p.IdUser).Include(p => p.likes)
                .OrderByDescending(p => p.Date).ToList()
               .Skip(index * count + newPost)
               .Take(count).ToList();

            foreach (var post in data)
            {
                if (post.IdUser.Id == currentUserId)
                {
                    post.myPost = true;
                }
             foreach (var Likes in post.likes)
                {
                    if (Likes.iduser == currentUserId)
                    {
                        post.isLike = true;
                    }
                };
            };
            return new JsonResult() { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        // GET: Post/CreatуLikes create Likes
         public void CreateLike(int idPost,string currentUserId)
        {
            Likes likeIs = db.Likes.FirstOrDefault(x => x.idPost == idPost && x.iduser == currentUserId);
            if (likeIs != null)
            {
                return;
            }
            Likes like = new Likes();
            like.iduser = currentUserId;
            like.idPost = idPost;
            if (ModelState.IsValid)
            {
                db.Likes.Add(like);
                db.SaveChanges();
            }

        }

        // GET: Post/CreatуLikes create Likes
        public void DeleteLike(int idPost, string currentUserId)
        {
            Likes like = db.Likes.FirstOrDefault(x => x.idPost == idPost && x.iduser == currentUserId);
            if(like != null)
            {
                db.Likes.Remove(like);
                db.SaveChanges();
            }
            
        }

        // POST: Post/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]        
        public JsonResult Create(Post post)
        {
            var id = User.Identity.GetUserId();
            post.IdUser = db.Users.FirstOrDefault(x => x.Id == id);
            post.Date = DateTime.Now;
            List<Likes> like = new List<Likes>();
            post.likes = like;
            post.myPost = true;
           if (ModelState.IsValid)
            {
                db.Post.Add(post);
                db.SaveChanges();
            }
        return new JsonResult() { Data = post, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
     
        // POST: Post/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]

        public void Edit(Post Post)
        {
            //Post post = db.Post.Include(p => p.IdUser).FirstOrDefault(x => x.Id == Post.Id);
            //var id = User.Identity.GetUserId();
            //if (post.IdUser.Id != id)
            //{
            //    return;
            //}

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
            Post post = db.Post.Include(p => p.IdUser).FirstOrDefault(x => x.Id == postId);
            var id = User.Identity.GetUserId();
            if (post.IdUser.Id == id)
            {
                db.Post.Remove(post);
                db.SaveChanges();
            };
            
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
