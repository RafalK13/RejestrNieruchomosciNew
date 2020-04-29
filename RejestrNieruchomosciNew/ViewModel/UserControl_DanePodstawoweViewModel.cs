using Castle.Core;
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

        #region private
        private IAdres _adres;
        private bool _adresChanged;
        private UserControl_PreviewViewModel _userPrev;
        private IDzialka _dzialka;
        private ObrebClass _obreb;
        private bool _canAdd;
        #endregion

        public ChangeMode changeMode;

        public bool adresChanged
        {
            get => _adresChanged;
            set
            {
                Set(ref _adresChanged, value);
                canAdd = true;
                testDzialka();
            }
        }

        public UserControl_PreviewViewModel userPrev
        {
            get => _userPrev;
            set
            {
                Set ( ref _userPrev, value);
                //userPrev.zmianaDzialkaSel += UserPrev_zmianaDzialkaSel;
            }
        }

        //private void UserPrev_zmianaDzialkaSel(object sender, EventArgs e)
        //{
        //    MessageBox.Show("1");
        //    dzialka = userPrev.dzialkaSel;
        //}

        public IDzialka dzialka
        {
            get => _dzialka;
            set
            {
                Set( ref _dzialka, value);

                if (dzialka != null)
                    dzialka.zmiana += Dzialka_zmiana;
            }
        }

        private void Dzialka_zmiana(object sender, EventArgs e)
        {
            testDzialka();
        }
  
        public ObrebClass obreb
        {
            get => _obreb;
            set
            {
                Set( ref _obreb, value);
                obreb.PropertyChanged += Obreb_PropertyChanged;
            }
        }

        private void Obreb_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            dzialka.Obreb = obreb.getObreb();
            RaisePropertyChanged();
        }
        
        public bool canAdd
        {
            get => _canAdd;
            set => Set(ref _canAdd, value);
        }

        public bool? canMod;

        public ICommand leftClick { get; set; }
        public ICommand OnAddDzialka { get; set; }
        public ICommand clsClick { get; set; }

        public IDzialkaList dzialkaList { get; set; }


        public IAdres adres
        {
            get => _adres;
            set
            {
                Set(ref _adres, value);              
            }

        }
        #endregion

        #region Konstructor

        public UserControl_DanePodstawoweViewModel()
        {
            leftClick = new RelayCommand(onLeftClick);
            OnAddDzialka = new RelayCommand(OnAddDzialkaClick);
            clsClick = new RelayCommand(onClsClick);
            canAdd = false;
        }

        #endregion

        private void onClsClick()
        {
            obreb.clsObreb();
            dzialka.ObrebId = 0;
            testDzialka();
        }


        private void OnAddDzialkaClick()
        {
            switch (changeMode)
            {
                case ChangeMode.add:
                    {
                        dzialkaList.AddRow(dzialka);
                        break;
                    }
                case ChangeMode.mod:
                    {                        
                        dzialkaList.ModRow(dzialka);
                        canAdd = false;
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
                if (!string.IsNullOrEmpty(dzialka.Numer))
                {
                    var dz = dzialkaList.list.FirstOrDefault(n => n.DzialkaId == dzialka.DzialkaId);
                    int r2 = 13;
                    if (dzialka.Equals(dz) && adresChanged == false)
                        canAdd = false;
                    else
                    {
                        // zmiana kw, pow .. oprócz obrebu i gminy
                        if (string.Compare(dz.Numer, dzialka.Numer) == 0 &&
                                           dz.ObrebId == dzialka.ObrebId)
                        {
                            canAdd = true;
                           
                        }
                        else // zmiana obrebu i/lub gminy
                        {
                            var c = dzialkaList.list.FirstOrDefault(r => r.ObrebId == dzialka.ObrebId
                                                                  && r.Numer == dzialka.Numer);
                            canAdd = c == null ? true : false;
                        }
                        
                    }
                }
                //canAdd &= adresChanged;
            }
        }

        #endregion
    }
}
