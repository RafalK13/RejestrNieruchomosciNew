using Castle.Core;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace RejestrNieruchomosciNew.ViewModel
{
    public class UserControl_DaneDodatkoweViewModel : ViewModelBase
    {
        //private UserControl_PreviewViewModel _userPrev;
        //public UserControl_PreviewViewModel userPrev
        //{
        //    get => _userPrev;
        //    set
        //    {
        //        _userPrev = value;
        //        RaisePropertyChanged();

        //        dzialka = userPrev.dzialkaSel;
        //        //userPrev.zmianaDzialkaSel += UserPrev_zmianaDzialkaSel1;
        //    }
        //}

        //private void UserPrev_zmianaDzialkaSel1(object sender, EventArgs e)
        //{
        //    if (userPrev?.dzialkaSel != null)
        //        dzialka = (Dzialka)userPrev.dzialkaSel.clone();
        //}

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

        public IUzytkiList uzytkiList { get; set; }

        public IUzytkiSloList uzytkiSloList { get; set; }

        public ICommand daneDodAdd { get; set; }

        public IDzialkaList dzialkaList { get; set; }

        //public UserControl_PreviewViewModel prev { get; set; }

        public INadzorKonserwatoraSloList nadzorKons { get; set; }

        public UserControl_DaneDodatkoweViewModel(IDzialka _dzialka,
                                                  UserControl_PreviewViewModel _prev
                                                 ) 
        {

            if (_prev?.dzialkaSel != null)
            {
               

                dzialka = (IDzialka)_prev.dzialkaSel.clone();

                _prev.dzialkaView.Refresh();
            }


            daneDodAdd = new RelayCommand( onDaneDodAdd);
           
            
        }

        private void onDaneDodAdd()
        {
            uzytkiList.saveUzytki();

            //int n = dzialkaList.list.FindIndex(r => r.DzialkaId == dzialka.DzialkaId);

            //dzialkaList.list.Insert(n, (IDzialka)dzialka.clone());

            //prev.dzialkaView.Refresh();


            dzialkaList.ModRow(dzialka);
        }
    }
}
