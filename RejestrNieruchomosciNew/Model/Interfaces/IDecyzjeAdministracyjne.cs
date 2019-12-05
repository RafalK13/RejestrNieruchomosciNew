using System;

namespace RejestrNieruchomosciNew.Model.Interfaces
{
    public interface IDecyzjeAdministracyjne
    {
        int DecyzjeAdministracyjneId { get; set; }
        string Numer { get; set; }
        DateTime? DataDecyzji { get; set; }
        int? PodmiotId { get; set; }
        string Przedmiot { get; set; }
        string  Skan { get; set; }
    }
}
