namespace AspNet_FirstLesson.Data
{
    using AspNet_FirstLesson.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ProductContext : IdentityDbContext<User>
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
        public virtual DbSet<Basket> Baskets { get; set; }
        public virtual DbSet<BasketItem> BasketItems { get; set; }
        public virtual DbSet<OrderBasket> OrderBaskets { get; set; }
        public virtual DbSet<OrderBasketItem> OrderBasketItems { get; set; }

        public static ProductContext Create()
        {
            return new ProductContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().
                Property(p => p.BirthDate)
                .HasColumnType("datetime2")
                .HasPrecision(0)
                .IsRequired();
            base.OnModelCreating(modelBuilder);
        }
    }
}
