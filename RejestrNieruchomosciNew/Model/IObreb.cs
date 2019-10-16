using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model
{
    interface IObreb
    {
         int ObrebId { get; set; }
         string Nazwa { get; set; }

         //ICollection<Dzialka> Dzialka { get; set; }
         int GminaSloId { get; set; }
         GminaSlo GminaSlo { get; set; }
    }
}
