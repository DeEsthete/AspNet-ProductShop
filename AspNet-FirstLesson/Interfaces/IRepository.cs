using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNet_FirstLesson.Interfaces
{

    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Edit(T entity);
        void Delete(int id);
        T GetEntity(int id);
        IEnumerable<T> GetAll();
    }
}
