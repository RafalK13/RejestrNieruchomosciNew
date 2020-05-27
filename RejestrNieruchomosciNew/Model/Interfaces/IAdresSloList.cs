using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model.Interfaces
{
    public interface IAdresSloList 
    {   
        IMiejscowoscSloList miejscList { get; set; }
        
        IUlicaSloList ulicaList { get; set; }

        event EventHandler zmiana;
    }
}
