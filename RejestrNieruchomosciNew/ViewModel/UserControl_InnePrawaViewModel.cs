using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.Model.Interfaces;

namespace RejestrNieruchomosciNew.ViewModel
{
    public class UserControl_InnePrawaViewModel : ViewModelBase
    {

        private int dzialkaId;

        private PlatnoscInnePrawa _platnoscInnePrawa;
        public PlatnoscInnePrawa platnoscInnePrawa
        {
            get => _platnoscInnePrawa;
            set
            {
                _platnoscInnePrawa = value;
                RaisePropertyChanged();
            }
        }

        private Visibility _sellVisibility;
        public Visibility sellVisibility
        {
            get => _sellVisibility;

            set
            {
                _sellVisibility = value;
                RaisePropertyChanged("sellVisibility");
            }
        }

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

        public IInnePrawa innePrawa { get; set; }

        public ObservableCollection<IInnePrawa> inneListLok { get; set; }
        public IInnePrawaList innePrawaList { get; set; }

        public DecyzjeAdministracyjne decyzjeAdmin { get; set; }
        public DecyzjeAdministracyjneList decyzjeAdminList { get; set; }

        public RodzajInnegoPrawaList rodzajInnegoPrawaSlo { get; set; }

        public ITransakcjeList transakcjeList { get; set; }
        public RodzajDokumentuList rodzDokSlo { get; set; }
        public NazwaCzynnosciList nazwaCzynSlo { get; set; }
        public ICelNabyciaList celNabyciaList { get; set; }

        private IInnePrawa _innePrawaSel;
        public IInnePrawa innePrawaSel
        {
            get { return _innePrawaSel; }
            set
            {
                _innePrawaSel = value;
                testInnePrawaSel();    
                RaisePropertyChanged("innePrawaSel");
            }
        }

        public IPodmiotList podmiotList { get; set; }

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

        public UserControl_InnePrawaViewModel(UserControl_PreviewViewModel userPrev,
                                             IInnePrawaList _innePrawaList)
        {
            initButtons();
            
            sellVisibility = Visibility.Hidden;

            if (userPrev.dzialkaSel != null)
            {
                dzialkaId = int.Parse(userPrev.dzialkaSel.DzialkaId.ToString());
                _innePrawaList.getList(userPrev.dzialkaSel);

                inneListLok = new ObservableCollection<IInnePrawa>(_innePrawaList.list.Select(r => new InnePrawa(r)).ToList());
            }

            podmiotDetail = false;
        }

        private void testInnePrawaSel()
        {
            if (innePrawaSel != null)
            {
                if (innePrawaSel.DzialkaId != 0)
                {
                    podmiotDetail = true;
                }
            }
            else
                podmiotDetail = false;
        }
        
        private bool testWlascExist()
        {
            if (innePrawaList.list.Count == 0)
                return false;

            var v = innePrawaList.list.Where(r => r.PodmiotId == selectedPodmId).Count();

            return (v == 0) ? false : true;
        }

        #region Buttons
        public ICommand podmiotAdd { get; set; }
        public ICommand podmiotDel { get; set; }
        public ICommand innePrawaAdd { get; set; }
        public ICommand innePrawaSell { get; set; }
        public ICommand protPrzejScanClick { get; set; }
        public ICommand protZwrotScanClick { get; set; }
        public ICommand innePrawaCls { get; set; }

        private void initButtons()
        {
            podmiotAdd = new RelayCommand(onPodmiotAdd);
            podmiotDel = new RelayCommand(onPodmiotDel);
            innePrawaAdd = new RelayCommand(onInnePrawaAdd);
            innePrawaSell = new RelayCommand(onInnePrawaSell);
            protPrzejScanClick = new RelayCommand(onProtPrzejScan);
            protZwrotScanClick = new RelayCommand(onProtZwrotScan);
            innePrawaCls = new RelayCommand(onInnePrawaCls);
        }

        private void onInnePrawaCls()
        {
            innePrawaSel = null;
        }

        private void onProtZwrotScan()
        {
            string zalPath = ConfigurationManager.AppSettings["zalacznikPath"] + "\\Dzialka\\" + innePrawaSel.DzialkaId + "\\InnePrawa\\Podmiot\\" + innePrawaSel.PodmiotId + "\\ProtokolZwrotnegoPrzekazania\\";

            innePrawaSel.ProtZwrotScan = zalPath;

            DirectoryInfo dir = new DirectoryInfo(zalPath);
            if (!dir.Exists)
                dir.Create();

            Process.Start(zalPath);
        }

        private void onProtPrzejScan()
        {
            string zalPath = ConfigurationManager.AppSettings["zalacznikPath"] + "\\Dzialka\\" + innePrawaSel.DzialkaId + "\\InnePrawa\\Podmiot\\" + innePrawaSel.PodmiotId + "\\ProtokolPrzejecia\\";
            innePrawaSel.ProtPrzejScan = zalPath;

            DirectoryInfo dir = new DirectoryInfo(zalPath);
            if (!dir.Exists)
                dir.Create();

            Process.Start(zalPath);
        }

        private void onInnePrawaSell()
        {
            sellVisibility = Visibility.Visible;
        }

        private void onInnePrawaAdd()
        {
            innePrawaList.list = new ObservableCollection<IInnePrawa>(inneListLok.Select(r => new InnePrawa(r)).ToList());
            innePrawaList.save();
        }

        private void onPodmiotAdd()
        {
            if (selectedPodmId > 0)
            {
                if (testWlascExist() == false)
                {
                    innePrawa.DzialkaId = dzialkaId;
                    innePrawa.PodmiotId = selectedPodmId;

                    //innePrawaList.list.Add(new InnePrawa()
                    inneListLok.Add( new InnePrawa()
                    {
                        DzialkaId = innePrawa.DzialkaId,
                        PodmiotId = innePrawa.PodmiotId,
                        PlatnoscInnePrawa = platnoscInnePrawa.clone()
                    });

                    podmiotName = string.Empty;
                    innePrawaSel = null;
                }

                //platnoscInnePrawaList.list.Add(new PlatnoscInnePrawa()
                //{
                //    DzialkaId = innePrawa.DzialkaId,
                //    PodmiotId = innePrawa.PodmiotId,
                //});
                
            }
        }
        private void onPodmiotDel()
        {
            inneListLok.Remove(innePrawaSel);
            //innePrawaList.list.Remove(innePrawaSel);
            innePrawaSel = null;
        }
        #endregion

    }
}
