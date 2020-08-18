using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore;
using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.Model.Interfaces;
using RejestrNieruchomosciNew.View;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace RejestrNieruchomosciNew.ViewModel
{
    public class UserControl_InfoWladanieViewModel : ViewModelBase
    {

        public RodzajDokumentuList rodzDokList { get; set; }
        public NazwaCzynnosciList nazwaCzynList { get; set; }
        public ICelNabyciaList celNabyciaList { get; set; }

        private IWladanie _wladanieSel;
        public IWladanie wladanieSel
        {
            get => _wladanieSel;
            set
            {
                _wladanieSel = value;
                //getWladanieSel();
                RaisePropertyChanged();
            }
        }

        //private IWladanie _wlad;

        //public IWladanie wlad
        //{
        //    get { return _wlad; }
        //    set { Set( ref _wlad, value); }
        //}


        //private void getWladanieSel()
        //{
        //    if(wladanieSel != null)
        //    using (Context c = new Context())
        //    {
        //        try
        //        {
        //            wlad = c.Wladanie.AsNoTracking().Include(f => f.FormaWladaniaSlo)
        //                                            .Include(t => t.TransakcjeK_Wlad)
        //                                            .FirstOrDefault(r => r.WladanieId == wladanieSel.WladanieId && r.TransS_Id == null);
                    
        //        }
        //        catch (Exception e)
        //        {
        //            MessageBox.Show($"WladanieList\r\n{e.Message}");
        //            Environment.Exit(0);
        //        }
        //    }
        //}

        private UserControl_PreviewViewModel _prev;
        public UserControl_PreviewViewModel prev
        {
            get => _prev;
            set
            {
                _prev = value;
                RaisePropertyChanged();
                prev.zmianaDzialkaSel += Prev_zmianaDzialkaSel;
            }
        }

        private IWladanieList _wladanieList;
        public IWladanieList wladanieList
        {
            get => _wladanieList;
            set
            {
                _wladanieList = value;
                RaisePropertyChanged();
            }
        }

        private void Prev_zmianaDzialkaSel(object sender, System.EventArgs e)
        {
            if (prev != null)
            {
                wladanieList.getList(prev.dzialkaSel);
            }
        }

        public UserControl_InfoWladanieViewModel()
        {
        }
    }
}
