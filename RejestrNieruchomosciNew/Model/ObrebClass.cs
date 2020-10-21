using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace RejestrNieruchomosciNew.Model
{
    public class ObrebClass : ViewModelBase, IObrebClass
    {
        #region Properties
        public IObrebList obrebList { get; set; }

        private ICollectionView _gminaView;
        public ICollectionView gminaView
        {
            get
            {
                if (obrebValue != null)
                    return CollectionViewSource.GetDefaultView(obrebList.obrebList.Where(a => a.Nazwa.Contains(obrebValue)).Select(a => a.GminaSlo.Nazwa).Distinct());
                else
                    return CollectionViewSource.GetDefaultView(obrebList.obrebList.Select(a => a.GminaSlo.Nazwa).Distinct());
            }

            set
            {
                _gminaView = value;
                RaisePropertyChanged("gminaView");
            }
        }

        private ICollectionView _obrebView;
        public ICollectionView obrebView
        {
            get
            {
                if (gminaValue != null)
                    return CollectionViewSource.GetDefaultView(obrebList.obrebList.Where(a => a.GminaSlo.Nazwa.Contains(gminaValue)).Select(a => a.Nazwa).Distinct());
                else
                    return CollectionViewSource.GetDefaultView(obrebList.obrebList.Select(a => a.Nazwa).Distinct());
            }

            set
            {
                _obrebView = value;
                RaisePropertyChanged("obrebView");
            }
        }

        public int? id
        {
            get => getId();
        }

        private string _obrebValue;
        public string obrebValue
        {
            get => _obrebValue;
            set
            {
                _obrebValue = value;
                RaisePropertyChanged("obrebValue");
                RaisePropertyChanged("gminaView");

                //setFilter();
            }
        }

        private string _gminaValue;
        public string gminaValue
        {
            get => _gminaValue;
            set
            {
                _gminaValue = value;
                RaisePropertyChanged("gminaValue");
                RaisePropertyChanged("obrebView");
                //setFilter();
            }
        }
        #endregion

        #region Methods

        public Obreb getObreb()
        {
            int? n = getId();
            return n != null ? obrebList.obrebList.FirstOrDefault(r => r.ObrebId == n) : null;
        }

        public void fillValues(IDzialka d)
        {
            try
            {
                if (gminaView != null && obrebView != null)
                {
                    var v = obrebList.obrebList.Where(r => r.ObrebId == d.ObrebId).First();

                    obrebValue = v.Nazwa;
                    gminaValue = v.GminaSlo.Nazwa;
                }
            }
            catch 
            {
                obrebValue = null;
                gminaValue = null;
            }
        }


        public void fillValues(int id)
        {
            try
            {
                if (gminaView != null && obrebView != null)
                {
                    obrebValue = obrebList.obrebList.Where(r => r.ObrebId == id).First().Nazwa;
                    gminaValue = obrebList.obrebList.Where(r => r.ObrebId == id).First().GminaSlo.Nazwa;
                }
            }
            catch (Exception)
            {
                obrebValue = null;
                gminaValue = null;
            }
        }

        public int getId(string obreb, string gmina)
        {
            return obrebList.obrebList.FirstOrDefault(r => r.Nazwa == obreb && r.GminaSlo.Nazwa == gmina).ObrebId;
        }

        public int? getId()
        {
            int? n = null;
            if (!string.IsNullOrEmpty(obrebValue) && !string.IsNullOrEmpty(gminaValue))
            {

                n =  obrebList.obrebList.FirstOrDefault(o => o.Nazwa == obrebValue && o.GminaSlo.Nazwa == gminaValue).ObrebId;
                //using (var c = new Context())
                //{
                //    n = c.Obreb.FirstOrDefault(o => o.Nazwa == obrebValue && o.GminaSlo.Nazwa == gminaValue).ObrebId;
                //}
            }
            return n;
        }

        public void clsObreb()
        {
            gminaValue = string.Empty;
            obrebValue = string.Empty;
        }
        #endregion
    }
}
