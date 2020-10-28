using Castle.Core;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace RejestrNieruchomosciNew.ViewModel
{
    public class UserControl_WlascicielViewModel : ViewModelBase
    {
        private string _podmiotName;
        public string podmiotName
        {
            get => _podmiotName;
            set
            {
                _podmiotName = value;
                RaisePropertyChanged("podmiotName");
            }
        }

        private int _selectedPodmId;
        public int selectedPodmId
        {
            get => _selectedPodmId;
            set
            {
                _selectedPodmId = value;
                RaisePropertyChanged("selectedPodmId");
            }
        }

        public IWladanie wladanie { get; set; }

        public ObservableCollection<IWladanie> wladListLok { get; set; }

        public IWladanieList wladanieList { get; set; }

        public IPodmiotList podmiotList { get; set; }

        public FormaWladaniaList sloFormWlad { get; set; }

        public ITransakcjeList transakcjeList { get; set; }

        public RodzajDokumentuList rodzDokSlo { get; set; }

        public NazwaCzynnosciList nazwaCzynSlo { get; set; }

        public ICelNabyciaList celNabyciaList { get; set; }

        private IWladanie _wladanieSel;
        public IWladanie wladanieSel
        {
            get { return _wladanieSel; }
            set
            {
                _wladanieSel = value;
                testWladanieSel();
                RaisePropertyChanged("wladanieSel");
            }
        }

        private void testWladanieSel()
        {
           
            if (wladanieSel != null)
            {
                if (wladanieSel.DzialkaId != null)
                    podmiotDetail = true;
            }
            else
                podmiotDetail = false;
        }

        private bool _podmiotDetail;
        public bool podmiotDetail
        {
            get => _podmiotDetail;

            set {
                _podmiotDetail = value;
                RaisePropertyChanged("podmiotDetail");
            }
        }

        private Visibility _sellVisibility;
        public Visibility sellVisibility
        {
            get => _sellVisibility;

            set {
                _sellVisibility = value;
                RaisePropertyChanged("sellVisibility");
            }
        }

        #region Buttons
        public ICommand wlascAdd { get; set; }
        public ICommand wlascCls { get; set; }
        public ICommand podmiotAdd { get; set; }
        public ICommand podmiotDel { get; set; }
        public ICommand onCzyscPlatnosci { get; set; }
        public ICommand wlascSell{ get; set; }
        public ICommand onCancel { get; set; }
        #endregion

        public IDzialka dzialkaSel { get; set; }

        public PlatnoscUW platnosci { get; set; }

        //public IDzialkaList dzialkaList { get; set; }

        private int dzialkaId;

        public UserControl_WlascicielViewModel(UserControl_PreviewViewModel userPrev,
                                               IWladanieList _wladanieList
                                              )
        {

            initButtons();

            sellVisibility = Visibility.Hidden;

            if (userPrev.dzialkaSel != null)
            {
                dzialkaId = int.Parse(userPrev.dzialkaSel.DzialkaId.ToString());
                _wladanieList.getList(userPrev.dzialkaSel);

                wladListLok = new ObservableCollection<IWladanie>(_wladanieList.list.Select(r => new Wladanie(r)).ToList());
            }

            podmiotDetail = false;
        }

        private void initButtons()
        {
            wlascCls = new RelayCommand(onWlascCls);
            wlascAdd = new RelayCommand(onWlascAdd);
            podmiotAdd = new RelayCommand(onPodmiotAdd);
            podmiotDel = new RelayCommand(onPodmiotDel);
            onCzyscPlatnosci = new RelayCommand(onCzyscPlatnosciClick);
            wlascSell = new RelayCommand(onWlascSell);
            onCancel = new RelayCommand(onCancelClick);
        }

        private void onCancelClick()
        {
            //var w = Application.Current.Windows[1];
        }

        private void onWlascSell()
        {
            sellVisibility = Visibility.Visible;
        }

        private void onCzyscPlatnosciClick()
        {
            platnosci.cleanObj();
        }

        private void onWlascCls()
        {
            wladanieSel = null;
        }

        private void onPodmiotAdd()
        {
            
            if (selectedPodmId > 0)
            {
                if (testWlascExist() == false)
                {
                    wladanie.DzialkaId = dzialkaId;
                    wladanie.PodmiotId = selectedPodmId;

                    wladListLok.Add(new Wladanie()
                    {
                        DzialkaId = wladanie.DzialkaId,
                        PodmiotId = wladanie.PodmiotId,
                    });
                    
                    podmiotName = string.Empty;
                    wladanieSel = null;
                }
            }
        }

        private void onPodmiotDel()
        {
            wladListLok.Remove(wladanieSel);
            wladanieSel = null;
        }

        private void onWlascAdd()
        {
            wladanieList.list = new ObservableCollection<IWladanie>(wladListLok.Select(r => new Wladanie(r)).ToList());
            wladanieList.saveWladanie();
        }

        private bool testWlascExist()
        {
            if(wladListLok.Count() == 0 )
                return false;

            var v = wladListLok.Where(r => r.PodmiotId == selectedPodmId).Count();

            return (v == 0) ? false : true;
        }
    }
}
