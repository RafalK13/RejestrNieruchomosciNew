using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model
{
    public class Lokale : ILokale
    {
        public int LokalId { get; set; }
        public int BudynkiId { get; set; }
        public string Numer { get; set; }
        public double pow { get; set; }
        public double powPomPrzyn { get; set; }
        public string opis { get; set; }
        public int media { get; set; }
        public int kondygnacja { get; set; }
        public string KWlok { get; set; }
        public int NajemcaId { get; set; }
    }
}
