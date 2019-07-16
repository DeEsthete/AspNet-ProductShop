using AspNet_FirstLesson.Interfaces;
using AspNet_FirstLesson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNet_FirstLesson.Data
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly ProductContext db = new ProductContext();

        public void Add(Product entity)
        {
            if (entity != null)
            {
                db.Products.Add(entity);
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var entity = db.Products.FirstOrDefault(i => i.Id == id);
            if (entity != null)
            {
                db.Products.Remove(entity);
                db.SaveChanges();
            }
        }

        public void Edit(Product entity)
        {
            var item = db.Products.FirstOrDefault(i => i.Id == entity.Id);
            if (item != null)
            {
                item.Name = entity.Name;
                item.ProducerId = entity.ProducerId;
                item.Price = entity.Price;
                item.CategoryId = entity.CategoryId;
                db.SaveChanges();
            }
        }

        public IEnumerable<Product> GetAll()
        {
            return db.Products;
        }

        public Product GetEntity(int id)
        {
            return db.Products.FirstOrDefault(i => i.Id == id);
        }
    }
}