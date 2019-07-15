using AspNet_FirstLesson.Data;
using AspNet_FirstLesson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AspNet_FirstLesson.Controllers
{
    public class AdminPanelController : Controller
    {
        ProductContext db = new ProductContext();

        public ActionResult Index()
        {
            return View();
        }

        #region Gets
        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddProducer()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddRole()
        {
            return View();
        }

        [HttpGet]
        public ActionResult EditProducts(int? id)
        {
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Products = db.Products.Where(c => c.CategoryId == id);
            if (id == null)
            {
                ViewBag.Products = db.Products.ToList();
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditProduct(int? id)
        {
            return View();
        }
        #endregion

        #region Posts
        [HttpPost]
        public ActionResult CreateRole(Role role)
        {
            if (db.Roles.FirstOrDefault(r => r.Name == role.Name) == null && ModelState.IsValid)
            {
                db.Roles.Add(role);
                db.SaveChanges();
                return new RedirectResult("~/AdminPanel/Index");
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        public ActionResult CreateProducer(Producer producer)
        {
            if (db.Producers.FirstOrDefault(p => p.Name == producer.Name) == null && ModelState.IsValid)
            {
                db.Producers.Add(producer);
                db.SaveChanges();
                return new RedirectResult("~/AdminPanel/Index");
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        public ActionResult CreateCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return new RedirectResult("~/AdminPanel/Index");
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return new RedirectResult("~/Product/GetProducts");
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
        #endregion
    }
}