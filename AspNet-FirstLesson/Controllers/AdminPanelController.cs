using AspNet_FirstLesson.Data;
using AspNet_FirstLesson.Interfaces;
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
        IRepository<Product> productRepository;
        IRepository<Category> categoryRepository;
        IRepository<Role> roleRepository;
        IRepository<Producer> producerRepository;

        public AdminPanelController(IRepository<Product> productRepository, IRepository<Category> categoryRepository, 
            IRepository<Role> roleRepository, IRepository<Producer> producerRepository)
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
            this.roleRepository = roleRepository;
            this.producerRepository = producerRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        #region Gets
        [HttpGet]
        public ActionResult AddProduct()
        {
            ViewBag.Categories = categoryRepository.GetAll();
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
            ViewBag.Categories = categoryRepository.GetAll();
            ViewBag.Products = productRepository.GetAll().Where(c => c.CategoryId == id);
            if (id == null)
            {
                ViewBag.Products = productRepository.GetAll().ToList();
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditProduct(int? id)
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
        #endregion

        #region Posts
        [HttpPost]
        public ActionResult CreateRole(Role role)
        {
            if (roleRepository.GetAll().FirstOrDefault(r => r.Name == role.Name) == null && ModelState.IsValid)
            {
                roleRepository.Add(role);
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
            if (producerRepository.GetAll().FirstOrDefault(p => p.Name == producer.Name) == null && ModelState.IsValid)
            {
                producerRepository.Add(producer);
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
                categoryRepository.Add(category);
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
                productRepository.Add(product);
                return new RedirectResult("~/Product/GetProducts");
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        public ActionResult EditProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                productRepository.Edit(product);
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