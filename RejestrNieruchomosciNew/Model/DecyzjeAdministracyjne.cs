using System;
using RejestrNieruchomosciNew.Model.Interfaces;

namespace RejestrNieruchomosciNew.Model
{
    public class DecyzjeAdministracyjne : IDecyzjeAdministracyjne
    {
        public int DecyzjeAdministracyjneId { get; set;}
        public string Numer {get; set;}
        public DateTime? DataDecyzji {get; set;}
        public int? PodmiotId {get; set;}
        public string Przedmiot {get; set;}
        public string Skan {get; set;}

        //public InnePrawa InnePrawa { get; set; }
    }
}
