using Castle.Core;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.Model.Interfaces;
using RejestrNieruchomosciNew.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace RejestrNieruchomosciNew.ViewModel
{
    public class UserControl_PreviewViewModel : ViewModelBase
    {
        #region ICommand
        public ICommand doubleClick { get; set; }
        public ICommand leftClick { get; set; }
        public ICommand clsClick { get; set; }
        public ICommand unselectClick { get; set; }
        public ICommand clsSzukaj { get; set; }
        #endregion

        private int _selectedIndeks;
        public int selectedIndeks
        {
            get => _selectedIndeks;
            set
            {
                _selectedIndeks = value;
                RaisePropertyChanged();
            }
        }

        [DoNotWire]
        public IDzialkaList dzialkiList { get; set; }

        public ICollectionView dzialkaView
        {
            get => CollectionViewSource.GetDefaultView(dzialkiList.list);
        }

        public event EventHandler zmianaDzialkaSel;

        public IDzialka _dzialkaSel;
        public IDzialka dzialkaSel
        {
            get
            {
                return _dzialkaSel;
            }
            set
            {
                _dzialkaSel = value;
                RaisePropertyChanged("dzialkaSel");

                clearLists();

                if (zmianaDzialkaSel != null)
                    zmianaDzialkaSel(null, EventArgs.Empty);

            }
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

        private string _dzialkaNr;
        public string dzialkaNr
        {
            get => _dzialkaNr;
            set
            {
                _dzialkaNr = value;
                RaisePropertyChanged("dzialkaNr");
                setFilter();
            }
        }

        private string _result;
        public string result
        {
            get => _result;
            set
            {
                _result = value;
                RaisePropertyChanged("result");
            }
        }

        private bool _allowDelete;
        public bool allowDelete
        {
            get => _allowDelete;
            set
            {
                _allowDelete = value;
                RaisePropertyChanged("allowDelete");
            }
        }

        public IViewFactory factory { get; set; }

        //public Window_Filtr windowFiltr { get; set; }
        public Window_FiltrViewModel viewModel { get; set; }

        public IFiltr filtr { get; set; }

        public PerformMode performMode { get; set; }

        #region Konstructor
        public UserControl_PreviewViewModel() { }
        public UserControl_PreviewViewModel(IDzialkaList _dzialkiList,
                                            PerformMode _performMode) : this( _dzialkiList)
        {
            performMode = _performMode;

            if (performMode.workMod == PerformMode.workMode.admin)
                allowDeleteEnabled = true;
            else
                allowDeleteEnabled = false;
        }

        public UserControl_PreviewViewModel(IDzialkaList _dzialkiList)
        {
            dzialkiList = _dzialkiList;

            dzialkiList.zmianaDzialkiList += DzialkiBase_zmianaDzialkiList;

            initCommands();
            allowDelete = false;
        }

        private void DzialkiBase_zmianaDzialkiList(object sender, EventArgs e)
        {
            dzialkaView.Refresh();
        }
        #endregion

        #region Methods

        private void initCommands()
        {
            doubleClick = new RelayCommand(onDoubleClicked);
            leftClick = new RelayCommand(onLeftClick);
            clsClick = new RelayCommand(onClsClick);
            unselectClick = new RelayCommand(onUnSelectClick);
            clsSzukaj = new RelayCommand(onSzukaj);
        }

        private void onSzukaj()
        {
            Window_Filtr windowFiltr = new Window_Filtr(viewModel);
            windowFiltr.ShowDialog();

            if (windowFiltr.DialogResult.HasValue && windowFiltr.DialogResult.Value)
            {
                setFilter();
            }

        }

        private void clearLists()
        {
            selectedIndeks = -1;
        }

        private void onUnSelectClick()
        {
            dzialkaSel = null;
            clearLists();
        }

        private void onClsClick()
        {
            dzialkaNr = String.Empty;
            obreb.clsObreb();
            clearLists();
        }

        private void onLeftClick()
        {
            setFilter();
        }

       public bool allowDeleteEnabled { get; set; }

        public void onDoubleClicked()
        {
            if (performMode.workMod == PerformMode.workMode.admin)
            {
                if (allowDelete == true)
                    deleteDzialka();
                else
                {
                    if (dzialkaSel != null)
                    {
                        var v = factory.CreateView<ChangeView>();
                        v.DataContext = factory.CreateView<IChangeViewModel>("Mod");
                        v.ShowDialog();
                    }
                }
            }
        }

        public void deleteDzialka()
        {
            if (dzialkaSel != null)
                if (dzialkaSel.Numer != null)
                {
                    dzialkiList.DelRow(dzialkaSel);
                    dzialkaView.Refresh();
                }
        }

        //private bool testIfExist<T>(T wrt, Dzialka d, string name)
        //{
        //    var v = Type.GetTypeCode( wrt.GetType());

        //    if (v == TypeCode.String)
        //    {
        //        var n = v.ToString();

        //        var result = !string.IsNullOrEmpty(n) ? d.Wladanie.FirstOrDefault(r => r.GetType().GetProperty(name).GetValue(d.Wladanie).ToString() == n) != null : true;

        //        return false;
        //    }



        //    return false;
        //}

        public void setFilter()
        {
            string s = String.Empty;

            clearLists();

            dzialkaView.Filter = row =>
            {
                Dzialka d = row as Dzialka;

                bool nb = !string.IsNullOrEmpty(dzialkaNr) ? d.Numer.Contains(dzialkaNr) : true;
                bool ob = !string.IsNullOrEmpty(obreb.obrebValue) ? d.Obreb.Nazwa.Contains(obreb.obrebValue) : true;
                bool gb = !string.IsNullOrEmpty(obreb.gminaValue) ? d.Obreb.GminaSlo.Nazwa.Contains(obreb.gminaValue) : true;
                bool wladanieUdzial = !string.IsNullOrEmpty(filtr.wlad_udzial) ? d.Wladanie.FirstOrDefault(r => r.Udzial == filtr.wlad_udzial) != null : true;

                bool wladanie_formaWlad = filtr.wlad_formaWladId != 0 ?
                    (d.Wladanie.FirstOrDefault(r => r.FormaWladaniaSloId == filtr.wlad_formaWladId)) != null ? true : false : true;

                bool wladanie_Podmiot = filtr.wlad_podmiot != 0 ?
                    (d.Wladanie.FirstOrDefault(r => r.PodmiotId == filtr.wlad_podmiot)) != null ? true : false : true;

                bool wladNumerTrans = (string.IsNullOrEmpty(filtr.wlad_NumerTrans)) ?
                   true : d.Wladanie.FirstOrDefault(r => EqualsStr(r?.TransakcjeK_Wlad?.Numer, filtr?.wlad_NumerTrans)) != null ?
                   true : false;

                bool wladTytulTrans = (string.IsNullOrEmpty(filtr.wlad_TytulTrans)) ?
                    true : d.Wladanie.FirstOrDefault(r => EqualsStr(r?.TransakcjeK_Wlad?.Tytul, filtr?.wlad_TytulTrans)) != null ?
                    true : false;

                bool kwAkt = (string.IsNullOrEmpty(filtr.kwAkt)) ?
                   true : EqualsStr(d.Kwakt, filtr.kwAkt) ?
                   true : false;

                bool kwZrob = (string.IsNullOrEmpty(filtr.kwZrob)) ?
                   true : EqualsStr(d.Kwzrob, filtr.kwZrob) ?
                   true : false;

                bool wlad_dataOdb_od = true;
                    if (filtr.wlad_dataOdb_odP != null || filtr.wlad_dataOdb_odK != null)
                    wlad_dataOdb_od = checkDate<Wladanie>(filtr.wlad_dataOdb_odP, filtr.wlad_dataOdb_odK, d.Wladanie, "DataOdbOd");

                bool wlad_dataOdb_do = true;
                if (filtr.wlad_dataOdb_doP != null || filtr.wlad_dataOdb_doK != null)
                    wlad_dataOdb_do = checkDate<Wladanie>(filtr.wlad_dataOdb_doP, filtr.wlad_dataOdb_doK, d.Wladanie, "DataOdbDo");

                bool powDanePod = testRange(filtr.powP, filtr.powK, d.Pow);

                return nb && ob && gb
                          && wladanieUdzial
                          && wladanie_formaWlad
                          && wladanie_Podmiot
                          && wladNumerTrans
                          && wladTytulTrans
                          && kwAkt
                          && kwZrob
                          && wlad_dataOdb_od
                          && wlad_dataOdb_do
                          && powDanePod;
            };
            result = dzialkaView.Cast<object>().Count().ToString();
        }

        private bool checkDate<T>(DateTime? p, DateTime? k, ICollection<T> col, string name)
        {
            DateTime valueDate;
            foreach (var item in col)
            {
                var v = item.GetType().GetProperty(name).GetValue(item);
                if (v != null)
                {
                    DateTime.TryParse(v.ToString(), out valueDate);

                    if (valueDate != null)
                        if (testRange(p, k, valueDate) == true)
                        {
                            return true;
                        }
                }
            }
            return false;
        }

        private bool wlasData(DateTime? p, DateTime? k, ICollection<Wladanie> w)
        {
            foreach (var item in w)
            {
                if (testRange(p, k, item.DataOdbOd) == true)
                {
                    return true;
                }
            }
            return false;
        }


        private bool testDataRangeMulti()
        {

            return false;
        }

        public bool testRange<T>(T limitLow, T limitUp, T value) where T : IComparable
        {
            if ((value == null) && (limitLow == null && limitUp == null))
                return true;

            if ((value == null) && (limitLow == null || limitUp == null))
                return false;

            if (value != null && limitLow == null && limitUp == null)
                return true;

            if (value != null)
            {
                if (limitLow == null)
                {
                    return CompareRaf(value, limitUp);
                }

                if (limitUp == null)
                {
                    return CompareRaf(limitLow, value);
                }

                return CompareRaf(limitLow, value) &&
                       CompareRaf(value, limitUp);
            }

            return false;
        }

        public bool testRange<T>(T? limitLow, T? limitUp, T? value) where T : struct, IComparable
        {
            if ((value == null) && (limitLow == null && limitUp == null))
                return true;

            if ((value == null) && (limitLow == null || limitUp == null))
                return false;

            if (value != null && limitLow == null && limitUp == null)
                return true;

            if (value != null)
            {
                if (limitLow == null)
                {
                    return CompareRaf(value.Value, limitUp.Value);
                }

                if (limitUp == null)
                {
                    return CompareRaf(limitLow.Value, value.Value);
                }

                return CompareRaf(limitLow.Value, value.Value) &&
                       CompareRaf(value.Value, limitUp.Value);
            }

            return false;
        }

        public bool CompareRaf<T>(T nMniejsze, T nWieksze) where T : IComparable
        {
            return nMniejsze.CompareTo(nWieksze) <= 0 ? true : false;
        }

        #endregion

        private bool EqualsStr(string s1, string s2)
        {
            if (s1 == null)
                return false;

            if (s2 == null)
                return false;

            return s1.Contains(s2);
        }

    }
}
