using RejestrNieruchomosciNew.Model.Interfaces;

namespace RejestrNieruchomosciNew.Model
{
    public class DzialkaOchrona : IDzialkaOchrona
    {
        public int DzialkaOchronaId { get; set; }
        public int? DzialkaId { get; set; }

        public bool obszarChroniony { get; set; }
        public bool wpisDoGEZ { get; set; }
        public bool wpisDoWEZ { get; set; }
        public bool wpisDoWZ { get; set; }
        public bool wpisDoMPZP { get; set; }
        public bool parkNarodowy { get; set; }
        public bool rezerwatPrzyrody { get; set; }
        public bool parkKrajobrazowy { get; set; }
        public bool obszarChronionyKrajobrazu { get; set; }
        public bool obszarNatura2000 { get; set; }
        public bool pomnikPrzyrody { get; set; }
        public bool stonowiskoDok { get; set; }
        public bool uzytekEkologiczny { get; set; }
        public bool wpisWMPZM { get; set; }
        public bool terenOchrBezp { get; set; }
        public bool terenOchrScislej { get; set; }
        public bool terenOchrPosr { get; set; }
        public string planObowiazujacy { get; set; }
        public string planProcedowany { get; set; }

        public Dzialka Dzialka { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
