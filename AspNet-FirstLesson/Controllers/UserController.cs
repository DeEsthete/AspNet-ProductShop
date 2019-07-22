using AspNet_FirstLesson.Data;
using AspNet_FirstLesson.Interfaces;
using AspNet_FirstLesson.Models;
using AspNet_FirstLesson.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AspNet_FirstLesson.Controllers
{
    public class UserController : Controller
    {
        private AppUserManager UserManager => HttpContext.GetOwinContext().GetUserManager<AppUserManager>();

        private AppRolesManager RolesManager => HttpContext.GetOwinContext().GetUserManager<AppRolesManager>();

        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SignOut()
        {
            if (User.Identity.IsAuthenticated && User.Identity != null)
            {
                AuthenticationManager.SignOut();
            }
            return new RedirectResult("~/User/SignIn");
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SuccessfulRegistration()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UserInfo()
        {
            var user = UserManager.Users.FirstOrDefault(u => u.Id == User.Identity.GetUserId());
            if (user != null)
            {
                ViewBag.User = user;
            }
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SignIn(LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var user = UserManager.Users.FirstOrDefault(u => u.UserName == loginModel.Username);
                if (user == null)
                {
                    return new RedirectResult("/User/SignUp");
                }

                ClaimsIdentity claim = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                AuthenticationManager.SignOut();
                AuthenticationManager.SignIn(new AuthenticationProperties
                {
                    IsPersistent = true,
                }, claim);

                return new RedirectResult("/Product/GetProducts");
            }
            else
            {
                return View(loginModel);
            }
        }

        [HttpPost]
        public async Task<ActionResult> SignUp(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = model.Username, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    if (!UserManager.Users.Any())
                    {
                        UserManager.AddToRole(user.Id, "creator");
                    }
                    UserManager.AddToRole(user.Id, "user");
                    return new RedirectResult("/User/SuccessfulRegistration");
                }
                else
                {
                    return View(model);
                }
            }
            return View(model);
        }
    }
}