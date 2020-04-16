using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Linq;
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

                if (adres != null)
                {
                    adres.Dzialka = (Dzialka)dzialka;
                }
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

        public IDzialkaList dzialkaList { get; set; }

        private IAdres _adres;
        public IAdres adres
        {
            get => _adres;
            set
            {
                _adres = value;
                RaisePropertyChanged();

                if (adres != null)
                    adres.zmiana += Adres_zmiana;
            }
        }

        private void Adres_zmiana(object sender, EventArgs e)
        {
            testDzialka();
        }
        #endregion

        #region Konstructor

        public UserControl_DanePodstawoweViewModel()
        {
            leftClick = new RelayCommand(onLeftClick);
            OnAddDzialka = new RelayCommand(OnAddDzialkaClick);
        }
      
        #endregion

        private void OnAddDzialkaClick()
        {
            switch (changeMode)
            {
                case ChangeMode.add:
                    dzialkaList.AddRow(dzialka);
                    break;
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

        public void testDzialka()
        {
            if (changeMode == ChangeMode.add)
            {
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

        #endregion
    }
}
