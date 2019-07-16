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
            Database.SetInitializer<ProductContext>(new ProductContextInitializer());
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Producer> Producers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
