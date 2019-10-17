using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(RejestrNieruchomosciNew.Startup1))]

namespace RejestrNieruchomosciNew
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            // Aby uzyskać więcej informacji o sposobie konfigurowania aplikacji, odwiedź stronę https://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
