﻿using System;
using System.Collections.Generic;

namespace RejestrNieruchomosciNew
{
    public partial class Obreb 
    {
        public int ObrebId { get; set; }
        public string Nazwa { get; set; }
     
        public ICollection<Dzialka> Dzialka { get; set; }

        public int GminaSloId { get; set; }
        public GminaSlo GminaSlo { get; set; }
    }
}
