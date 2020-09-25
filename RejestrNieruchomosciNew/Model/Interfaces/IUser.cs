namespace RejestrNieruchomosciNew.Model.Interfaces
{
    public interface IUser
    {
        int UserId { get; set; }
        string name { get; set; }
        bool admin { get; set; }
    }
}
