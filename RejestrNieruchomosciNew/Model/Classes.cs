using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model
{
    public interface IPerson
    {
        string name { get; set; }
    }

    public class Person : IPerson
    {
        public string name { get; set; }

        public Person()
        {
            name = "Ala";
        }
    }
}
