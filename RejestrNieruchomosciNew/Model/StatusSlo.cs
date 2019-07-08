using System;
using System.Collections.Generic;

namespace RejestrNieruchomosciNew
{
    public partial class StatusSlo
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }

        public virtual ICollection<Podmiot> Podmiot { get; set; }
    }
}
