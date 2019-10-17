using System;
using RejestrNieruchomosciNew.Model.Interfaces;

namespace RejestrNieruchomosciNew.Model
{
    public class Transakcje : ITransakcje
    {
        public int TransakcjeId { get; set; }
        public int RodzajDokumentuId { get; set; }
        public int RodzajCzynnosciSloId { get; set; }
        public string numer { get; set; }
        public DateTime Data { get; set; }
        public string Tytul { get; set; }
    }
}
