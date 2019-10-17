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

         int? FormaWladaniaId { get; set; }
         string Udzial { get; set; }
         int? NabycieId { get; set; }
         int? ZbycieId { get; set; }

        //int? NazwaCzynnosciId { get; set; }
        //int? RodzajDokumentuId { get; set; }
        //int? PlatnoscUwId { get; set; }

        //string TytulDokumentu { get; set; }
        //DateTime? DataDokumentu { get; set; }
        //DateTime? DataObowiazywaniaOd { get; set; }
        //DateTime? DataObowiazywaniaDo { get; set; }

        //int? Stawka { get; set; }
        //int? Okres { get; set; }
        //decimal? Wartosc { get; set; }
    }
}
