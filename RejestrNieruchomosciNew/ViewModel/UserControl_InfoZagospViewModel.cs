using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RejestrNieruchomosciNew.ViewModel
{
    public class UserControl_InfoZagospViewModel : ViewModelBase
    {
        public ICommand onClick { get; set; }

        public IPodmiotList podmiotList { get; set; }

        private IZagospList _zagospList;
        public IZagospList zagospList
        {
            get => _zagospList;

            set
            {
                _zagospList = value;
                RaisePropertyChanged();
            }
        }

        private IZagosp _zagospSel;
        public IZagosp zagospSel
        {
            get => _zagospSel;
            set
            {
                _zagospSel = value;
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

        private void Prev_zmianaDzialkaSel(object sender, System.EventArgs e)
        {
            if (prev != null)
            {
                zagospList.getList(prev.dzialkaSel);
                
                int r = 13;
            }
        }

        public ICelNabyciaList celNabList { get; set; }

        public UserControl_InfoZagospViewModel()
        {
            onClick = new RelayCommand(onClickSkan);
        }

        private void onClickSkan()
        {
            MessageBox.Show("Rafałek");
        }
    }
}