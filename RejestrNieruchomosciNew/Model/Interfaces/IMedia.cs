namespace RejestrNieruchomosciNew.Model.Interfaces
{
    public interface IMedia
    {
        int MediaId { get; set; }
        int prad { get; set; }
        int woda { get; set; }
        int kanSan { get; set; }
        int kanLok { get; set; }
        int kanDeszcz { get; set; }
        int tel { get; set; }
        int co { get; set; }
        int gaz { get; set; }
        int internet { get; set; }
        int tv { get; set; }
    }
}
