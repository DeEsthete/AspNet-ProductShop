using AspNet_FirstLesson.Data;
using AspNet_FirstLesson.Interfaces;
using AspNet_FirstLesson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace AspNet_FirstLesson.Controllers
{
    public class UserController : Controller
    {
        readonly IRepository<User> userRepository;

        public UserController(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

        public ActionResult SignUp()
        {
            return View();
        }

        public ActionResult SuccessfulRegistration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User user)
        {
            if (ModelState.IsValid)
            {
                User user1 = userRepository.GetAll().FirstOrDefault(u => u.Login == user.Login);
                if (user1 == null)
                {
                    userRepository.Add(user);
                    return new RedirectResult("~/User/SuccessfulRegistration");
                }
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            }
            return View("SignUp");
        }
    }
}