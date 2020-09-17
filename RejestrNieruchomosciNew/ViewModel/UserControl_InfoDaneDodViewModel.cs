using GalaSoft.MvvmLight;
using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RejestrNieruchomosciNew.ViewModel
{
    public class UserControl_InfoDaneDodViewModel : ViewModelBase
    {
        private UserControl_PreviewViewModel _prev;
        public UserControl_PreviewViewModel prev
        {
            get => _prev;
            set {
                _prev = value;
                RaisePropertyChanged();
                prev.zmianaDzialkaSel += Prev_zmianaDzialkaSel;
            } }

        private void Prev_zmianaDzialkaSel(object sender, EventArgs e)
        {
            if (prev.dzialkaSel != null)
            {
                uzytki.getList(prev.dzialkaSel);
            }
            else
                uzytki.list = null;
        }

        public IUzytkiList uzytki { get; set; }

    }
}
