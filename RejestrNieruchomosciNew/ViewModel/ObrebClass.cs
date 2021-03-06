﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace RejestrNieruchomosciNew.ViewModel
{
    public class ObrebClass : INotifyPropertyChanged
    {
        //public Dzialka _dzialkaSel;
        //public Dzialka dzialkaSel
        //{
        //    get => _dzialkaSel;
        //    set
        //    {
        //        _dzialkaSel = value;
        //    }
        //}

        public List<Obreb> obrebList { get; set; }

        private ICollectionView _gminaView;
        public ICollectionView gminaView
        {
            get
            {
                if (obrebValue != null)
                    return CollectionViewSource.GetDefaultView(obrebList.Where(a => a.Nazwa.Contains(obrebValue)).Select(a => a.GminaSlo.Nazwa).Distinct());
                else
                    return CollectionViewSource.GetDefaultView(obrebList.Select(a => a.GminaSlo.Nazwa).Distinct());
            }

            set
            {
                _gminaView = value;
                OnPropertyChanged("gminaView");
            }
        }

        private ICollectionView _obrebView;
        public ICollectionView obrebView
        {
            get
            {
                if (gminaValue != null)
                    return CollectionViewSource.GetDefaultView(obrebList.Where(a => a.GminaSlo.Nazwa.Contains(gminaValue)).Select(a => a.Nazwa).Distinct());
                else
                    return CollectionViewSource.GetDefaultView(obrebList.Select(a => a.Nazwa).Distinct());
            }

            set
            {
                _obrebView = value;
                OnPropertyChanged("obrebView");
            }
        }

        private string _obrebValue;
        public string obrebValue
        {
            get => _obrebValue;
            set
            {
                _obrebValue = value;
                OnPropertyChanged("obrebValue");
                OnPropertyChanged("gminaView");
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
                OnPropertyChanged("gminaValue");
                OnPropertyChanged("obrebView");
                //setFilter();
            }
        }

        public ObrebClass()
        {
            obrebList = new List<Obreb>();
            initObreb();
        }

        private void initObreb()
        {
            using (var c = new Context())
            {
                obrebList = c.Obreb.Include("GminaSlo").ToList();
            }
        }

        public int? getId()
        {
            int? n = null;
            if (!string.IsNullOrEmpty(obrebValue) && !string.IsNullOrEmpty(gminaValue))
            {
                using (var c = new Context())
                {
                    n = c.Obreb.FirstOrDefault(o => o.Nazwa == obrebValue && o.GminaSlo.Nazwa == gminaValue).ObrebId;
                }
            }
            return n;
        }

        #region OnPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion
    }
}
