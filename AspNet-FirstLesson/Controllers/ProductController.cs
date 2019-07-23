using AspNet_FirstLesson.Data;
using AspNet_FirstLesson.Interfaces;
using AspNet_FirstLesson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace AspNet_FirstLesson.Controllers
{
    public class ProductController : Controller
    {
        IRepository<Product> productRepository;
        IRepository<Category> categoryRepository;

        public ProductController(IRepository<Product> productRepository, IRepository<Category> categoryRepository)
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
        }

        public ViewResult Index()
        {
            ViewBag.Title = "ProductShop.com";
            return View();
        }

        public ActionResult GetProduct(int? id)
        {
            Product product = null;
            if (id != null)
            {
                product = productRepository.GetAll().FirstOrDefault(p => p.Id == id);
            }
            if (product != null)
            {
                ViewBag.Product = product;
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            return View();
        }

        public ActionResult AddToBasket(int? id)
        {
            if (id != null)
            {

                return new RedirectResult("~/Product/GetProduct/" + id.Value);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
        }

        public ViewResult GetProducts(int? id)
        {
            ViewBag.Categories = categoryRepository.GetAll().ToList();
            ViewBag.Products = productRepository.GetAll().Where(c => c.CategoryId == id);
            ViewBag.ThisCategory = id;
            if (id == null)
            {
                ViewBag.Products = productRepository.GetAll().ToList();
            }
            return View();
        }

        public void LookButton_Click(int id)
        {
            GetProduct(id);
        }
    }
}