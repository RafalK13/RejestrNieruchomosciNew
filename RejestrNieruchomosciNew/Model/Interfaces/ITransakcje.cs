using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model.Interfaces
{
    public interface ITransakcje
    {
        int TransakcjeId { get; set; }
        int RodzajDokumentuId { get; set; }
        int RodzajCzynnosciSloId { get; set; }
        string numer { get; set; }
        DateTime Data { get; set; }
        string Tytul { get; set; }
    }
}
