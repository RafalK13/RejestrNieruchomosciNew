using System;

namespace RejestrNieruchomosciNew.Model.Interfaces
{
    interface ICelNabyciaZadania
    {
        int ID { get; set; }
        Guid guid { get; set; }
        string Nazwa { get; set; }
    }
}
