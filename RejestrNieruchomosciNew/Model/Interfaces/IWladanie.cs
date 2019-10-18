using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model
{
    public interface IWladanie
    {
         int WladanieId { get; set; }
         int? DzialkaId { get; set; }
         int? PodmiodId { get; set; }

         int? FormaWladaniaSloId { get; set; }

         int? TransakcjaId { get; set; }
         int? NabycieId { get; set; }
         string Udzial { get; set; }

         Podmiot Podmiot { get; set; }
    }
}
