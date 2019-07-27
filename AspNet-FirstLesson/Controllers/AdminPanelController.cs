using AspNet_FirstLesson.Data;
using AspNet_FirstLesson.Interfaces;
using AspNet_FirstLesson.Models;
using AspNet_FirstLesson.ViewModels;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AspNet_FirstLesson.Controllers
{
    [Authorize(Roles = "creator,admin")]
    public class AdminPanelController : Controller
    {
        readonly IRepository<Product> productRepository;
        readonly IRepository<Category> categoryRepository;
        readonly IRepository<Producer> producerRepository;

        private AppRolesManager RolesManager => HttpContext.GetOwinContext().GetUserManager<AppRolesManager>();
        private AppUserManager UserManager => HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        public AdminPanelController(IRepository<Product> productRepository, IRepository<Category> categoryRepository, 
            IRepository<Producer> producerRepository)
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
            this.producerRepository = producerRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        #region User
        [HttpGet]
        public ActionResult EditUsers()
        {
            ViewBag.Users = UserManager.Users.ToList();
            return View();
        }

        [HttpGet]
        public ActionResult EditUser(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                ViewBag.Roles = RolesManager.Roles.ToList();
                var user = new EditViewModel(UserManager.Users.FirstOrDefault(u => u.Id == id));
                return View(user);
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public ActionResult EditUser(EditViewModel user)
        {
            if (ModelState.IsValid)
            {
                var updateUser = UserManager.Users.FirstOrDefault(p => p.Id == user.Id);
                updateUser.UserName = user.UserName;
                updateUser.Email = user.Email;
                updateUser.Country = user.Country;
                updateUser.BirthDate = user.BirthDate;
                var roles = UserManager.GetRoles(updateUser.Id);
                UserManager.RemoveFromRole(updateUser.Id, roles.First());
                UserManager.AddToRole(updateUser.Id, RolesManager.FindById(user.RoleId.ToString()).Name);
                UserManager.Update(updateUser);
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
    }
}