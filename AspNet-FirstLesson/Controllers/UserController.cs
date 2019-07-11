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
    public class UserController : Controller
    {
        ProductContext db = new ProductContext();

        // GET: User
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User user)
        {
            User user1 = db.Users.FirstOrDefault(u => u.Login == user.Login);

            if (user1 != null)
            {
                db.Users.Add(user1);
                db.SaveChanges();
                return new RedirectResult("~/Home/Index");
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
    }
}