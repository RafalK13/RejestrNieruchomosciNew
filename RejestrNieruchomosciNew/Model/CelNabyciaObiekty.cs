﻿using RejestrNieruchomosciNew.Model.Interfaces;
using System;

namespace RejestrNieruchomosciNew.Model
{
    public class CelNabyciaObiekty : ICelNabyciaObiekty
    {
        public int ID { get; set; }
        public Guid guid { get; set; }
        public string Nazwa { get; set; }
    }
}
