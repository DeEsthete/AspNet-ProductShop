using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNet_FirstLesson.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        //это наз. action
        public ActionResult Index()
        {
            return View();
        }
        public string Test()
        {
            return "Test";
        }
    }
}