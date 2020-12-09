using Castle.Core;
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
        private ICelNabyciaList _celNabList;
        public ICelNabyciaList celNabList
        {
            get => _celNabList;
            set
            {
                _celNabList = value;
                RaisePropertyChanged();
            }
        }

        //public IKonserwPrzyrodySloList konsPrzyrodyList { get; set; }

        //public IKonserwZabytkowSloList konsZabytkowList { get; set; }

        //public IPrzedstawicielSloList przedstawicielSloList { get; set; }

        //public UserControl_PreviewViewModel userPrev { get; set; }

        //public ZagospFunkcjaSloList zagFunList { get; set; }

        //public IZagospStatusSlo zapospStatusSel { get; set; }

        public IZagospList zagospList { get; set; }

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


        private Zagosp _zagospLok;
        public Zagosp zagospLok
        {
            get => _zagospLok;
            set
            {
                _zagospLok = value;
                RaisePropertyChanged();
            }
        }

        public ICommand statusAdd { get; set; }
        public ICommand statusDel { get; set; }
        //public ICommand zagospAdd { get; set; }
        public ICommand zagospCls { get; set; }
        public ICommand zagospSave { get; set; }

      
        private ZagospStatusList _zagospStatusList;
        [DoNotWire]
        public ZagospStatusList zagospStatusList
        {
            get
            {
                return _zagospStatusList;
            }
            set
            {
                _zagospStatusList = value;
                RaisePropertyChanged();
            }
        }

        public ZagospStatusListSlo list { get; set; }

        public ZagospStatus statusSel { get; set; }
        [DoNotWire]
        public ZagospStatusListSlo zagospStatusRaf { get; set; }

        #region Konstruktor
        public UserControl_ZagospViewModel(UserControl_PreviewViewModel userPrev
                                            , IZagospList _zagospList
                                            , ZagospStatusList _zagospStatusList
                                            , ZagospStatusListSlo _zagospStatusRaf
                                            )
        {
            zagospStatusList = _zagospStatusList;

            initButtons();
           
            if (userPrev.dzialkaSel != null)
            {
                _zagospList.getList(userPrev.dzialkaSel);

                zagospLok = (Zagosp)_zagospList.listAll.FirstOrDefault(r => r.DzialkaId == (userPrev.dzialkaSel.DzialkaId));

                if (zagospLok == null)
                {
                    int t = 13;
                    zagospLok = new Zagosp(userPrev.dzialkaSel.DzialkaId);
                    podmiotDetail = false;
                }
                else
                {
                    zagospStatusList.ustalId(zagospLok.ZagospStatusId);
                    podmiotDetail = true;
                }

                zagospStatusList.zmianaZagospStatus += ZagospStatusList_zmianaZagospStatus;
            }
        }

        private void ZagospStatusList_zmianaZagospStatus(object sender, EventArgs e)
        {
            if (zagospStatusList.funkcjaSel != null)
            {
                int x = 13;
                podmiotDetail = true;
                zagospLok.ZagospStatusId = zagospStatusList.funkcjaSel.ZagospFunkcjaSloId;
            }
            else
            {
                podmiotDetail = false;
                zagospLok.ZagospStatusId = null;
            }

        }

        #endregion

        private void initButtons()
        {
            statusAdd = new RelayCommand(onStatusAdd);
            //statusDel = new RelayCommand(onStatusDel);
            ////zagospAdd = new RelayCommand(onZagospAdd);
            //zagospCls = new RelayCommand(onZagospCls);
            zagospSave = new RelayCommand(onZagospSave);
        }

        private void onZagospSave()
        {
            int z1 = 13;
            if (zagospLok != null)
            {
                
                zagospList.saveZagosp(zagospLok);
            }
            //            zagospLok = null;
        }

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
            int xxx = 13;
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
