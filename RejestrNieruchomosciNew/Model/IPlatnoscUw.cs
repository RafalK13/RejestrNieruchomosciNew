using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model
{
    public interface IPlatnoscUw
    {
        int Id { get; set; }
        double? Stawka { get; set; }
        int? Okres { get; set; }
        double? Wartosc { get; set; }
    }
}
