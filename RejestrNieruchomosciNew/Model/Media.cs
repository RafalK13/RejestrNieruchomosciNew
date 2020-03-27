using RejestrNieruchomosciNew.Model.Interfaces;

namespace RejestrNieruchomosciNew.Model
{
    public class Media : IMedia
    {
        public int MediaId { get; set; }
        public int prad { get; set; }
        public int woda { get; set; }
        public int kan { get; set; }
        public int tel { get; set; }
        public int co { get; set; }
        public int internet { get; set; }
    }
}
