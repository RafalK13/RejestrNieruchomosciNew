using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model
{
    interface IRodzajDokumentuSlo
    {
        int RodzajDokumentuSloId { get; set; }
        string Nazwa { get; set; }
    }
}
