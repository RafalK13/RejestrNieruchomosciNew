using RejestrNieruchomosciNew.Model.Interfaces;
using System;

namespace RejestrNieruchomosciNew.Model
{
    public class CelNabycia : ICelNabycia
    {
        public int Id { get; set; }
        public Guid guid { get; set; }
        public string Nazwa { get; set; }
        public string Rodzaj { get; set; }
    }
}
