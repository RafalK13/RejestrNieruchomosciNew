using System.Collections.Generic;

namespace RejestrNieruchomosciNew.Model
{
    public partial class RodzajDokumentuSlo : IRodzajDokumentuSlo
    {
        public int RodzajDokumentuSloId { get; set; }
        public string Nazwa { get; set; }

        public ICollection<Transakcje> TransakcjeSlo { get; set; }
    }
}
