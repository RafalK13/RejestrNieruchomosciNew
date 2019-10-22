using RejestrNieruchomosciNew.Model;
using System;
using System.Collections.Generic;

namespace RejestrNieruchomosciNew
{
    public partial class NazwaCzynnosciSlo : INazwaCzynosciSlo
    {
        public int NazwaCzynnosciSloId { get; set; }
        public string Nazwa { get; set; }

        public ICollection<Transakcje> TransakcjeSlo { get; set; }
    }
}
