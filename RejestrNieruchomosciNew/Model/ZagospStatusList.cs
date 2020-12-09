using Castle.Core;
using GalaSoft.MvvmLight;
using Microsoft.EntityFrameworkCore;
using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace RejestrNieruchomosciNew.Model
{
    public class ZagospStatusList : ViewModelBase
    {
        public event EventHandler zmianaZagospStatus;

        public ZagospStatusListSlo ZagospStatusListSlo { get; set; }

        private IZagospStatus _statusSel;

        public IZagospStatus statusSel
        {
            get { return _statusSel; }
            set
            {
                _statusSel = value;
                RaisePropertyChanged();
                RaisePropertyChanged("functionList");
            }
        }

        public void ustalId( int? id)
        {
            if (id.HasValue)
            {
                int iStatusSlo = ZagospStatusListSlo.list.FirstOrDefault(r => r.ZagospStatusId == id).ZagospStatusSloId;
                statusSel = ZagospStatusListSlo.list.FirstOrDefault(r => r.ZagospStatusSloId == iStatusSlo);
                funkcjaSel = ZagospStatusListSlo.list.FirstOrDefault(r => r.ZagospStatusId == id);
            }
        }

        private ZagospStatus _funkcjaSel;

        public ZagospStatus funkcjaSel
        {
            get { return _funkcjaSel; }
            set
            {
                _funkcjaSel = value;

                if (zmianaZagospStatus != null)
                    zmianaZagospStatus.Invoke( null, EventArgs.Empty);

                RaisePropertyChanged();
            }
        }

        public ObservableCollection<ZagospStatus> statusList
        {
            get
            {
                return new ObservableCollection<ZagospStatus>(ZagospStatusListSlo.list.GroupBy(r => r.ZagospStatusSloId).Select(t => t.First()).ToList()); }
            }

        public ObservableCollection<ZagospStatus> functionList
        {
            get
            {
                if (statusSel != null)
                    return new ObservableCollection<ZagospStatus>(ZagospStatusListSlo.list.Where(r => r.ZagospStatusSloId == statusSel.ZagospStatusSloId));
                else
                    return null;
            }
        }
    }
}
