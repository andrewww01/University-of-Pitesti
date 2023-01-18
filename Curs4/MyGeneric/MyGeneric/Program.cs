using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGeneric
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyGenericContainer<Contact> myGenericContainer = new MyGenericContainer<Contact>();

            myGenericContainer.Add(new Contact()
            {
                Id = 12,
                Name = "cocolino",
                Age = 30
            });

            Console.ReadKey();
        }
    }
}
