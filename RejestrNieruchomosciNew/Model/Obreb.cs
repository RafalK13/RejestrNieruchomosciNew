using Microsoft.EntityFrameworkCore;
using RejestrNieruchomosciNew.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RejestrNieruchomosciNew
{
    [Serializable]
    public partial class Obreb : IObreb
    {
        public int ObrebId { get; set; }
        public string Nazwa { get; set; }
        public string Numer { get; set; }

        public GminaSlo GminaSlo { get; set; }
        [field: NonSerialized]
        public ICollection<Dzialka> Dzialka { get; set; }

        public int GminaSloId { get; set; }
        //public GminaSlo GminaSlo { get; set; }    
        
        public IObreb copy(IObreb obSource)
        {
            ObrebId = obSource.ObrebId;
            Nazwa = obSource.Nazwa;
            Numer = obSource.Numer;
            GminaSloId = obSource.GminaSloId;

            if (GminaSlo == null)
                GminaSlo = new GminaSlo();

            GminaSlo.copy(obSource.GminaSlo);

            return this;
        }
    }
}
