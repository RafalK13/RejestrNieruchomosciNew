namespace RejestrNieruchomosciNew.Model
{
    interface IObreb
    {
         int ObrebId { get; set; }
         string Nazwa { get; set; }
         string Numer { get; set; }

        //ICollection<Dzialka> Dzialka { get; set; }
        int GminaSloId { get; set; }
         GminaSlo GminaSlo { get; set; }
    }
}
