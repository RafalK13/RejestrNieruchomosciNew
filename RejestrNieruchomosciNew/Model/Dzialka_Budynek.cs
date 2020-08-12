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

            Budynek = (Budynek)d.Budynek.Clone();
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        //public override  bool Equals(Object _other)
        //{
        //    IDzialka_Budynek other = _other as IDzialka_Budynek;

        //    return DzialkaId.Equals(other.DzialkaId) &&
        //           BudynekId.Equals(other.BudynekId);
        //}

        //public override int GetHashCode() => (DzialkaId, BudynekId).GetHashCode();

        public override int GetHashCode()
        {
            unchecked
            {
                const int HashingBase = (int)2166136261;
                const int HashingMultiplier = 16777619;

                int hash = HashingBase;
                hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, DzialkaId) ? DzialkaId.GetHashCode() : 0);
                hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, BudynekId) ? BudynekId.GetHashCode() : 0);
                return hash;
            }
        }

        public override bool Equals(object _other)
        {
            if (_other == null)
            {
                return false;
            }

            IDzialka_Budynek other = _other as IDzialka_Budynek;

            if (other == null)
            {
                return false;
            }

            return DzialkaId == other.DzialkaId &&
                   BudynekId == other.BudynekId;

        }
    }
}


