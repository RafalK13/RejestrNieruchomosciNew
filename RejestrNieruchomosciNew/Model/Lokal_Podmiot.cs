namespace RejestrNieruchomosciNew.Model
{
    public class Lokal_Podmiot
    {
        public int Lokal_PodmiotId  { get; set; }

        public int LokalId { get; set; }
        public Lokal Lokal { get; set; }

        public int PodmiotId { get; set; }        
    }
}
