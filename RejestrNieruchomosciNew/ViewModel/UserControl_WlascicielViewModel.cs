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

        public UserControl_PreviewViewModel userControl_prevModel { get; set; }

        public ICommand wlascAdd { get; set; }
        public ICommand wlascCls { get; set; }
        public ICommand podmiotAdd { get; set; }
        public ICommand podmiotDel { get; set; }

        //public UserControl_WlascicielViewModel(IDzialkaList dzList)
        public UserControl_WlascicielViewModel()
        {
            wlascCls = new RelayCommand(onWlascCls);
            wlascAdd = new RelayCommand(onWlascAdd);
            podmiotAdd = new RelayCommand(onPodmiotAdd);
            podmiotDel = new RelayCommand(onPodmiotDel);

            //dzialkaId = int.Parse(dzList.list.First(r => r.Numer.Contains("1") == true).DzialkaId.ToString());
        }

        private void onWlascCls()
        {
            wladanieSel = null;
        }

        private void onPodmiotAdd()
        {
            if (wlascSel != null)
            {
                if (testWlascExist(wlascSel) == false)
                {
                    wladanie.DzialkaId = userControl_prevModel.dzialkaSel.DzialkaId;
                    wladanie.PodmiotId = wlascSel.id;
                    wladanie.Podmiot = (Podmiot)podmiotList.list.First(r => r.PodmiotId == wlascSel.id);

                    wladanieList.list.Add(new Wladanie()
                                                        {
                                                            DzialkaId = wladanie.DzialkaId,
                                                            PodmiotId = wladanie.PodmiotId,
                                                            Podmiot = wladanie.Podmiot
                                                        });
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
            wladanieList.saveWladanie();
        }

        private bool testWlascExist(WpfControlLibraryRaf.Podmiot wlascSel)
        {
            if (wladanieList.list.Count == 0)
                return false;

            var v = wladanieList.list.Where(r => r.PodmiotId == wlascSel.id).Count();
      
            return (v == 0) ? false : true;
        }
    }
}
