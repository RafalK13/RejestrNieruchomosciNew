using GalaSoft.MvvmLight;
using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.ViewModel
{
    public class UserControl_InfoBudynkiViewModel : ViewModelBase
    {
        public IAdresSloList adresSloList { get; set; }

        private IBudynek _budynekSel;

        public IBudynek budynekSel
        {
            get { return _budynekSel; }
            set
            {
                _budynekSel = value;
                RaisePropertyChanged();
                getDzialkiPrzyn();
            }
        }

        private void getDzialkiPrzyn()
        {
            if (budynekSel?.Dzialka_Budynek != null)
            {
                var dzialkaListBudAll = new List<IDzialka>(budynekSel.Dzialka_Budynek.Select(r => r.Dzialka).ToList());
                var dzialkaIn = new List<IDzialka>(new Dzialka[] { (Dzialka)prev.dzialkaSel });
                dzialkaListBud = new ObservableCollection<IDzialka>(dzialkaListBudAll.Except(dzialkaIn).ToList());
            }
        }

        private ICollection<IDzialka> _dzialkaListBud;

        public ICollection<IDzialka> dzialkaListBud
        {
            get { return _dzialkaListBud; }
            set
            {
                _dzialkaListBud = value;
                RaisePropertyChanged();
            }
        }





        private IBudynkiList _budynkiList;

        public IBudynkiList budynkiList
        {
            get { return _budynkiList; }
            set { _budynkiList = value; }
        }

        private UserControl_PreviewViewModel _prev;
        public UserControl_PreviewViewModel prev
        {
            get => _prev;
            set
            {
                _prev = value;
                RaisePropertyChanged();
                prev.zmianaDzialkaSel += Prev_zmianaDzialkaSel;
            }
        }

        private void Prev_zmianaDzialkaSel(object sender, System.EventArgs e)
        {
            if (prev != null)
            {
                budynkiList.getList(prev.dzialkaSel);

            }
        }


    }
}
