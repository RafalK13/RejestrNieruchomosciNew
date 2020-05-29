using Castle.Core;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RejestrNieruchomosciNew.Model;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace RejestrNieruchomosciNew.ViewModel
{
    public class UserControl_PlatnoscUWViewModel : ViewModelBase
    {
        [DoNotWire]
        public PlatnoscUW platnoscUW { get; set; }

        public ICommand platnosciUWAdd { get; set; }

        private Visibility _sellVisibility;
        public Visibility sellVisibility
        {
            get => _sellVisibility;

            set
            {
                _sellVisibility = value;
                RaisePropertyChanged("sellVisibility");
            }
        }

        public UserControl_PreviewViewModel userPrev { get; set; }

        public UserControl_PlatnoscUWViewModel(UserControl_PreviewViewModel _userPrev,
                                           
                                               PlatnoscUW _platnoscUW)
        {

            if (_userPrev?.dzialkaSel?.PlatnoscUW != null)
            {
                _platnoscUW = _userPrev.dzialkaSel.PlatnoscUW;
            }

            platnoscUW = _platnoscUW;
            initButtons();
        }

        private void initButtons()
        {
            platnosciUWAdd = new RelayCommand(clickPlatnosciAdd);
        }
        
        private void clickPlatnosciAdd()
        {
            platnoscUW.Dzialka = userPrev.dzialkaSel as Dzialka;
            platnoscUW.DzialkaId = userPrev.dzialkaSel.DzialkaId;
            platnoscUW.save(platnoscUW);

            userPrev.dzialkaSel.PlatnoscUW = platnoscUW.clone();
            userPrev.dzialkaView.Refresh();
        }
    }
}       
    

