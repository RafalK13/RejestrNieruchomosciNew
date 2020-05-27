using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model
{
    public class AdresSloList : INotifyPropertyChanged, IAdresSloList
    {
        private IMiejscowoscSloList _miejscList;
        private IUlicaSloList _ulicaList;

        public IMiejscowoscSloList miejscList
        {
            get => _miejscList;
            set
            {
               _miejscList = value;
                NotifyPropertyChanged();
                if (zmiana != null)
                    zmiana(null, EventArgs.Empty);
            }
        }

        public IUlicaSloList ulicaList
        {
            get => _ulicaList;
            set
            {
                _ulicaList = value;
                NotifyPropertyChanged();
            }
           }

        #region events
        [field: NonSerialized]
        public event EventHandler zmiana;

        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
