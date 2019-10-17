using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model
{
    public interface IRodzajDokScanSlo
    {
        int RodzajDokScanSloId { get; set; }
        string Nazwa { get; set; }
    }
}
