using GalaSoft.MvvmLight;
using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Linq;

namespace RejestrNieruchomosciNew.ViewModel
{
    public class UserControl_InfoDaneDodViewModel : ViewModelBase
    {
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

        private void Prev_zmianaDzialkaSel(object sender, EventArgs e)
        {
            if (prev.dzialkaSel != null)
            {
                uzytki.getList(prev.dzialkaSel);
                pow = uzytki.list.Sum(r => r.Pow);
                if (pow == 0)
                    pow = null;
            }
            else
                uzytki.list = null;
        }

        private double? _pow;

        public double? pow
        {
            get { return _pow; }
            set
            {
                _pow = value;
                RaisePropertyChanged();
            }
        }


        public IUzytkiList uzytki { get; set; }

    }
}
