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
            container.Register(Component.For<IWindsorContainer>().Instance(container));
            container.Register(Component.For<IViewFactory>().ImplementedBy<WindsorViewFactory>());

            container.Register(Component.For<MainView>());
            container.Register(Component.For<MainViewModel>());

            container.Register(Component.For<ChangeViewModel>());

            container.Register(Component.For<IObrebList>().ImplementedBy<ObrebList>());

            container.Register(Component.For<IDzialka>().ImplementedBy<Dzialka>());
            //container.Register(Component.For<IDzialka>().ImplementedBy<Dzialka>().Named("dzialkaNew").LifeStyle.Transient);

            container.Register(Component.For<IDzialkaList>().ImplementedBy<DzialkaList>().LifeStyle.Transient);

            container.Register(Component.For<ObrebClass>());

            container.Register(Component.For<ChangeView>().LifeStyle.Transient);

            //container.Register(Component.For<AddViewModel>().LifeStyle.Transient);

            container.Register(Component.For<UserControl_DanePodstawowe>());
            container.Register(Component.For<UserControl_DanePodstawoweViewModel>());

            container.Register(Component.For<UserControl_PreviewViewModel>());

            container.Register(Component.For<ISelectorModel>().ImplementedBy<SelectorModel>());
            container.Register(Component.For<IChangeViewModel>().ImplementedBy<AddViewModel>().Named("Add"));

            //container.Register(Component.For<IChangeViewModel>().ImplementedBy<AddViewModel>().Named("Add")
            //                  .DependsOn( Dependency.OnComponent( "dzialka", "dzialkaNew"))
            //                  );

            container.Register(Component.For<IChangeViewModel>().ImplementedBy<ModViewModel>().Named("Mod"));

            container.Register(Component.For<Window2>());

        }
    }
}
