using AspNet_FirstLesson.App_Start;
using Ninject;
using Ninject.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AspNet_FirstLesson
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var registrator = new NinjectRegistrator();
            var kernel = new StandardKernel(registrator);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
