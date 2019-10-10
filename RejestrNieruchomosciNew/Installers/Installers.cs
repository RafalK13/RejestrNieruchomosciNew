﻿using Castle.MicroKernel.Registration;
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

            container.Register(Component.For<IDzialka>().ImplementedBy<Dzialka>().LifeStyle.Transient);
            
            container.Register(Component.For<IDzialkaList>().ImplementedBy<DzialkaList>());

            container.Register(Component.For<ObrebClass>().LifeStyle.Transient);

            container.Register(Component.For<ChangeView>().LifeStyle.Transient);

            container.Register(Component.For<UserControl_DanePodstawowe>().LifeStyle.Transient);
            container.Register(Component.For<UserControl_DanePodstawoweViewModel>().LifeStyle.Transient);
            
            container.Register(Component.For<UserControl_PreviewViewModel>());

            container.Register(Component.For<ISelectorModel>().ImplementedBy<SelectorModel>().LifeStyle.Transient);
            container.Register(Component.For<IChangeViewModel>().ImplementedBy<AddViewModel>().Named("Add").LifeStyle.Transient);
            container.Register(Component.For<IChangeViewModel>().ImplementedBy<ModViewModel>().Named("Mod").LifeStyle.Transient);

            container.Register(Component.For<Window2>());

            container.Register(Component.For<IContrlosVisibling>().ImplementedBy<ContrlosVisibling>());

            container.Register(Component.For<IPodmiot>().ImplementedBy<Podmiot>());
            container.Register(Component.For<IPodmiotList>().ImplementedBy<PodmiotList>());



        }
    }
}
