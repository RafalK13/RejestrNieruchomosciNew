using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model
{
    public interface IWladanie : IEquatable<IWladanie>, ICloneable
    {
         int WladanieId { get; set; }
         int? DzialkaId { get; set; }
         int? PodmiotId { get; set; }

         int? FormaWladaniaSloId { get; set; }

         int TransK_Id { get; set; }

         int TransS_Id { get; set; }

         int? NabycieId { get; set; }
         string Udzial { get; set; }

         Podmiot Podmiot { get; set; }
    }
}
