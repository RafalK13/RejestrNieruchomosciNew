using RejestrNieruchomosciNew.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RejestrNieruchomosciNew.ViewModel
{
    public class AddViewModel : ChangeClass
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
                OnPropertyChanged("modeMessage");
            }
        }

        public bool canAdd
        {
            get => _canAdd;
            set
            {
                _canAdd = value;
                OnPropertyChanged("canAdd");
            }
        }

        public DzialkaViewModel dzialkaViewModel { get; set; }

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

        #region Medods
        #endregion
    }
}
