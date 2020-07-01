using RejestrNieruchomosciNew.Model.Interfaces;

namespace RejestrNieruchomosciNew.Model
{
    public class Media : IMedia
    {
        public int MediaId { get; set; }
        public int prad { get; set; }
        public int woda { get; set; }
        public int kanSan { get; set; }
        public int kanLok { get; set; }
        public int kanDeszcz { get; set; }
        public int tel { get; set; }
        public int co { get; set; }
        public int gaz { get; set; }
        public int internet { get; set; }
        public int tv { get; set; }
    }
}
