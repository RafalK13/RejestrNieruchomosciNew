using Castle.Windsor;
using RejestrNieruchomosciNew.Model;

namespace RejestrNieruchomosciNew.Installers
{
    public class WindsorViewFactory : IViewFactory
    {
        private readonly IWindsorContainer container;

        public WindsorViewFactory(IWindsorContainer container)
        {
            this.container = container;
        }

        T IViewFactory.CreateView<T>()
        {
            return container.Resolve<T>();
        }

        T IViewFactory.CreateView<T>( string s)
        {
            return container.Resolve<T>( s);
        }
    }
}
