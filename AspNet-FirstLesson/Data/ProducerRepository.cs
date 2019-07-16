using AspNet_FirstLesson.Interfaces;
using AspNet_FirstLesson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNet_FirstLesson.Data
{
    public class ProducerRepository : IRepository<Producer>
    {
        private readonly ProductContext db = new ProductContext();

        public void Add(Producer entity)
        {
            if (entity != null)
            {
                db.Producers.Add(entity);
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var entity = db.Producers.FirstOrDefault(i => i.Id == id);
            if (entity != null)
            {
                db.Producers.Remove(entity);
                db.SaveChanges();
            }
        }

        public void Edit(Producer entity)
        {
            var item = db.Producers.FirstOrDefault(i => i.Id == entity.Id);
            if (item != null)
            {
                item.Name = entity.Name;
                db.SaveChanges();
            }
        }

        public IEnumerable<Producer> GetAll()
        {
            return db.Producers;
        }

        public Producer GetEntity(int id)
        {
            return db.Producers.FirstOrDefault(i => i.Id == id);
        }
    }
}