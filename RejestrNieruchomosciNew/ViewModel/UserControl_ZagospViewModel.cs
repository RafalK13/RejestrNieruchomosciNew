using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RejestrNieruchomosciNew.ViewModel
{
    public class UserControl_ZagospViewModel : ViewModelBase
    {
        public ICelNabyciaList celNabyciaList { get; set; }

        public UserControl_PreviewViewModel userPrev { get; set; }

        public ZagospFunkcjaSloList zagFunList { get; set; }
        public ZagospStatusSloList zagStaList { get; set; }

        public IZagosp zagospSel { get; set; }
        public IZagospList zagospList { get; set; }

        private string _nazwa;
        public string nazwa
        {
            get => _nazwa;
            set
            {
                _nazwa = value;
                RaisePropertyChanged();
            }
        }

        public ICommand nazwaAdd { get; set; }
        public ICommand nazwaDel { get; set; }
        public ICommand zagospAdd { get; set; }

        public UserControl_ZagospViewModel()
        {
            nazwaAdd = new RelayCommand(onNazwaAll);
            nazwaDel = new RelayCommand(onNazwaDel);
            zagospAdd = new RelayCommand(onZagospAdd);
        }

        private void onZagospAdd()
        {
            zagospList.saveZagosp();
        }

        private void onNazwaDel()
        {
            zagospList.list.Remove(zagospSel);
        }

        private void onNazwaAll()
        {
            if (testIfExist())
            {
                zagospList.list.Add(new Zagosp() { Nazwa = nazwa, DzialkaId = userPrev.dzialkaSel.DzialkaId });
                nazwa = string.Empty;
            }
        }

        private bool testIfExist()
        {
            return zagospList.list.FirstOrDefault(r => r.Nazwa == nazwa) == null ? true : false;
        }
    }
}
