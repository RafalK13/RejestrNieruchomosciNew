using RejestrNieruchomosciNew.Model;
using System;
using System.Collections.Generic;

namespace RejestrNieruchomosciNew
{
    public partial class RodzajDokumentuSlo : IRodzajDokumentuSlo
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }

        public int? WladanieId { get; set; }
        public Wladanie Wladanie { get; set; }
    }
}
