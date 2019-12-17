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

        //public PlatnoscUW platnoscUW { get; set; }
        //public PlatnoscList platnoscList { get; set; }

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

        public UserControl_PlatnoscUWViewModel(UserControl_PreviewViewModel userPrev,
                                               PlatnoscList platnoscList)
        {

            if (userPrev.dzialkaSel != null)
            {
                platnoscUW = platnoscList.listPlatnoscUW.FirstOrDefault(r => r.DzialkaId == userPrev.dzialkaSel.DzialkaId);

            }

            initButtons();

            //sellVisibility = Visibility.Hidden;

            //if (userPrev.dzialkaSel != null)
            //{
            //    dzialkaId = int.Parse(userPrev.dzialkaSel.DzialkaId.ToString());
            //}

            //podmiotDetail = false;
        }

        private void initButtons()
        {
            platnosciUWAdd = new RelayCommand(clickPlatnosciAdd);
            
        }
        
        private void clickPlatnosciAdd()
        {
            platnoscUW.save( platnoscUW);
        }
    }
}       
    

