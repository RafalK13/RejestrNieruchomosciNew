using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model
{
    public class Scan : IScan
    {
        public int ScanId { get; set; }
        public int RodzajDokScanSloId { get; set; }
        public int RodzajId { get; set; }
        public string Path { get; set; }
    }
}
