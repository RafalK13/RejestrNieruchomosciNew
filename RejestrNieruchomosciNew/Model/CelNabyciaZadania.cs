using RejestrNieruchomosciNew.Model.Interfaces;
using System;

namespace RejestrNieruchomosciNew.Model
{
    public class CelNabyciaZadania : ICelNabyciaZadania
    {
        public int ID { get; set; }
        public string Nazwa { get; set; }
    }
}
