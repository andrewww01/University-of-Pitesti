using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGeneric
{
    public class Contact : IComparable<Contact>
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public int Age { get; set; }

        public int CompareTo(Contact other)
        {
            throw new NotImplementedException();
        }
    }
}
