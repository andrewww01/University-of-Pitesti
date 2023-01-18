using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository
{
    public class RepositoryFactory<T> where T : class, IEntity
    {
        public static IRepository<T> Create()
        {
            return new JsonRepository<T>();
        }
    }
}
