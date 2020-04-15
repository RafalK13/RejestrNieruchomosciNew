namespace RejestrNieruchomosciNew.Model.Interfaces
{
    public interface IMiejscowoscSlo
    {
        int MiejscowoscSloId { get; set; }

        int GminaSloId { get; set; }
        int MiejscowoscUlice { get; set; }

        string Nazwa { get; set; }
    }
}
