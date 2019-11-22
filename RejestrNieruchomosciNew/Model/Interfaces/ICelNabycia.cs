using System;

namespace RejestrNieruchomosciNew.Model.Interfaces
{
    interface ICelNabycia
    {
        int Id { get; set; }
        Guid guid { get; set; }
        string Nazwa { get; set; }
        string Rodzaj { get; set; }
    }
}
