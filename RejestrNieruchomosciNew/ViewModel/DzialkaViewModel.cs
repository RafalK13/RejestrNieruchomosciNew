using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RejestrNieruchomosciNew.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace RejestrNieruchomosciNew.ViewModel
{
    public class DzialkaViewModel : ViewModelBase
    {
        #region Properties
        private ObrebClass _obreb;
        public ObrebClass obreb
        {
            get => _obreb;
            set
            {
                _obreb = value;
                RaisePropertyChanged("obreb");
            }
        } 

        private string _dzialkaNr;
        public string dzialkaNr
        {
            get => _dzialkaNr;
            set
            {
                _dzialkaNr = value;
                RaisePropertyChanged("dzialkaNr");
                setFilter();
            }
        }

        public ICommand leftClick { get; set; }

        #endregion

        #region Konstructor
        public DzialkaViewModel()
        {
            obreb = new ObrebClass();
            leftClick = new RelayCommand(onLeftClick);
        }
        #endregion

        #region Metods
        private void onLeftClick()
        {
            setFilter();
        }

        public void setFilter()
        {
            UserControl_PreviewViewModel d = ServiceLocator.Current.GetInstance<UserControl_PreviewViewModel>();

            if (obreb.getId().HasValue)
            {
                int c = d.dzialkaList.Where(r => r.ObrebId == obreb.getId().Value &&
                                                 r.Numer == dzialkaNr).Count();
                
               
            }

            //bool nb = d.dzialkaList.Where(r => r.Numer == dzialkaNr).Count() > 0 ? true : false;
            //int n = d.dzialkaList.Where(r => r.Numer == dzialkaNr).Count();

            //MessageBox.Show(obreb.getId().ToString());
            //bool nb = !string.IsNullOrEmpty(dzialkaNr) ? d.dzialkaList.Contains(dzialkaNr) : false;
            //bool ob = !string.IsNullOrEmpty(obreb.obrebValue) ? d..Obreb.Nazwa.Contains(obreb.obrebValue) : false;
            //bool gb = !string.IsNullOrEmpty(obreb.gminaValue) ? d.Obreb.GminaSlo.Nazwa.Contains(obreb.gminaValue) : false;

            //if ((nb && ob && gb) == true)
            //    MessageBox.Show("OK");

            //if (nb == true)
            //    MessageBox.Show("OK");


            #endregion
        }
    }
}
