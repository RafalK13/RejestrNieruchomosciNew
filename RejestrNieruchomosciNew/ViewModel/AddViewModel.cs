using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using RejestrNieruchomosciNew.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RejestrNieruchomosciNew.ViewModel
{
    public class AddViewModel : ViewModelBase
    {
        #region private Properties
        private string _modeMessage;
        private bool _canAdd;
        #endregion

        public string modeMessage
        {
            get => _modeMessage;
            set
            {
                _modeMessage = value;
                RaisePropertyChanged("modeMessage");
            }
        }

        public bool canAdd
        {
            get => _canAdd;
            set
            {
                _canAdd = value;
                RaisePropertyChanged("canAdd");
            }
        }

        public ICommand closeWindow { get; set; }

        public DzialkaViewModel dzialkaViewModel { get; set; }

        #region Konstruktor
        public AddViewModel()
        {
            closeWindow = new RelayCommand(onCloseWindow);
        }
        #endregion
        
        #region Medods
        private void onCloseWindow()
        {
            #region obsługa messenger -REM
            //Messenger.Default.Send<MessagesRaf>( new MessagesRaf() { activity=true }, "Token1" );
            #endregion

            var v = ServiceLocator.Current.GetInstance<MainViewModel>();
            v.btActivity = true;
        }

        //public int? isDzialka()
        //{
        //    int? obrebId = dzialkaViewModel.obreb.getId();
        //    string numer = dzialkaViewModel.dzialka.Numer;

        //    if (obrebId.HasValue && !string.IsNullOrEmpty(numer))
        //    {
        //        using (var c = new Context())
        //        {
        //            var o = c.Dzialka.AsQueryable().FirstOrDefault(n => n.ObrebId == obrebId && n.Numer == numer);//.DzialkaId;

        //            if (o != null)
        //            {


        //                return o.DzialkaId;
        //            }
        //            else
        //            {
        //               // dzialkaViewModel.dzialka.ObrebId = obrebId.Value;
        //                return 0;
        //            }

        //            //return o != null ? o.DzialkaId : 0;
        //        }
        //    }
        //    return null;

        //}

        //public AddViewModel()
        //{
        //    modeMessage = "Dodawanie nowego rekordu";
        //    canAdd = false;

        //    dzialkaViewModel = new DzialkaViewModel();

        //    dzialkaViewModel.obreb.PropertyChanged += dzialkaViewModel_PropertyChanged;
        //    dzialkaViewModel.dzialka.PropertyChanged += dzialkaViewModel_PropertyChanged;
        //}

        //private void dzialkaViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    canAdd = isDzialka()==0 ? true : false;
        //}
        #endregion
    }
}
