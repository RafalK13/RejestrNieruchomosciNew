using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model.Interfaces
{
    public interface IDzialka_Budynek : IEquatable<IDzialka_Budynek>, ICloneable
    {
        int DzialkaId { get; set; }
        int BudynekId { get; set; }

        Dzialka Dzialka { get; set; }
        Budynek Budynek { get; set; }

        //object Clone();        
    }
}
