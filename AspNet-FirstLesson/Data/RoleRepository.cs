using AspNet_FirstLesson.Interfaces;
using AspNet_FirstLesson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNet_FirstLesson.Data
{
    //public class RoleRepository : IRepository<Role>
    //{
    //    private readonly ProductContext db = new ProductContext();

    //    public void Add(Role entity)
    //    {
    //        if (entity != null)
    //        {
    //            db.Roles.Add(entity);
    //            db.SaveChanges();
    //        }
    //    }

    //    public void Delete(int id)
    //    {
    //        var entity = db.Roles.FirstOrDefault(i => i.Id == id);
    //        if (entity != null)
    //        {
    //            db.Roles.Remove(entity);
    //            db.SaveChanges();
    //        }
    //    }

    //    public void Edit(Role entity)
    //    {
    //        var item = db.Roles.FirstOrDefault(i => i.Id == entity.Id);
    //        if (item != null)
    //        {
    //            item.Name = entity.Name;
    //            db.SaveChanges();
    //        }
    //    }

    //    public IEnumerable<Role> GetAll()
    //    {
    //        return db.Roles;
    //    }

    //    public Role GetEntity(int id)
    //    {
    //        return db.Roles.FirstOrDefault(i => i.Id == id);
    //    }
    //}
}