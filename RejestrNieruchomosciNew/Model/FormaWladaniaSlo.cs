using RejestrNieruchomosciNew.Model.Interfaces;
using System.Collections.Generic;

namespace RejestrNieruchomosciNew
{
    public partial class FormaWladaniaSlo : IFormaWladaniaSlo
    {
        public int FormaWladaniaSloId { get; set; }
        public string Nazwa { get; set; }

        public ICollection<Wladanie> Wladanie { get; set; }
    }
}
