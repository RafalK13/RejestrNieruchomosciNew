using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model
{
    public interface IScan
    {
        int ScanId { get; set; }
        int RodzajDokScanSloId { get; set; }
        int RodzajId { get; set; }
        string Path { get; set; }
    }
}
