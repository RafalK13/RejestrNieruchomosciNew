using System.Collections;
using System.Collections.Generic;

namespace RejestrNieruchomosciNew.Model.Interfaces
{
    public interface IFormaWladaniaSlo
    {
        int FormaWladaniaSloId { get; set; }
        string Nazwa { get; set; }

        ICollection<Wladanie> Wladanie { get; set; }
    }
}
