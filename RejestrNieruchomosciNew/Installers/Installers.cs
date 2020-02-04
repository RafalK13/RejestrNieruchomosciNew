﻿using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.Model.Interfaces;
using RejestrNieruchomosciNew.View;
using RejestrNieruchomosciNew.ViewModel;

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

            container.Register(Component.For<UserControl_Wlasciciel>().LifeStyle.Transient);
            container.Register(Component.For<UserControl_WlascicielViewModel>().LifeStyle.Transient);

            container.Register(Component.For<UserControl_InnePrawa>().LifeStyle.Transient);
            container.Register(Component.For<UserControl_InnePrawaViewModel>().LifeStyle.Transient);

            container.Register(Component.For<ISelectorModel>().ImplementedBy<SelectorModel>().LifeStyle.Transient);
            container.Register(Component.For<IChangeViewModel>().ImplementedBy<AddViewModel>().Named("Add").LifeStyle.Transient);
            container.Register(Component.For<IChangeViewModel>().ImplementedBy<ModViewModel>().Named("Mod").LifeStyle.Transient);

            container.Register(Component.For<IContrlosVisibling>().ImplementedBy<ContrlosVisibling>());

            container.Register(Component.For<IPodmiot>().ImplementedBy<Podmiot>());
            container.Register(Component.For<IPodmiotList>().ImplementedBy<PodmiotList>());

            container.Register(Component.For<IWladanie>().ImplementedBy<Wladanie>().LifeStyle.Transient);
            container.Register(Component.For<IWladanieList>().ImplementedBy<WladanieList>().LifeStyle.Transient);

            container.Register(Component.For<IInnePrawa>().ImplementedBy<InnePrawa>().LifeStyle.Transient);
            container.Register(Component.For<IInnePrawaList>().ImplementedBy<InnePrawaList>().LifeStyle.Transient);

            container.Register(Component.For<IFormaWladaniaSlo>().ImplementedBy<FormaWladaniaSlo>());
            container.Register(Component.For<FormaWladaniaList>());

            container.Register(Component.For<ITransakcje>().ImplementedBy<Transakcje>().LifeStyle.Transient);
            container.Register(Component.For<ITransakcjeList>().ImplementedBy<TransakcjeList>());

            container.Register(Component.For<IRodzajTransakcjiSlo>().ImplementedBy<RodzajTransakcjiSlo>());
            container.Register(Component.For<RodzajTransakcjiList>());
            container.Register(Component.For<INazwaCzynosciSlo>().ImplementedBy<NazwaCzynnosciSlo>());
            container.Register(Component.For<NazwaCzynnosciList>());
            container.Register(Component.For<IRodzajDokumentuSlo>().ImplementedBy<RodzajDokumentuSlo>());
            container.Register(Component.For<RodzajDokumentuList>());

            container.Register(Component.For<IRodzajInnegoPrawaSlo>().ImplementedBy<RodzajInnegoPrawaSlo>());
            container.Register(Component.For<RodzajInnegoPrawaList>());

            container.Register(Component.For<Window2>());
            container.Register(Component.For<Window2ViewModel>());

            container.Register(Component.For<UserControl_Transakcja>());
            container.Register(Component.For<UserControl_TransViewModel>());

            container.Register(Component.For<ICelNabyciaList>().ImplementedBy<CelNabyciaList>());

            container.Register(Component.For<UserControl_CelNabycia>());

            container.Register(Component.For<PlatnoscUW>().LifeStyle.Transient);
            container.Register(Component.For<PlatnoscList>());

            container.Register(Component.For<PlatnoscInnePrawa>().LifeStyle.Transient);
            container.Register(Component.For<UserControl_PlatnoscUWViewModel>().LifeStyle.Transient);

            container.Register(Component.For<DecyzjeAdministracyjne>());
            container.Register(Component.For<DecyzjeAdministracyjneList>());

            container.Register(Component.For<UserControl_Test>());

            container.Register(Component.For<UserControl_DecyzjeAdmin>());

            container.Register(Component.For<IUzytki>().ImplementedBy<Uzytki>().LifeStyle.Transient);
            container.Register(Component.For<IUzytkiSlo>().ImplementedBy<UzytkiSlo>());
            container.Register(Component.For<IUzytkiList>().ImplementedBy<UzytkiList>().LifeStyle.Transient);
            container.Register(Component.For<IUzytkiSloList>().ImplementedBy<UzytkiSloList>());
            container.Register(Component.For<UserControl_Uzytki>());

            container.Register(Component.For<UserControl_DaneDodatkowe>().LifeStyle.Transient);
            container.Register(Component.For<UserControl_DaneDodatkoweViewModel>().LifeStyle.Transient);

            container.Register(Component.For<INadzorKonserwSlo>().ImplementedBy<NadzorKonserwSlo>());
            container.Register(Component.For<INadzorKonserwatoraSloList>().ImplementedBy<NadzorKonserwatoraSloList>());

            container.Register(Component.For<IZagosp>().ImplementedBy<Zagosp>().LifeStyle.Transient);
            container.Register(Component.For<IZagospList>().ImplementedBy<ZagospList>().LifeStyle.Transient);
            container.Register(Component.For<IZagospFunkcjaSlo>().ImplementedBy<ZagospFunkcjaSlo>());
            container.Register(Component.For<IZagospStatusSlo>().ImplementedBy<ZagospStatusSlo>());
            container.Register(Component.For<ZagospFunkcjaSloList>());
            container.Register(Component.For<ZagospStatusSloList>());

            container.Register(Component.For<UserControl_Zagosp>().LifeStyle.Transient);
            container.Register(Component.For<UserControl_ZagospViewModel>().LifeStyle.Transient);
        }
    }
}
