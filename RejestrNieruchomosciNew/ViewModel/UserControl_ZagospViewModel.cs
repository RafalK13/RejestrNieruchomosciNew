using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace RejestrNieruchomosciNew.ViewModel
{
    public class UserControl_ZagospViewModel : ViewModelBase
    {
        //private ICelNabyciaList _celNabList;
        //public ICelNabyciaList celNabList
        //{
        //    get => _celNabList;
        //    set
        //    {
        //        _celNabList = value;
        //        RaisePropertyChanged();
        //    }
        //}

        //public IKonserwPrzyrodySloList konsPrzyrodyList { get; set; }

        //public IKonserwZabytkowSloList konsZabytkowList { get; set; }

        //public IPrzedstawicielSloList przedstawicielSloList { get; set; }

        //public UserControl_PreviewViewModel userPrev { get; set; }

        //public ZagospFunkcjaSloList zagFunList { get; set; }

        //public IZagospStatusSlo zapospStatusSel { get; set; }

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

        //private IZagosp _zagospSel;
        //public IZagosp zagospSel
        //{
        //    get => _zagospSel;
        //    set
        //    {
        //        _zagospSel = value;
        //        RaisePropertyChanged();

        //        testPodmiotDetail();
        //    }
        //}

        //private void testPodmiotDetail()
        //{
        //    if (zagospSel != null)
        //    {
        //        if (zagospSel.DzialkaId != 0)
        //            podmiotDetail = true;
        //    }
        //    else
        //        podmiotDetail = false;
        //}

        //public IZagospList zagospList { get; set; }

        public IZagosp zagospLok { get; set; }

        public ICommand statusAdd { get; set; }
        public ICommand statusDel { get; set; }
        //public ICommand zagospAdd { get; set; }
        public ICommand zagospCls { get; set; }
        public ICommand zagospSave { get; set; }

        public ZagospStatusList zagospStatusList { get; set; }

        //private ZagospStatus _zagospStatusSel;
        //public ZagospStatus zagospStatusSel
        //{
        //    get => _zagospStatusSel;
        //    set {
        //        _zagospStatusSel = value;
               
        //    }
        //}

        private IZagosp _zagospSel;

        public IZagosp zagospSel
        {
            get { return _zagospSel; }
            set
            {
                _zagospSel = value;
                RaisePropertyChanged();
                zagospSel.zmiana += ZagospSel_zmiana;
            }
        }

        private void ZagospSel_zmiana(object sender, EventArgs e)
        {
            podmiotDetail = zagospSel.ZagospStatusId != null ? true : false;
        }



        //public List<ZagospStatus> status { get => zagospStatusList.list.GroupBy(r => r.ZagospStatusSloId).Select(t => t.First()).ToList(); }

        //public ZagospStatusList status
        //{
        //    get => zagospStatusList.
        //}

        #region Konstruktor

        public UserControl_ZagospViewModel(UserControl_PreviewViewModel userPrev,
                                           IZagospList _zagospList)
        {
            initButtons();

            if (userPrev.dzialkaSel != null)
            {
                _zagospList.getList(userPrev.dzialkaSel);
                zagospLok = _zagospList.listAll.FirstOrDefault(r => r.DzialkaId == (userPrev.dzialkaSel.DzialkaId)) ?? new Zagosp();
            }
            podmiotDetail = false;
        }

        #endregion

        private void initButtons()
        {
            statusAdd = new RelayCommand(onStatusAdd);
            //statusDel = new RelayCommand(onStatusDel);
            ////zagospAdd = new RelayCommand(onZagospAdd);
            //zagospCls = new RelayCommand(onZagospCls);
            //zagospSave = new RelayCommand(onZagospSave);
        }

        //private void onZagospSave()
        //{
        //    zagospSel = null;
        //    zagospList.list = zagospListLok;
        //    zagospList.saveZagosp(userPrev.dzialkaSel);
        //}

        //private void onZagospCls()
        //{
        //    //MessageBox.Show( $"{zagospSel.istObiektySloId.ToString()}\r\n{zagospSel.obiektyKomSloId.ToString()}\r\n{zagospSel.zadInwestSloId.ToString()}\r\n{zagospSel.celeKomSloId.ToString()}");

        //    zagospSel = null;
        //}



        //private void onStatusDel()
        //{
        //    zagospListLok.Remove(zagospSel);
        //}

        private void onStatusAdd()
        {
            //    if (testIfExist())
            //    {
            //        try
            //        {
            //            zagospListLok.Add(new Zagosp() { ZagospStatusSloId = zapospStatusSel.ZagospStatusSloId, DzialkaId = userPrev.dzialkaSel.DzialkaId });
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show($@"{ex.Message}" +
            //                              $"{ex.Source}" +
            //                              $"{ex.StackTrace}");
            //        }
            //    }
        }

        //private bool testIfExist()
        //{
        //    return zagospListLok.FirstOrDefault(r => r.ZagospStatusSloId == zapospStatusSel.ZagospStatusSloId) == null ? true : false;
        //}

    }
}
