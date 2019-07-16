using AspNet_FirstLesson.Interfaces;
using AspNet_FirstLesson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNet_FirstLesson.Data
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly ProductContext db = new ProductContext();

        public void Add(Category entity)
        {
            if (entity != null)
            {
                db.Categories.Add(entity);
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var entity = db.Categories.FirstOrDefault(i => i.Id == id);
            if (entity != null)
            {
                db.Categories.Remove(entity);
                db.SaveChanges();
            }
        }

        public void Edit(Category entity)
        {
            var item = db.Categories.FirstOrDefault(i => i.Id == entity.Id);
            if (item != null)
            {
                item.Name = entity.Name;
                db.SaveChanges();
            }
        }

        public IEnumerable<Category> GetAll()
        {
            return db.Categories;
        }

        public Category GetEntity(int id)
        {
            return db.Categories.FirstOrDefault(i => i.Id == id);
        }
    }
}