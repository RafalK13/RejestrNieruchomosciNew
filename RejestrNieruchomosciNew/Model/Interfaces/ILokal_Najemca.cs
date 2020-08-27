using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model.Interfaces
{
    public interface ILokal_Najemca
    {
         int LokalId { get; set; }
         int NajemcaId { get; set; }
    }
}
