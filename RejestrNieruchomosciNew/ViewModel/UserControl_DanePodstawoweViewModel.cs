using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace RejestrNieruchomosciNew.ViewModel
{
    public class UserControl_DanePodstawoweViewModel : ViewModelBase
    {
        #region Properties

        public ChangeMode changeMode;

        private UserControl_PreviewViewModel _userPrev;
        public UserControl_PreviewViewModel userPrev
        {
            get => _userPrev;
            set
            {
                _userPrev = value;
                RaisePropertyChanged();
                userPrev.zmianaDzialkaSel += UserPrev_zmianaDzialkaSel;
            }
        }

        private void UserPrev_zmianaDzialkaSel(object sender, EventArgs e)
        {
            //dzialka = userPrev.dzialkaSel;
        }

        private IDzialka _dzialka;
        public IDzialka dzialka
        {
            get => _dzialka;
            set
            {
                _dzialka = value;
                RaisePropertyChanged();

                if (dzialka != null)
                    dzialka.zmiana += Dzialka_zmiana;

            }
        }

        public string Numer
        {
            get => _numer;
            set
            {
                _numer = value;
                RaisePropertyChanged();
            }
        }

        private void Dzialka_zmiana(object sender, EventArgs e)
        {

            testDzialka();
        }

        private ObrebClass _obreb;
        public ObrebClass obreb
        {
            get => _obreb;

            set
            {
                _obreb = value;
                RaisePropertyChanged("obreb");
                obreb.PropertyChanged += Obreb_PropertyChanged;
            }
        }

        private void Obreb_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            int r = 13;
            dzialka.Obreb = obreb.getObreb();
           
            //if (dzialka.Obreb != null)
            {
                
                RaisePropertyChanged( "adres");
               
            //    adres.miejscList.getList(adres.Dzialka);
            //    //MessageBox.Show(adres.miejscList.list.Count.ToString());
            }
        }

        private bool _canAdd;
        public bool canAdd
        {
            get
            {
                return _canAdd;
            }

            set
            {
                _canAdd = value;
                RaisePropertyChanged("canAdd");
            }
        }

        public bool? canMod;

        public ICommand leftClick { get; set; }
        public ICommand OnAddDzialka { get; set; }
        public ICommand clsClick { get; set; }

        public IDzialkaList dzialkaList { get; set; }

        private IAdres _adres;
        private string _numer;

        public IAdres adres
        {
            get => _adres;
            set
            {
                _adres = value;
                RaisePropertyChanged();

                if (adres != null)
                {
                    adres.Dzialka = (Dzialka)dzialka;
                }
            }
        }

        #endregion

        #region Konstructor

        public UserControl_DanePodstawoweViewModel()
        {
            leftClick = new RelayCommand(onLeftClick);
            OnAddDzialka = new RelayCommand(OnAddDzialkaClick);
            clsClick = new RelayCommand(onClsClick);
        }

        #endregion

        private void onClsClick()
        {
            obreb.clsObreb();

            //if( dzialka.Obreb != null)
            dzialka.ObrebId = 0;
            testDzialka();

        }

        private void OnAddDzialkaClick()
        {
            switch (changeMode)
            {
                case ChangeMode.add:
                    {
                        int r = 13;
                        dzialkaList.AddRow(dzialka);
                        break;
                    }
                case ChangeMode.mod:
                    {
                        dzialkaList.ModRow(dzialka);
                        break;
                    }
            }
            userPrev.dzialkaView.Refresh();
        }

        #region Metods
        private void onLeftClick()
        {
            if (obreb.getId().HasValue)
            {
                dzialka.ObrebId = obreb.getId().Value;
                testDzialka();
            }
        }

        private void getMiejscList()
        {
            if (dzialka.Adres != null)
            {
                dzialka.Adres.miejscList.getList(dzialka);
            }
        }

        public void testDzialka()
        {
            if (changeMode == ChangeMode.add)
            {
                int r = 13;
                testDzialkaToAdd();
            }
            if (changeMode == ChangeMode.mod)
                testDzialkaToMod();
        }

        private void testDzialkaToAdd()
        {
            if (obreb.getId().HasValue && string.IsNullOrEmpty(dzialka.Numer) == false)
            {
                int obrebId = obreb.getId().Value;

                int c = dzialkaList.list.Where(r => r.ObrebId == obrebId &&
                                                    r.Numer == dzialka.Numer).Count();

                canAdd = c == 0 ? true : false;
            }
        }

        private void testDzialkaToMod()
        {
            if (dzialka.ObrebId == 0)
                canAdd = false;
            else
            {
                var dz = dzialkaList.list.First(n => n.DzialkaId == dzialka.DzialkaId);
                dz.ObrebId = obreb.getId().Value;

                if (!string.IsNullOrEmpty(dzialka.Numer))
                {
                    if (string.Compare(dz.Numer, dzialka.Numer) == 0 &&
                                       dz.ObrebId == dzialka.ObrebId)
                    {
                        canAdd = true;
                    }
                    else
                    {
                        int obrID = obreb.getId().Value;

                        var c = dzialkaList.list.FirstOrDefault(r => r.ObrebId == obrID &&
                                                                     r.Numer == dzialka.Numer);
                        canAdd = c == null ? true : false;
                    }
                }
            }
        }

        #endregion
    }
}
