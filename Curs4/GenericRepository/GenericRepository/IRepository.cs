using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository
{
    public interface IRepository<T> where T : class, IEntity
    {
        T GetById(int id);
        List<T> GetAll();
        int Create(T entity);
        void Update(T entity);
        void Delete(int id);
        bool Exists(int id);
    }
}
