﻿using RejestrNieruchomosciNew.Model.Interfaces;

namespace RejestrNieruchomosciNew.Model
{
    public class Adres : IAdres
    {
        public int AdresId { get; set; }
        public int UlicaId { get; set; }
        public int BudynekId { get; set; }
        public string Numer { get; set; }
    }
}