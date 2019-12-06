using System;
using System.Linq;
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

        public IInnePrawa innePrawa{ get; set; }

        public IInnePrawaList innePrawaList { get; set; }

        private IInnePrawa _innePrawaSel;
        public IInnePrawa innePrawaSel
        {
            get { return _innePrawaSel; }
            set
            {
                _innePrawaSel = value;
                //testWladanieSel();
                RaisePropertyChanged("innePrawaSel");
            }
        }

        public IPodmiotList podmiotList { get; set; }

        public UserControl_InnePrawaViewModel(UserControl_PreviewViewModel userPrev)
        {
            initButtons();

            if (userPrev.dzialkaSel != null)
            {
                dzialkaId = int.Parse(userPrev.dzialkaSel.DzialkaId.ToString());
            }
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

        private void initButtons()
        {
            podmiotAdd = new RelayCommand(onPodmiotAdd);
            podmiotDel = new RelayCommand(onPodmiotDel);
        }

        private void onPodmiotAdd()
        {
            if (selectedPodmId > 0)
            {
                if (testWlascExist() == false)
                {
                    innePrawa.DzialkaId = dzialkaId;
                    innePrawa.PodmiotId = selectedPodmId;

                    innePrawaList.list.Add(new InnePrawa()
                    {
                        DzialkaId = innePrawa.DzialkaId,
                        PodmiotId = innePrawa.PodmiotId,
                    });

                    podmiotName = string.Empty;
                    innePrawaSel = null;
                }
            }
        }

        private void onPodmiotDel()
        {
            innePrawaList.list.Remove(innePrawaSel);
            innePrawaSel = null;
        }
        #endregion

    }
}
