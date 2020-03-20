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

        public ObservableCollection<Uzytki> uzytkiListLok { get; set; }

        public IUzytkiList uzytkiList { get; set; }

        public IUzytkiSloList uzytkiSloList { get; set; }

        public ICommand daneDodAdd { get; set; }

        public IDzialkaList dzialkaList { get; set; }

        public UserControl_PreviewViewModel userPrev { get; set; }

        public INadzorKonserwatoraSloList nadzorKons { get; set; }

        public UserControl_DaneDodatkoweViewModel(IDzialka _dzialka,
                                                  UserControl_PreviewViewModel _prev,
                                                  IUzytkiList _uzytkiList
                                                 ) 
        {
            if (_prev?.dzialkaSel != null)
            {
                dzialka = (IDzialka)_prev.dzialkaSel.clone();

                _prev.dzialkaView.Refresh();
            }

            _uzytkiList.getList(_prev.dzialkaSel);
            uzytkiListLok = new ObservableCollection<Uzytki>(_uzytkiList.list.Select(r => new Uzytki(r)).ToList());

            daneDodAdd = new RelayCommand( onDaneDodAdd);
        }

        private void onDaneDodAdd()
        {
            uzytkiList.list = new ObservableCollection<Uzytki>(uzytkiListLok.Select(r => new Uzytki(r)).ToList());
            uzytkiList.saveUzytki();

            dzialkaList.ModRow(dzialka);

            userPrev.dzialkaSel = dzialka;
        }
    }
}
