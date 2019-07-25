using AspNet_FirstLesson.App_Start;
using Ninject;
using Ninject.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace AspNet_FirstLesson
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var registrator = new NinjectRegistrator();
            var kernel = new StandardKernel(registrator);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
