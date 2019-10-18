using RejestrNieruchomosciNew.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RejestrNieruchomosciNew
{
    public partial class Wladanie : IWladanie
    {
        public int WladanieId { get; set; }
        public int? DzialkaId { get; set; }
        public int? PodmiodId { get; set; }

        public int? FormaWladaniaSloId { get; set; }
        
        public int? TransakcjaId { get; set; }
        public int? NabycieId { get; set; }
        public string Udzial { get; set; }
    }
}
