using AspNet_FirstLesson.Interfaces;
using AspNet_FirstLesson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNet_FirstLesson.Data
{
    public class UserRepository : IRepository<User>
    {
        private readonly ProductContext db = new ProductContext();

        public void Add(User entity)
        {
            if (entity != null)
            {
                db.Users.Add(entity);
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var entity = db.Users.FirstOrDefault(i => i.Id == id);
            if (entity != null)
            {
                db.Users.Remove(entity);
                db.SaveChanges();
            }
        }

        public void Edit(User entity)
        {
            var item = db.Users.FirstOrDefault(i => i.Id == entity.Id);
            if (item != null)
            {
                item.Name = entity.Name;
                db.SaveChanges();
            }
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users;
        }

        public User GetEntity(int id)
        {
            return db.Users.FirstOrDefault(i => i.Id == id);
        }
    }
}