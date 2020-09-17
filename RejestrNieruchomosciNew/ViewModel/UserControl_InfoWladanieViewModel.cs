using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore;
using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.Model.Interfaces;
using RejestrNieruchomosciNew.View;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace RejestrNieruchomosciNew.ViewModel
{
    public class UserControl_InfoWladanieViewModel : ViewModelBase
    {

        public RodzajDokumentuList rodzDokList { get; set; }
        public NazwaCzynnosciList nazwaCzynList { get; set; }
        public ICelNabyciaList celNabyciaList { get; set; }

        private IWladanie _wladanieSel;
        public IWladanie wladanieSel
        {
            get => _wladanieSel;
            set
            {
                _wladanieSel = value;
                //getWladanieSel();
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
                if( prev.dzialkaSel != null)
                    wladanieList.getList(prev.dzialkaSel);
                else
                    wladanieList.list = null;
            }
        }

        public UserControl_InfoWladanieViewModel()
        {
        }
    }
}
