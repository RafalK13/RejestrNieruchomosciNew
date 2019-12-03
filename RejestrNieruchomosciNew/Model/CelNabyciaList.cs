using GalaSoft.MvvmLight;
using RejestrNieruchomosciNew.Model.Interfaces;
using System.Collections.ObjectModel;
using System.Windows;

namespace RejestrNieruchomosciNew.Model
{
    public class CelNabyciaList : ViewModelBase, ICelNabyciaList
    {
        public ObservableCollection<ICelNabycia> list { get; set; }

        public CelNabyciaList()
        {
            using (var c = new Context())
            {
                list = new ObservableCollection<ICelNabycia>(c.CelNabyciaView);
            }
        }
    }
}
