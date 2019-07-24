using AspNet_FirstLesson.Data;
using AspNet_FirstLesson.Interfaces;
using AspNet_FirstLesson.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
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
        IBasketRepository<Basket> userBasketRepository;

        private AppUserManager UserManager => HttpContext.GetOwinContext().GetUserManager<AppUserManager>();

        public ProductController(IRepository<Product> productRepository, IRepository<Category> categoryRepository, IBasketRepository<Basket> userBasketRepository)
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
            this.userBasketRepository = userBasketRepository;
        }

        public ViewResult Index()
        {
            ViewBag.Title = "ProductShop.com";
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult AddToBasket(int? id)
        {
            if (id != null)
            {
                Product product = productRepository.GetEntity(id.Value);
                if (product != null)
                {
                    User user = UserManager.FindByName(User.Identity.Name);
                    userBasketRepository.AddToBasket(user.BasketId.Value, id.Value);
                    return new RedirectResult("~/User/Basket/");
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [Authorize]
        [HttpGet]
        public ActionResult RemoveFromBasket(int?  id)
        {
            if (id != null)
            {
                Product product = productRepository.GetEntity(id.Value);
                if (product != null)
                {
                    User user = UserManager.FindByName(User.Identity.Name);
                    userBasketRepository.RemoveFromBasket(user.BasketId.Value, id.Value);
                    return new RedirectResult("~/User/Basket/");
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
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