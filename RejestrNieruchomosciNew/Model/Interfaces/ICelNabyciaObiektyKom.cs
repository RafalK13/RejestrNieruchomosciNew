﻿using System;

namespace RejestrNieruchomosciNew.Model.Interfaces
{
    interface ICelNabyciaObiektyKom 
    {
        int ID { get; set; }
        Guid guid { get; set; }
        string Nazwa { get; set; }
    }
}
