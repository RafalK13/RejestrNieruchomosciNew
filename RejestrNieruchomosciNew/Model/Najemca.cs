using RejestrNieruchomosciNew.Model.Interfaces;

namespace RejestrNieruchomosciNew.Model
{
    public class Najemca : INajemca
    {
        public int PodmiotId { get; set; }
        public IPodmiot Podmiot { get; set; }
    }
}
