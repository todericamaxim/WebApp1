using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            var c = db.Category.ToList();

            return View(c);
        }

        public ActionResult Edit(int id)
        {
            var a = db.Category.Where(x => x.Id == id).FirstOrDefault();

            return View(a);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            var cat = db.Category.Where(x => x.Id == category.Id).FirstOrDefault();
            cat.Name = category.Name;
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            db.Category.Add(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Login()
        { return View(); }

        [HttpPost]
        public ActionResult Login(User user)
        {
            db.User.Add(user);
            db.SaveChanges();
            return RedirectToAction("Users");
        }


        NewEntities2 db = new NewEntities2();
        [HttpGet]
        public ActionResult Index2()
        {
            var a = db.User.ToList();
            return View(a);
        }

        [HttpGet]
        public ActionResult DeleteUser(int id)
        {
            var a = db.User.Where(x => x.User_Id == id).FirstOrDefault();

            return View(a);
        }
        [HttpPost]
        public ActionResult DeleteUser(User user)
        {
            var a = db.User.Where(x => x.User_Id == user.User_Id).FirstOrDefault();
            
                db.User.Remove(a);
                db.SaveChanges();
            
            
            return RedirectToAction("Index2");
        }

        [HttpPost]
        public ActionResult Delete(Category category)
        {
            var cat1 = db.Category.Where(x => x.Id == category.Id).FirstOrDefault();

            db.Category.Remove(cat1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

             [HttpGet]
        public ActionResult Delete(int? id)
        {
            var cat1 = db.Category.Where(x => x.Id == id).FirstOrDefault();
            return View(cat1);
        }

        
    }
}