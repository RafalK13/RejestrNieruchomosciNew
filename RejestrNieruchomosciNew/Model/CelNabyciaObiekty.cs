using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model
{
    public class CelNabyciaObiekty : ICelNabyciaObiekty
    {
        public int CelNabyciaObiektyId { get; set; }
        public string Nazwa { get; set; }
    }
}
