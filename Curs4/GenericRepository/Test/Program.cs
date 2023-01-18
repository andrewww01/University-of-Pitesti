using GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var repository = RepositoryFactory<Contact>.Create();


            repository.Create(new Contact()
            {
                Name = "cocolino",
                Email = "test@upit.ro"
            });
        }
    }
}
