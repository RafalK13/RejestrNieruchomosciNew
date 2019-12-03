using System;

namespace RejestrNieruchomosciNew.Model.Interfaces
{
    public interface ICelNabycia
    {
        int Id { get; set; }
        Guid guid { get; set; }
        string Nazwa { get; set; }
        string Rodzaj { get; set; }
    }
}
