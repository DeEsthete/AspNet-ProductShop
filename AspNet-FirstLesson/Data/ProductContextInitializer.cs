using AspNet_FirstLesson.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AspNet_FirstLesson.Data
{
    public class ProductContextInitializer : CreateDatabaseIfNotExists<ProductContext>//DropCreateDatabaseAlways<ProductContext>
    {
        protected override void Seed(ProductContext db)
        {
            var roleManager = new AppRolesManager(new RoleStore<IdentityRole>(db));
            var userManager = new AppUserManager(new UserStore<User>(db));

            roleManager.Create(new IdentityRole("creator"));
            roleManager.Create(new IdentityRole("admin"));
            roleManager.Create(new IdentityRole("user"));

            Basket basket = new Basket();
            Basket basket1 = new Basket();
            Basket basket2 = new Basket();
            db.Baskets.Add(basket);
            db.Baskets.Add(basket1);
            db.Baskets.Add(basket2);
            db.SaveChanges();

            var user = new User { UserName = "admin1", Email = "admin1@mail.ru", BasketId = 1 };
            userManager.Create(user, "Qaz/123456");
            userManager.AddToRole(user.Id, "creator");
            var user1 = new User { UserName = "admin2", Email = "admin2@mail.ru", BasketId = 2 };
            userManager.Create(user1, "Qaz/123456");
            userManager.AddToRole(user1.Id, "admin");
            var user2 = new User { UserName = "user1", Email = "user1@mail.ru", BasketId = 3 };
            userManager.Create(user2, "Qaz/123456");
            userManager.AddToRole(user2.Id, "user");

            ProducerRepository producerRepository = new ProducerRepository();
            producerRepository.Add(new Producer { Name = "Хлебозавод #1" });
            producerRepository.Add(new Producer { Name = "Молокозавод #1" });
            CategoryRepository categoryRepository = new CategoryRepository();
            categoryRepository.Add(new Category { Name = "Хлебо-булочные изделия" });
            categoryRepository.Add(new Category { Name = "Молочные изделия" });
            ProductRepository productRepository = new ProductRepository();
            productRepository.Add(new Product { Name = "Хлеб", Price = 65, ProducerId = 1, CategoryId = 1 });
            productRepository.Add(new Product { Name = "Молоко", Price = 240, ProducerId = 2, CategoryId = 2 });
        }
    }
}