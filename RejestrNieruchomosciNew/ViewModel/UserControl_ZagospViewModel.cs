using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace RejestrNieruchomosciNew.ViewModel
{
    public class UserControl_ZagospViewModel : ViewModelBase
    {
        private ICelNabyciaList _celNabList;
        public ICelNabyciaList celNabList { get => _celNabList;
            set {
                _celNabList = value;
                RaisePropertyChanged();
            } }

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

        public ObservableCollection<IZagosp> zagospListLok { get; set; }

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

        public UserControl_ZagospViewModel(UserControl_PreviewViewModel userPrev,
                                           IZagospList _zagospList)
        {
            initButtons();

            if (userPrev.dzialkaSel != null)
            {
                _zagospList.getList(userPrev.dzialkaSel);

                zagospListLok = new ObservableCollection<IZagosp>(_zagospList.list.Select(r => new Zagosp(r)).ToList());
            }

            podmiotDetail = false;
        }

        private void initButtons()
        {
            nazwaAdd = new RelayCommand(onNazwaAll);
            nazwaDel = new RelayCommand(onNazwaDel);
            zagospAdd = new RelayCommand(onZagospAdd);
            zagospCls = new RelayCommand(onZagospCls);
        }

        private void onZagospCls()
        {
            //MessageBox.Show( $"{zagospSel.istObiektySloId.ToString()}\r\n{zagospSel.obiektyKomSloId.ToString()}\r\n{zagospSel.zadInwestSloId.ToString()}\r\n{zagospSel.celeKomSloId.ToString()}");

            //zagospSel = null;
        }

        private void onZagospAdd()
        {
            try
            {
                
                zagospList.list = new ObservableCollection<IZagosp>(zagospListLok.Select(r => new Zagosp(r)).ToList());
                zagospList.saveZagosp();
            }
            catch (Exception ex)
            {
                MessageBox.Show( $@"{ex.Message}" +
                                  $"{ex.Source}" +
                                  $"{ex.StackTrace}");
            }
        }

        private void onNazwaDel()
        {
            zagospListLok.Remove(zagospSel);
        }

        private void onNazwaAll()
        {
            if (testIfExist())
            {
                try
                {
                    zagospListLok.Add(new Zagosp() { Nazwa = nazwa, DzialkaId = userPrev.dzialkaSel.DzialkaId });
                    nazwa = string.Empty;
                    zagospSel = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($@"{ex.Message}" +
                                      $"{ex.Source}" +
                                      $"{ex.StackTrace}");
                }
            }
        }

        private bool testIfExist()
        {
            return zagospList.list.FirstOrDefault(r => r.Nazwa == nazwa) == null ? true : false;
        }

    }
}
