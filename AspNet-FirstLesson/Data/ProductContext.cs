namespace AspNet_FirstLesson.Data
{
    using AspNet_FirstLesson.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ProductContext : DbContext
    {
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "ProductModel" 
        // в файле конфигурации приложения.
        public ProductContext()
            : base("name=ProductModel")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Producer> Producers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        /*Заполнение БД начальными данными*/
        public void FillBd(ProductContext db)
        {
            Role role = new Role { Name = "Creator" };
            Role role1 = new Role { Name = "Admin" };
            Role role2 = new Role { Name = "User" };
            db.Roles.Add(role);
            db.Roles.Add(role1);
            db.Roles.Add(role2);
            Producer producer = new Producer { Name = "Хлебозавод #1" };
            Producer producer1 = new Producer { Name = "Молокозавод #1" };
            db.Producers.Add(producer);
            db.Producers.Add(producer1);
            Category category = new Category { Name = "Хлебо-булочные изделия" };
            Category category1 = new Category { Name = "Молочные изделия" };
            db.Categories.Add(category);
            db.Categories.Add(category1);
            Product product = new Product { Name = "Хлеб", Price = 65, ProducerId = 1, CategoryId = 1 };
            Product product1 = new Product { Name = "Молоко", Price = 240, ProducerId = 2, CategoryId = 2 };
            db.Products.Add(product);
            db.Products.Add(product1);
            User user = new User { Name = "Leha", Login = "Leha90", Password = "123456", RoleId = 1 };
            User user1 = new User { Name = "Gena", Login = "GenAdy", Password = "genka000", RoleId = 2 };
            User user2 = new User { Name = "Miha", Login = "mehanik89", Password = "meh101", RoleId = 3 };
            db.Users.Add(user);
            db.Users.Add(user1);
            db.Users.Add(user2);
            db.SaveChanges();
        }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    FillBd(this);
        //}
    }
}
