using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model.Interfaces
{
    public interface ITransakcje
    {
        int TransakcjeId { get; set; }
        int? RodzajTransakcjiSloId { get; set; }
        int? NazwaCzynnosciSloId { get; set; }
        int? RodzajDokumentuSloId { get; set; }
        string Numer { get; set; }
        DateTime? Data { get; set; }
        string Tytul { get; set; }
        string Skan { get; set; }
        
    }
}
