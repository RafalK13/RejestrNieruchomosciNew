using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace RejestrNieruchomosciNew.Model
{
    public class ObrebList : IObrebList
    {
        public List<Obreb> obrebList { get; set; }

        public ObrebList()
        {
           
            using (var c = new Context())
            {
                obrebList = c.Obreb.Include("GminaSlo").ToList();
            }
        }
    }
}
