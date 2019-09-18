using Castle.Windsor;
using Castle.Windsor.Installer;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.EntityFrameworkCore;
using RejestrNieruchomosciNew.Installers;
using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.View;
using RejestrNieruchomosciNew.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RejestrNieruchomosciNew
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            WindsorContainer container = new WindsorContainer();
            container.Install(FromAssembly.This());
            
            var view = container.Resolve<MainView>();
            view.Show();
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
