namespace RejestrNieruchomosciNew.Model
{
    public class Lokal_Podmiot
    {
        public int LokalId { get; set; }
        public Lokal Lokal { get; set; }

        public int PodmiotId { get; set; }
        public Podmiot Podmiot { get; set; }
    }
}
