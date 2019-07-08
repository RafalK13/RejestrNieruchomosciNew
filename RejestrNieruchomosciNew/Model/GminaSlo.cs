using System;
using System.Collections.Generic;

namespace RejestrNieruchomosciNew
{
    public partial class GminaSlo
    {
        public int GminaSloId { get; set; }
        public string Nazwa { get; set; }

        public virtual List<Obreb> Obreb { get; set; }
    }
}
