using AspNet_FirstLesson.Data;
using AspNet_FirstLesson.Interfaces;
using AspNet_FirstLesson.Models;
using AspNet_FirstLesson.ViewModels;
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
        IRepository<User> userRepository;

        public AdminPanelController(IRepository<Product> productRepository, IRepository<Category> categoryRepository, 
            IRepository<Role> roleRepository, IRepository<Producer> producerRepository, IRepository<User> userRepository)
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
            this.roleRepository = roleRepository;
            this.producerRepository = producerRepository;
            this.userRepository = userRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        #region User
        [HttpGet]
        public ActionResult EditUsers()
        {
            ViewBag.Users = userRepository.GetAll();
            return View();
        }

        [HttpGet]
        public ActionResult EditUser(int? id)
        {
            if (id != null)
            {
                return View(userRepository.GetEntity(id.Value));
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public ActionResult EditUser(User user)
        {
            if (ModelState.IsValid)
            {
                userRepository.Edit(user);
                return new RedirectResult("~/AdminPanel/EditUsers");
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
        #endregion

        #region Product
        [HttpGet]
        public ActionResult AddProduct()
        {
            ViewBag.Categories = categoryRepository.GetAll();
            ViewBag.Producers = producerRepository.GetAll();
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

        #region Producer
        [HttpGet]
        public ActionResult AddProducer()
        {
            return View();
        }

        [HttpGet]
        public ActionResult EditProducers()
        {
            ViewBag.Producers = producerRepository.GetAll();
            return View();
        }

        [HttpGet]
        public ActionResult EditProducer(int? id)
        {
            if (id != null)
            {
                ViewBag.Producer = producerRepository.GetEntity(id.Value);
                return View();
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
        public ActionResult EditProducer(Producer producer)
        {
            if (ModelState.IsValid)
            {
                producerRepository.Edit(producer);
                return new RedirectResult("~/AdminPanel/EditProducers");
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
        #endregion

        #region Category
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
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
        #endregion

        #region Role
        [HttpGet]
        public ActionResult AddRole()
        {
            return View();
        }

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
        #endregion
    }
}