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
        List<Product> products = new List<Product>();

        public ProductController()
        {
            Product product = new Product { Id = 0, Name = "Хлеб", Price = 60, Producer = new Producer { Name = "Хлебозавод #1" } };
            Product product1 = new Product { Id = 1, Name = "Молоко", Price = 60, Producer = new Producer { Name = "Молокозавод #1" } };
            products.Add(product);
            products.Add(product1);
        }

        // GET: Product
        public ViewResult Index()
        {
            ViewBag.Title = "ProductShop.com";
            return View();
        }
        public ViewResult GetProduct(int id)
        {
            ViewBag.Product = products.FirstOrDefault(p => p.Id == id);
            //StringBuilder strBuild = new StringBuilder();
            //foreach(var i in products)
            //{
            //    strBuild.Append("<span style='color:green'>" + i.GetString() + "</span><br>");
            //}
            //return strBuild.ToString();
            return View();
        }
        public ViewResult GetProducts()
        {
            ViewBag.Products = products;
            return View();
        }

        public void LookButton_Click(int id)
        {
            GetProduct(id);
        }
    }
}