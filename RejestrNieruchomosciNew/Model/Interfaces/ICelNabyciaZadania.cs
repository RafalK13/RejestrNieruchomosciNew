using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model.Interfaces
{
    interface ICelNabyciaZadania
    {
        int ID { get; set; }
        Guid guid { get; set; }
        string Nazwa { get; set; }
    }
}
