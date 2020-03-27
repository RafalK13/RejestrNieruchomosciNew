namespace RejestrNieruchomosciNew.Model.Interfaces
{
    public interface ILokale
    {
        int LokalId { get; set; }
        int BudynkiId { get; set; }
        string Numer { get; set; }
        double pow { get; set; }
        double powPomPrzyn { get; set; }
        string opis { get; set; }
        int media { get; set; }
        int kondygnacja { get; set; }
        string KWlok { get; set; }

        int NajemcaId { get; set; }
    }
}
