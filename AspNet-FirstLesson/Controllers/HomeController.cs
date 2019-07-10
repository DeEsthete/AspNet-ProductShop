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
        public string Index()
        {
            return "HelloWorld";
        }
        public string Test()
        {
            return "Test";
        }
    }
}