namespace RejestrNieruchomosciNew.Model.Interfaces
{
    public interface IDzialkaOchrona
    {
        int DzialkaOchronaId { get; set; }
        int? DzialkaId { get; set; }
        bool obszarChroniony { get; set; }
        bool wpisDoGEZ { get; set; }
        bool wpisDoWEZ { get; set; }
        bool wpisDoWZ { get; set; }
        bool wpisDoMPZP { get; set; }
        bool parkNarodowy { get; set; }
        bool rezerwatPrzyrody { get; set; }
        bool parkKrajobrazowy { get; set; }
        bool obszarChronionyKrajobrazu { get; set; }
        bool obszarNatura2000 { get; set; }
        bool pomnikPrzyrody { get; set; }
        bool stonowiskoDok { get; set; }
        bool uzytekEkologiczny { get; set; }
        bool wpisWMPZM { get; set; }
        bool terenOchrBezp { get; set; }
        bool terenOchrScislej { get; set; }
        bool terenOchrPosr { get; set; }
        string planObowiazujacy { get; set; }
        string planProcedowany { get; set; }

        object Clone();
    }
}
