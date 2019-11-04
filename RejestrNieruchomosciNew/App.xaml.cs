using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using RejestrNieruchomosciNew.Installers;
using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace RejestrNieruchomosciNew
{
    public partial class App : Application
    {
        private static readonly WindsorContainer container = new WindsorContainer();

        private void Application_Startup(object sender, StartupEventArgs e)
        {
           
            container.Install(FromAssembly.This());

            //var view = container.Resolve<MainView>();
            var view = container.Resolve<Window2>();
            view.Show();

            //container.Dispose();
        }
    }

    class MakeInitDatabase
    {
        Random r1 = new Random();
        Random r2 = new Random();

        public MakeInitDatabase()
        {
            using (var c = new Context())
            {
                int len = 10;
                List<Obreb> o = c.Obreb.ToList();
                int n = c.Obreb.Count();

                Random r = new Random();

                for (int i = 0; i < len; i++)
                {
                    c.Dzialka.Add(new Dzialka() { Numer = i.ToString(), Kwakt = getNrKW(), Kwzrob = getNrKW(), Pow = r.Next(800, 5000), ObrebId = o[r.Next(n - 1)].ObrebId });
                }
                c.SaveChanges();
            }
        }

        private string getNrKW()
        {
            return string.Format("GD1G/{0:D6}/{1}", r1.Next(20, 99999), r2.Next(1, 10));
        }
    }
}
