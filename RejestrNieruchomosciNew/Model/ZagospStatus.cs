using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RejestrNieruchomosciNew.Model
{
    public class ZagospStatus : IZagospStatus, INotifyPropertyChanged
    {
        public int ZagospStatusId { get; set; }

        public int ZagospStatusSloId { get; set; }

        private int _ZagospFunkcjaSloId;
        public int ZagospFunkcjaSloId
        {
            get => _ZagospFunkcjaSloId;
            set
            {
                _ZagospFunkcjaSloId = value;
                NotifyPropertyChanged();
                if (zmiana != null)
                    zmiana(null, EventArgs.Empty);

            }
        }

        public ZagospStatusSlo ZagospStatusSlo { get; set; }
        public ZagospFunkcjaSlo ZagospFunkcjaSlo { get; set; }

        public ICollection<Zagosp> Zagosp { get; set; }

        public event EventHandler zmiana;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

