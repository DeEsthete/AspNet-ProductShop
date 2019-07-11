using AspNet_FirstLesson.Data;
using AspNet_FirstLesson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace AspNet_FirstLesson.Controllers
{
    public class ProductController : Controller
    {
        ProductContext db = new ProductContext();

        public ProductController()
        {
            db.Roles.ToList();
        }

        /*Заполнение БД начальными данными при переходе по пути: "/Product/FillBd"*/
        public string FillBd()
        {
            db.FillBd(db);
            return "БД успешно заполнена";
        }

        public ViewResult Index()
        {
            ViewBag.Title = "ProductShop.com";
            return View();
        }

        public ViewResult GetProduct(int id)
        {
            ViewBag.Product = db.Products.FirstOrDefault(p => p.Id == id);
            return View();
        }

        public ViewResult GetProducts()
        {
            ViewBag.Products = db.Products.ToList();
            return View();
        }

        public void LookButton_Click(int id)
        {
            GetProduct(id);
        }
    }
}