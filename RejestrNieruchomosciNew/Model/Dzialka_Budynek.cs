using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model
{
    public class Dzialka_Budynek : IDzialka_Budynek
    {
        public int DzialkaId { get; set; }
        public Dzialka Dzialka { get; set; }

        public int BudynekId { get; set; }
        public Budynek Budynek { get; set; }
        
        public Dzialka_Budynek()
        {

        }

        public Dzialka_Budynek(IDzialka_Budynek d)
        {
            DzialkaId = d.DzialkaId;
            BudynekId = d.BudynekId;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        bool IEquatable<IDzialka_Budynek>.Equals(IDzialka_Budynek other)
        {
            return DzialkaId.Equals(other.DzialkaId) &&
                   BudynekId.Equals(other.BudynekId);
        }
    }
}

