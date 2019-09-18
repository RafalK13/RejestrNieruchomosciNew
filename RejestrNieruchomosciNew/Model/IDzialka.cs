﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model
{
    public interface IDzialka
    {
        int DzialkaId { get; set; }
        string Numer { get; set; }
        string Kwakt { get; set; }
        string Kwzrob { get; set; }
        decimal? Pow { get; set; }
        int ObrebId { get; set; }
        Obreb Obreb { get; set; }
    }
}