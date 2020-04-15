namespace RejestrNieruchomosciNew.Model.Interfaces
{
    public interface IUlicaSlo
    {
        int UlicaSloId { get; set; }

        int MiejscowoscUlice { get; set; }
        
        string Nazwa { get; set; }
    }
}
