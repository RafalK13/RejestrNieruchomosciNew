using System;

namespace RejestrNieruchomosciNew.Model.Interfaces
{
    interface ICelNabyciaObiekty
    {
        int ID { get; set; }
        Guid guid { get; set; }
        string Nazwa { get; set; }
    }
}
