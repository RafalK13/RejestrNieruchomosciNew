using Castle.Core;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace RejestrNieruchomosciNew.ViewModel
{
    public class UserControl_DaneDodatkoweViewModel : ViewModelBase
    {
        private IDzialka _dzialka;
        [DoNotWire]
        public IDzialka dzialka
        {
            get => _dzialka;
            set
            {
                _dzialka = value;
                RaisePropertyChanged();
            }
        }

        private bool _sizeAlert;
        public bool sizeAlert { get => _sizeAlert; set { Set(ref _sizeAlert, value); } }

        public ObservableCollection<Uzytki> uzytkiListLok { get; set; }

        public IUzytkiList uzytkiList { get; set; }

        public IUzytkiSloList uzytkiSloList { get; set; }

        public ICommand daneDodAdd { get; set; }

        public IDzialkaList dzialkaList { get; set; }

        public UserControl_PreviewViewModel userPrev { get; set; }

        private double? _powUzTotal;
        public double? powUzTotal
        {
            get => _powUzTotal;
            set { Set(ref _powUzTotal, value); }
        }

        //public INadzorKonserwatoraSloList nadzorKons { get; set; }

        public UserControl_DaneDodatkoweViewModel(IDzialka _dzialka,
                                                  UserControl_PreviewViewModel _prev,
                                                  IUzytkiList _uzytkiList
                                                 )
        {
            if (_prev?.dzialkaSel != null)
            {
                dzialka = _dzialka;
                uzytkiList = _uzytkiList;

                dzialka.copy(_prev.dzialkaSel);
                //_prev.dzialkaSel.Kwzrob = "NowyNr";
                //_prev.dzialkaView.Refresh();
                //dzialka = _dzialka;
                //dzialka.copy(dzialka);
               
                
                uzytkiList.getList(dzialka);

                uzytkiListLok = new ObservableCollection<Uzytki>(uzytkiList.list.Select(r => new Uzytki(r)).ToList());
               
            }

            daneDodAdd = new RelayCommand(onDaneDodAdd);
            int x = 1;
        }

        private void onDaneDodAdd()
        {
            int x1 = 13;
            uzytkiList.getList(dzialka);
            uzytkiList.list = new ObservableCollection<Uzytki>(uzytkiListLok.Select(r => new Uzytki(r)).ToList());
            int x = 13;
            uzytkiList.saveUzytki();
     
            //dzialkaList.ModRow(dzialka);
  
            //userPrev.dzialkaView.Refresh();
        }
    }
}
