using RejestrNieruchomosciNew.Model;
using System;
using System.Collections.Generic;

namespace RejestrNieruchomosciNew
{
    public partial class NazwaCzynnosciSlo : INazwaCzynosciSlo
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }

        public ICollection<Wladanie> Wladanie { get; set; }
    }
}
