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
        int? RodzajTransakcjiId { get; set; }
        int? RodzajCzynnosciId { get; set; }
        int? RodzajDokumentuId { get; set; }
        string Numer { get; set; }
        DateTime? Data { get; set; }
        string Tytul { get; set; }
        string Skan { get; set; }
    }
}
