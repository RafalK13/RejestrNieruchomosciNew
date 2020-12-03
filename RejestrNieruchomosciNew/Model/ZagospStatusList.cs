using GalaSoft.MvvmLight;
using Microsoft.EntityFrameworkCore;
using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace RejestrNieruchomosciNew.Model
{
    public class ZagospStatusList : ViewModelBase
    {
        public ObservableCollection<ZagospStatus> list { get; set; }

        private ZagospStatus _statusSel;
        public ZagospStatus statusSel
        {
            get { return _statusSel; }
            set
            {
                _statusSel = value;
                RaisePropertyChanged();
                RaisePropertyChanged("functionList");
            }
        }

        public ObservableCollection<ZagospStatus> statusList { get => new ObservableCollection<ZagospStatus>(list.GroupBy(r => r.ZagospStatusSloId).Select(t => t.First()).ToList()); }

        public ObservableCollection<ZagospStatus> functionList
        {
            get
            {
                if (statusSel.ZagospStatusId != 0)
                {
                    return new ObservableCollection<ZagospStatus>(list.Where(r => r.ZagospStatusSloId == statusSel.ZagospStatusSloId));
                }
                else return null;
            }
        }

        public ZagospStatusList()
        {
            using (var c = new Context())
            {
                try
                {
                    list = new ObservableCollection<ZagospStatus>(c.ZagospStatus.Include(r => r.ZagospStatusSlo)
                                                                                .Include(r => r.ZagospFunkcjaSlo).ToList());

                    //var statusList1  = list.GroupBy(r => r.ZagospStatusSloId).Select(t => t.First()).ToList();
                }
                catch (Exception e)
                {
                    MessageBox.Show($"ZagospStatusList\r\n{e.Message}");
                    Environment.Exit(0);
                }
            }
        }
    }
}
