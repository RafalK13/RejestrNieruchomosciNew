using GalaSoft.MvvmLight;
using RejestrNieruchomosciNew.Model;
using System.Windows;

namespace RejestrNieruchomosciNew.ViewModel
{
    public class UserControl_InfoWladanieViewModel : ViewModelBase
    {
        public IPodmiotList podmiotList { get; set; }

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

        //public UserControl_InfoWladanieViewModel(UserControl_PreviewViewModel p,
        //                                         IWladanieList w)
        //{
        //    MessageBox.Show("Konstriktor2");

        //    wladanieList = w;
        //    p.zmianaDzialkaSel += P_zmianaDzialkaSel;
        //    prev = p;
        //}

        //private void P_zmianaDzialkaSel(object sender, System.EventArgs e)
        //{
        //    if (prev != null)
        //    {
        //        wladanieList.getList(prev.dzialkaSel);
        //    }
        //}
    }
}
