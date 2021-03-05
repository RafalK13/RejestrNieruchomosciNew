using GalaSoft.MvvmLight;
using RejestrNieruchomosciNew.Model.Interfaces;
using RejestrNieruchomosciNew.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RejestrNieruchomosciNew.Model
{
    public class HeaderOpis : ViewModelBase, IHeaderOpis
    {
        public IAdresSloList adresSlo { get; set; }

        private string _numer;
        public string numer
        {
            get { return _numer; }
            set { Set(ref _numer, value); }
        }

        private string _obreb;
        public string obreb
        {
            get { return _obreb; }
            set { Set(ref _obreb, value); }
        }

        private string _gmina;
        public string gmina
        {
            get { return _gmina; }
            set { Set(ref _gmina, value); }
        }

        private string _adres;
        public string adres
        {
            get { return _adres; }
            set { Set(ref _adres, value); }
        }

        public HeaderOpis(UserControl_PreviewViewModel userPrev, IAdresSloList _adresSlo)
        {
            if (userPrev?.dzialkaSel?.Obreb != null)
            {
                numer = userPrev.dzialkaSel.Numer;
                gmina = userPrev.dzialkaSel.Obreb.GminaSlo.Nazwa;
                obreb = userPrev.dzialkaSel.Obreb.Numer;
            }
            adresSlo = _adresSlo;
        }

        private string getAdres(IDzialka dzialka)
        {
            Adres adr = dzialka.Adres;
            if (adr != null)
            {
                if (adr.MiejscowoscSloId != 0)
                {
                    var n1 = adresSlo.miejscList.listAll.FirstOrDefault(r1 => r1.MiejscowoscSloId == adr.MiejscowoscSloId).Nazwa;
                    if (adr.UlicaSloId != null)
                    {
                        try
                        {
                            string n2 = adresSlo.ulicaList.listAll.FirstOrDefault(r2 => r2.UlicaSloId == adr.UlicaSloId).Nazwa;
                            return $"{n1}, {n2} {dzialka.Adres?.Numer}";
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"{ex.Message}\r\n{ex.Source}");
                            return "XXX";
                        }
                       
                    }
                    else
                    {
                        return $"{n1} {dzialka.Adres?.Numer}";
                    }
                }
            }
            return string.Empty;
        }

        public void changeValues(IDzialka dzialka)
        {
            if (dzialka?.Obreb != null)
            {
                numer = dzialka.Numer;
                gmina = dzialka.Obreb.GminaSlo.Nazwa;
                obreb = dzialka.Obreb.Numer;
            }
            else
            {
                gmina = "";
                obreb = "";
            }

            adres = getAdres(dzialka);

            //if (dzialka?.Adres != null)
            //{
            //    adres = $"{dzialka.Adres?.MiejscowoscSlo?.Nazwa} {dzialka.Adres?.UlicaSlo?.Nazwa} {dzialka.Adres?.Numer}";
            //}
            //else
            //    adres = "";
        }
    }
}
