using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Windows;
using System.Windows.Input;

namespace RejestrNieruchomosciNew.ViewModel
{
    public class UserControl_InfoWladanieViewModel : ViewModelBase
    {
        public ICommand onClick { get; set; }

        public RodzajDokumentuList rodzDokList { get; set; }
        public NazwaCzynnosciList nazwaCzynList { get; set; }

        private IWladanie _wladanieSel;
        public IWladanie wladanieSel
        {
            get => _wladanieSel;
            set {
                _wladanieSel = value;
                RaisePropertyChanged();
            }
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

        private IWladanieList _wladanieList;
        public IWladanieList wladanieList
        {
            get => _wladanieList;
            set
            {
                _wladanieList = value;
                RaisePropertyChanged();
            }
        }

        private void Prev_zmianaDzialkaSel(object sender, System.EventArgs e)
        {
            if (prev != null)
            {
                wladanieList.getList(prev.dzialkaSel);
            }
        }

        public UserControl_InfoWladanieViewModel()
        {
            onClick = new RelayCommand( onClickSkan);
        }

        private void onClickSkan()
        {
            MessageBox.Show("Rafałek");
        }
    }
}
