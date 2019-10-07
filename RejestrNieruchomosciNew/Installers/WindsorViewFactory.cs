using Castle.Windsor;
using RejestrNieruchomosciNew.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Installers
{
    public class WindsorViewFactory : IViewFactory
    {
        private readonly IWindsorContainer container;

        public WindsorViewFactory(IWindsorContainer container)
        {
            this.container = container;
        }

        //public T CreateView<T>() where T : IView
        //{
        //    return container.Resolve<T>();
        //}

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
