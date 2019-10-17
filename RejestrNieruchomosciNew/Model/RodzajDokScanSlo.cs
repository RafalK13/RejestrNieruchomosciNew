using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model
{
    public class RodzajDokScanSlo : IRodzajDokScanSlo
    {
        public int RodzajDokScanSloId { get; set; }
        public string Nazwa { get; set; }
    }
}
