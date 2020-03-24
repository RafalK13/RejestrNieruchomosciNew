namespace RejestrNieruchomosciNew.Model.Interfaces
{
    public interface IWindow_Factory
    {
        IWindow_ZalacznikViewModel create( string message);
        void relase(IWindow_ZalacznikViewModel zalViewModel);
    }
}
