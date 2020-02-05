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
    public class UserControl_ZagospViewModel : ViewModelBase
    {
        public ICelNabyciaList celNabyciaList { get; set; }

        public UserControl_PreviewViewModel userPrev { get; set; }

        public ZagospFunkcjaSloList zagFunList { get; set; }
        public ZagospStatusSloList zagStaList { get; set; }

        private bool _podmiotDetail;
        public bool podmiotDetail
        {
            get => _podmiotDetail;

            set
            {
                _podmiotDetail = value;
                RaisePropertyChanged("podmiotDetail");
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

                testPodmiotDetail();
            }
        }

        private void testPodmiotDetail()
        {
            if (zagospSel != null)
            {
                if (zagospSel.DzialkaId != 0)
                    podmiotDetail = true;
            }
            else
                podmiotDetail = false;
        }

        public IZagospList zagospList { get; set; }

        private string _nazwa;
        public string nazwa
        {
            get => _nazwa;
            set
            {
                _nazwa = value;
                RaisePropertyChanged();
            }
        }

        public IPodmiotList podmList { get; set; }

        public ICommand nazwaAdd { get; set; }
        public ICommand nazwaDel { get; set; }
        public ICommand zagospAdd { get; set; }
        public ICommand zagospCls { get; set; }

        public UserControl_ZagospViewModel()
        {
            nazwaAdd = new RelayCommand(onNazwaAll);
            nazwaDel = new RelayCommand(onNazwaDel);
            zagospAdd = new RelayCommand(onZagospAdd);
            zagospCls = new RelayCommand(onZagospCls);

            podmiotDetail = false;

        }

        private void onZagospCls()
        {
            zagospSel = null;
        }

        private void onZagospAdd()
        {
            zagospList.saveZagosp();
        }

        private void onNazwaDel()
        {
            zagospList.list.Remove(zagospSel);
        }

        private void onNazwaAll()
        {
            if (testIfExist())
            {
                zagospList.list.Add(new Zagosp() { Nazwa = nazwa, DzialkaId = userPrev.dzialkaSel.DzialkaId });
                nazwa = string.Empty;
                zagospSel = null;
            }
        }

        private bool testIfExist()
        {
            return zagospList.list.FirstOrDefault(r => r.Nazwa == nazwa) == null ? true : false;
        }

    }
}
