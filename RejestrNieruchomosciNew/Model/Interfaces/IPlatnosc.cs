namespace RejestrNieruchomosciNew.Model
{
    public interface IPlatnosc
    {
        //int PlatnoscId { get; set; }
        double? Stawka { get; set; }
        int? Okres { get; set; }
        double? Wysokosc { get; set; }
        double? Wartosc { get; set; }

        int? rok1 { get; set; }
        int? rok2 { get; set; }
        int? rok3 { get; set; }

        //void save();

        //void cleanObj();
        //bool isNull();
        
        //IPlatnosc clone();
    }
}
