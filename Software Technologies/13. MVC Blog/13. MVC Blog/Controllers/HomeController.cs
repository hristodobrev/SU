using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace _13.MVC_Blog.Controllers
{
    using Models;

    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        public ActionResult Index()
        {
            ViewBag.SidebarPosts = db.Posts.OrderByDescending(p => p.Date).Take(5).ToList();
            var posts = db.Posts.Include(path => path.Author).OrderByDescending(p => p.Date).Take(3);
            return View(posts.ToList());
        }
    }
}