using AspNet_FirstLesson.Data;
using AspNet_FirstLesson.Interfaces;
using AspNet_FirstLesson.Models;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNet_FirstLesson.App_Start
{
    public class NinjectRegistrator : NinjectModule
    {
        public override void Load()
        {
            Bind<ProductContext>().To<ProductContext>();

            Bind<IRepository<Product>>().To<ProductRepository>();
            Bind<IRepository<User>>().To<UserRepository>();
            Bind<IRepository<Producer>>().To<ProducerRepository>();
            Bind<IRepository<Role>>().To<RoleRepository>();
            Bind<IRepository<Category>>().To<CategoryRepository>();
        }
    }
}