using Castle.Core;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Linq;
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

        public DzialkaOchrona dzialkaOchronaLok { get; set; }
        [DoNotWire]
        public IDzialka dzialkaSel { get; set; }

        public UserControl_PreviewViewModel  userPrev { get; set; }

        #region Konstruktor
        public UserControl_ZagospViewModel(   UserControl_PreviewViewModel _userPrev
                                            , IZagospList _zagospList
                                            , ZagospStatusList _zagospStatusList
                                            )
        {
            int x = 13;
            zagospStatusList = _zagospStatusList;
            dzialkaSel = _userPrev.dzialkaSel;
            userPrev = _userPrev;

            initButtons();
           
            if (dzialkaSel != null)
            {
                _zagospList.getList( dzialkaSel);

                zagospLok = (Zagosp)_zagospList.listAll.FirstOrDefault(r => r.DzialkaId == (dzialkaSel.DzialkaId));

                //var t = (DzialkaOchrona)dzialkaSel.DzialkaOchrona.Clone();
                dzialkaOchronaLok = (DzialkaOchrona)dzialkaSel?.DzialkaOchrona?.Clone();

                if (zagospLok == null)
                {
                    zagospLok = new Zagosp(dzialkaSel.DzialkaId);
                    podmiotDetail = false;
                }
                else
                {
                    zagospStatusList.ustalId(zagospLok.ZagospStatusId);
                    podmiotDetail = true;
                }

                if (dzialkaOchronaLok == null)
                    dzialkaOchronaLok = new DzialkaOchrona() { DzialkaId = dzialkaSel.DzialkaId};
                int n = 13;
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
            //zagospCls = new RelayCommand(onZagospCls);
            zagospSave = new RelayCommand(onZagospSave);
        }

        private void onZagospSave()
        {
            if (zagospLok != null)
            {
                zagospList.saveZagosp(zagospLok);
            }

            saveDzialka();
            
            //            zagospLok = null;
        }

        private void saveDzialka()
        {
            using (var c = new Context())
            {
                int x = 13;
                c.Update(dzialkaOchronaLok);
                c.SaveChanges();

                var ind = userPrev.dzialkiList.list.IndexOf(dzialkaSel);

                userPrev.dzialkiList.list[ind].DzialkaOchrona = (DzialkaOchrona)dzialkaOchronaLok.Clone();
            }
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
