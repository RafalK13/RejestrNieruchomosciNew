using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model.Interfaces
{
    public interface IAdres
    {
        int AdresId { get; set; }
        int UliceSloId { get; set; }
        int BudynekId { get; set; }
        string Numer { get; set; }

    }
}
