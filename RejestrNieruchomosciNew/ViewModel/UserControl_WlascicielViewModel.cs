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
        

        private int _wlascId;
        public int wlascId
        {
            get => _wlascId;
            set
            {
                _wlascId = value;
                RaisePropertyChanged("wlascId");
            }
        }

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

        public ICommand wlascAdd { get; set; }
        public ICommand wlascCls { get; set; }
        public ICommand podmiotAdd { get; set; }
        public ICommand podmiotDel { get; set; }
        public ICommand wlascProt { get; set; }

        public IDzialka dzialkaSel { get; set; }
        public IDzialkaList dzialkaList { get; set; }

        private int dzialkaId;

        public UserControl_WlascicielViewModel(UserControl_PreviewViewModel userPrev)
        {

            wlascCls = new RelayCommand(onWlascCls);
            wlascAdd = new RelayCommand(onWlascAdd);
            wlascProt = new RelayCommand(onWlascProt);
            podmiotAdd = new RelayCommand(onPodmiotAdd);
            podmiotDel = new RelayCommand(onPodmiotDel);
            

            if (userPrev.dzialkaSel != null)
                dzialkaId = int.Parse(userPrev.dzialkaSel.DzialkaId.ToString());

        }

        private void onWlascProt()
        {   
            string zalPath = ConfigurationManager.AppSettings["zalacznikPath"] + "\\ProtokolPrzejecia\\Dzialka\\" + wladanieSel.DzialkaId+"\\Podmiot\\"+wladanieSel.PodmiotId;
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
            if (wlascId > 0)
            {
                if (testWlascExist() == false)
                {
                    wladanie.DzialkaId = dzialkaId;
                    wladanie.PodmiotId = wlascId;
                    wladanie.Podmiot = (Podmiot)podmiotList.list.First(r => r.PodmiotId == wlascId);

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

        private bool testWlascExist()
        {
            if (wladanieList.list.Count == 0)
                return false;

            var v = wladanieList.list.Where(r => r.PodmiotId == wlascId).Count();

            return (v == 0) ? false : true;
        }
    }
}
