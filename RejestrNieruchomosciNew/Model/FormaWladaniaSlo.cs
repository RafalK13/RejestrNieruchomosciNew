﻿using System;
using System.Collections.Generic;

namespace RejestrNieruchomosciNew
{
    public partial class FormaWladaniaSlo
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }

        public ICollection<Wladanie> Wladanie { get; set; }
    }
}
