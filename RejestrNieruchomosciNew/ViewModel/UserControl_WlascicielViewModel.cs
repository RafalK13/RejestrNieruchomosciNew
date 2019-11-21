using Castle.Core;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.Model.Interfaces;
using System;
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

        public IWladanieList wladanieList { get; set; }

        public IPodmiotList podmiotList { get; set; }

        public FormaWladaniaList sloFormWlad { get; set; }

        public ITransakcjeList transakcjeList { get; set; }

        public RodzajDokumentuList rodzDokSlo { get; set; }

        public NazwaCzynnosciList nazwaCzynSlo { get; set; }

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

        #region Buttons
        public ICommand wlascAdd { get; set; }
        public ICommand wlascCls { get; set; }
        public ICommand podmiotAdd { get; set; }
        public ICommand podmiotDel { get; set; }
        public ICommand wlascProt { get; set; }
        public ICommand onCzyscPlatnosci { get; set; }
        #endregion

        public IDzialka dzialkaSel { get; set; }

        public IPlatnoscUW platnosci { get; set; }

        public IDzialkaList dzialkaList { get; set; }

        private int dzialkaId;

        public UserControl_WlascicielViewModel(UserControl_PreviewViewModel userPrev)
        {
            initButtons();

            if (userPrev.dzialkaSel != null)
            {
                dzialkaId = int.Parse(userPrev.dzialkaSel.DzialkaId.ToString());
            }
        }

        private void initButtons()
        {
            wlascCls = new RelayCommand(onWlascCls);
            wlascAdd = new RelayCommand(onWlascAdd);
            wlascProt = new RelayCommand(onWlascProt);
            podmiotAdd = new RelayCommand(onPodmiotAdd);
            podmiotDel = new RelayCommand(onPodmiotDel);
            onCzyscPlatnosci = new RelayCommand(onCzyscPlatnosciClick);

        }

        private void onCzyscPlatnosciClick()
        {
            platnosci.cleanObj();
            int a = 13;
        }

        private void onWlascProt()
        {
            string zalPath = ConfigurationManager.AppSettings["zalacznikPath"] + "\\ProtokolPrzejecia\\Dzialka\\" + wladanieSel.DzialkaId + "\\Podmiot\\" + wladanieSel.PodmiotId;
            wladanieSel.Scan = zalPath;

            DirectoryInfo dir = new DirectoryInfo(zalPath);
            if (!dir.Exists)
                dir.Create();

            int a = 13;

            Process.Start(zalPath);
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
                    wladanie.Podmiot = (Podmiot)podmiotList.list.First(r => r.PodmiotId == selectedPodmId);

                    wladanieList.list.Add(new Wladanie()
                    {
                        DzialkaId = wladanie.DzialkaId,
                        PodmiotId = wladanie.PodmiotId,
                        Podmiot = wladanie.Podmiot
                    });

                    podmiotName = string.Empty;
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
            platnosci.save();
            wladanieList.saveWladanie();
        }

        private bool testWlascExist()
        {
            if (wladanieList.list.Count == 0)
                return false;

            var v = wladanieList.list.Where(r => r.PodmiotId == selectedPodmId).Count();

            return (v == 0) ? false : true;
        }
    }
}
