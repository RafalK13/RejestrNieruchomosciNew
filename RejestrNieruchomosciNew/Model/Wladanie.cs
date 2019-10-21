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

        public Podmiot Podmiot { get; set; }

        public Wladanie()
        {
        }

        public Wladanie(int? _DzialkaId, int? _PodmiodId, string _name )
        {
            Podmiot = new Podmiot() { Name = _name};

            DzialkaId = _DzialkaId;
            PodmiodId = _PodmiodId;
        }
    }

}
