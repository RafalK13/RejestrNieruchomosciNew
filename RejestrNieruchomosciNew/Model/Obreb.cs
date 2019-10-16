using Microsoft.EntityFrameworkCore;
using RejestrNieruchomosciNew.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RejestrNieruchomosciNew
{
    public partial class Obreb : IObreb
    {
        public int ObrebId { get; set; }
        public string Nazwa { get; set; }

        public GminaSlo GminaSlo { get; set; }

        public ICollection<Dzialka> Dzialka { get; set; }

        public int GminaSloId { get; set; }
        //public GminaSlo GminaSlo { get; set; }    
    }
}
