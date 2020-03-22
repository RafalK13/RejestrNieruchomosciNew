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
    public class UserControl_InfoInnePrawaViewModel : ViewModelBase
    {
        public ICommand onClick { get; set; }

        public RodzajDokumentuList rodzDokList { get; set; }
        public NazwaCzynnosciList nazwaCzynList { get; set; }
        public ICelNabyciaList celNabyciaList { get; set; }

        public IPodmiotList podmiotList { get; set; }

        private IInnePrawa _innePrawaSel;
        public IInnePrawa innePrawaSel
        {
            get => _innePrawaSel;
            set
            {
                _innePrawaSel = value;
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

        private IInnePrawaList _innePrawaList;
        public IInnePrawaList innePrawaList
        {
            get => _innePrawaList;
            set
            {
                _innePrawaList = value;
                RaisePropertyChanged();
            }
        }

        private void Prev_zmianaDzialkaSel(object sender, System.EventArgs e)
        {
            if (prev != null)
            {
                innePrawaList.getList(prev.dzialkaSel);
            }
        }

        public UserControl_InfoInnePrawaViewModel()
        {
            onClick = new RelayCommand(onClickSkan);
        }

        private void onClickSkan()
        {
            MessageBox.Show("Rafałek");
        }
    }
}