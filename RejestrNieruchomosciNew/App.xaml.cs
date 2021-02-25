using Castle.Windsor;
using Castle.Windsor.Installer;
using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.Model.Interfaces;
using RejestrNieruchomosciNew.View;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Markup;

namespace RejestrNieruchomosciNew
{
    public partial class App : Application
    {
        private static readonly WindsorContainer container = new WindsorContainer();

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            //var currentCulture = System.Threading.Thread.CurrentThread.CurrentCulture.Name;
            //var ci = new CultureInfo(currentCulture)
            //{
            //    NumberFormat = { NumberDecimalSeparator = "." },
            //    DateTimeFormat = { DateSeparator = "/" }
            //};
            //System.Threading.Thread.CurrentThread.CurrentCulture = ci;
            //System.Threading.Thread.CurrentThread.CurrentUICulture = ci;
            //FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));

            //MessageBox.Show( $"UserName:{Environment.UserName}");

            CultureInfo ci = new CultureInfo("pl-PL");

            ci.NumberFormat.NumberDecimalSeparator = ".";


            Thread.CurrentThread.CurrentCulture = ci;

            container.Install(FromAssembly.This());

            using (var c = new Context())
            {
                try
                {
                    c.Database.CanConnect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Błąd podłączenia z bazą danych\r\n{ ex.Message}");
                    Environment.Exit(0);
                }
            }

            //var view = container.Resolve<WindowTestRaf>();

            var mode = container.Resolve<PerformMode>();

            using (var c = new Context())
            {
                var u = c.User.FirstOrDefault(r => r.name == Environment.UserName);

                if (u != null)
                {
                    if (u.admin == true)
                        mode.workMod = PerformMode.workMode.admin;
                }
            }



                var view = container.Resolve<MainView>();
            //var view = container.Resolve<Window2>();
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
