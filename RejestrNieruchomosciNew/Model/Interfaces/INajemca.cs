using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model.Interfaces
{
    public interface INajemca
    {
        int PodmiotId { get; set; }
        IPodmiot Podmiot { get; set; }
    }
}
