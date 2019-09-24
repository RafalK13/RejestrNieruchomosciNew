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
            container.Register(Component.For<IObrebList>().ImplementedBy<ObrebList>());

            container.Register(Component.For<IDzialka>().ImplementedBy<Dzialka>().LifeStyle.Transient);
            container.Register(Component.For<IDzialkaList>().ImplementedBy<DzialkaList>().LifeStyle.Transient);
            //container.Register(Component.For<DzialkaList>());
            container.Register(Component.For<ObrebClass>().LifeStyle.Transient);
            container.Register(Component.For<AddView>().LifeStyle.Transient);
            container.Register(Component.For<AddViewModel>().LifeStyle.Transient);
            container.Register(Component.For<UserControl_Add_danePodstawoweViewModel>().LifeStyle.Transient);
            container.Register(Component.For<UserControl_PreviewViewModel>());

            

            container.Register(Component.For<Window2>());

            container.Register(Component.For<MainView>());
            container.Register(Component.For<MainViewModel>());
        }
    }
}
