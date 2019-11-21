using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model
{
    public interface IPlatnoscUW
    {
        int PlatnoscUWId { get; set; }
        int? DzialkaId { get; set; }
        double? Stawka { get; set; }
        int? Okres { get; set; }
        double? Wysokosc { get; set; }
        double? Wartosc { get; set; }

        int? rok1 { get; set; }
        int? rok2 { get; set; }
        int? rok3 { get; set; }

        void save();

        void cleanObj();
        bool isNull();
        
        IPlatnoscUW clone();
    }
}
