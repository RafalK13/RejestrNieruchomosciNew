using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using WpfControlLibraryRaf;

namespace RejestrNieruchomosciNew.ViewModel
{
    public class UserControl_WlascicielViewModel : ViewModelBase
    {
        private string _tekstCls;
        public string tekstCls
        {
            get => _tekstCls;
            set
            {
                _tekstCls = value;
                RaisePropertyChanged("tekstCls");
            }
        }
        public IWladanie wladanie { get; set; }
        public IWladanieList wladanieList { get; set; }
        public IPodmiotList podmiotList { get; set; }
        
        public FormaWladaniaList sloFormWlad { get; set; }
        public NazwaCzynnosciSlo sloNazwaCzyn { get; set; }

        private int dzialkaId;
        
        private WpfControlLibraryRaf.Podmiot _wlascSel;
        public WpfControlLibraryRaf.Podmiot wlascSel
        {
            get => _wlascSel;
            set
            {
                _wlascSel = value;
                RaisePropertyChanged("wlascSel");
            }
        }

        public ITransakcjeList transakcjeList { get; set; }

        private IWladanie _wladanieSel;
        public IWladanie wladanieSel
        {
            get { return _wladanieSel; }
            set
            {
                _wladanieSel = value;
                RaisePropertyChanged("wladanieSel");
            }
        }

        public ICommand podmiotAdd { get; set; }
        public ICommand wlascAdd { get; set; }
        public ICommand podmiotDel { get; set; }

        public UserControl_WlascicielViewModel(IDzialkaList dzList)
        {
            podmiotAdd = new RelayCommand(onPodmiotAdd);
            wlascAdd = new RelayCommand(onWlascAdd);
            podmiotDel = new RelayCommand(onPodmiotDel);

            dzialkaId = int.Parse(dzList.list.First(r => r.Numer.Contains("1") == true).DzialkaId.ToString());
        }

        private void onPodmiotAdd()
        {
            if (wlascSel != null)
            {
                if (testWlascExist(wlascSel) == false)
                {
                    wladanie.PodmiodId = wlascSel.id;
                    wladanie.Podmiot = new Podmiot() { Name = wlascSel.nazwa, PodmiotId = wlascSel.id };

                    wladanieList.AddRow(wladanie);

                    tekstCls = string.Empty;
                    wladanieSel = null;
                }
            }
        }

        private void onPodmiotDel()
        {
            wladanieList.list.Remove(wladanieSel);
            wladanieSel = null;
        }

        private void onWlascAdd()
        {
            
        }

        private bool testWlascExist(WpfControlLibraryRaf.Podmiot wlascSel)
        {
            if (wladanieList.list.Count == 0)
                return false;

            var v = wladanieList.list.Where(r => r.Podmiot.Name == wlascSel.nazwa).Count();

            return (v == 0) ? false : true;

        }
    }
}
