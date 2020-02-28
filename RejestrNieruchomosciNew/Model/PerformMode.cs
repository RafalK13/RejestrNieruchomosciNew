namespace RejestrNieruchomosciNew.Model
{
    public class PerformMode
    {
        public enum userMode { mod, prev }
        public enum appMode { main, dod }

        public userMode userMod { get; set; }
        public appMode appMod { get; set; }

        public PerformMode()
        {
            userMod = userMode.mod;
            appMod = appMode.main;
        }
    }
}
