using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.View;
using RejestrNieruchomosciNew.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Installers
{
    public class InstallersAdd : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IDzialka>().ImplementedBy<Dzialka>());
            container.Register(Component.For<ObrebClass>());
            container.Register(Component.For<AddView>());
            container.Register(Component.For<AddViewModel>());
            container.Register(Component.For<UserControl_Add_danePodstawoweViewModel>());
        }
    }
}
