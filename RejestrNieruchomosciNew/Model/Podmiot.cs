using System;
using System.Collections.Generic;

namespace RejestrNieruchomosciNew
{
    public partial class Podmiot
    {
        public int Id { get; set; }
        public int? StatusId { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Nazwa { get; set; }
        public string Adres { get; set; }
        public string NrTelefonu { get; set; }
        public string Email { get; set; }
        public int? State { get; set; }
        public DateTime? DataIn { get; set; }
        public DateTime? DataMod { get; set; }
        public int? Uid { get; set; }

        public virtual StatusSlo Status { get; set; }
        public virtual ICollection<Wladanie> Wladanie { get; set; }
    }
}
