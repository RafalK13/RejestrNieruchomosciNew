using GalaSoft.MvvmLight;
using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Windows;

namespace RejestrNieruchomosciNew.Model
{
    public class Filtr : ViewModelBase,  IFiltr
    {
        public void czysc()
        {
            var v = this.GetType();// typeof(Filtr);
            foreach (var prop in v.GetProperties())
            {
                TypeCode typeCode = Type.GetTypeCode(prop.PropertyType);
                switch ( typeCode)
                {
                    case TypeCode.Byte:
                    case TypeCode.Int16:
                    case TypeCode.UInt16:
                    case TypeCode.Int32:
                    case TypeCode.UInt32:
                    case TypeCode.Int64:
                    case TypeCode.UInt64:
                    case TypeCode.Single:
                         prop.SetValue(this, 0);
                         break;

                    case TypeCode.String:
                        prop.SetValue(this, null);
                        break;

                    case TypeCode.DateTime:
                        prop.SetValue(this, null);
                        break;
                    //default:
                    //    MessageBox.Show(Type.GetTypeCode(prop.GetType()).ToString());
                    //    break;
                }

            }
        }

        private int _wlad_podmiot;
        public int wlad_podmiot
        {
            get { return _wlad_podmiot; }
            set { Set(ref _wlad_podmiot, value); }
        }

        private int _wlad_formaWladId;
        public int wlad_formaWladId
        {
            get { return _wlad_formaWladId; }
            set { Set(ref _wlad_formaWladId , value); }
        }
       
        private string _wlad_udzial;
        public string wlad_udzial
        {
            get { return _wlad_udzial; }
            set { Set(ref _wlad_udzial, value); }
        }

        private DateTime? _wlad_dataOdbOdP;
        public DateTime? wlad_dataOdbOdP
        {
            get { return _wlad_dataOdbOdP; }
            set { Set(ref  _wlad_dataOdbOdP ,value); }
        }

        private DateTime? _wlad_dataOdbOdK;
        public DateTime? wlad_dataOdbOdK
        {
            get { return _wlad_dataOdbOdK; }
            set { Set(ref _wlad_dataOdbOdK, value); }
        }

        private DateTime? _wlad_dataOdbODo;
        public DateTime? wlad_dataOdbODo
        {
            get { return _wlad_dataOdbODo; }
            set { Set(ref _wlad_dataOdbODo, value); }
        }

        private DateTime? _wlad_NrProtPrzej;
        public DateTime? wlad_NrProtPrzej
        {
            get { return _wlad_NrProtPrzej; }
            set { Set(ref _wlad_NrProtPrzej, value); }
        }

        private int _wlad_celNadId;
        public int wlad_celNadId
        {
            get { return _wlad_celNadId; }
            set { Set(ref _wlad_celNadId, value); }
        }

        private int _wlad_RodzajTransakcjiSloId;
        public int wlad_RodzajTransakcjiSloId
        {
            get { return _wlad_RodzajTransakcjiSloId; }
            set { Set(ref _wlad_RodzajTransakcjiSloId, value); }
        }

        private int _wlad_NazwaCzynnosciSloId;
        public int wlad_NazwaCzynnosciSloId
        {
            get { return _wlad_NazwaCzynnosciSloId; }
            set { Set(ref _wlad_NazwaCzynnosciSloId, value); }
        }

        private int _wlad_RodzajDokumentuSloId;
        public int wlad_RodzajDokumentuSloId
        {
            get { return _wlad_RodzajDokumentuSloId; }
            set { Set(ref _wlad_RodzajDokumentuSloId, value); }
        }

        private string _wlad_NumerTrans;
        public string wlad_NumerTrans
        {
            get { return _wlad_NumerTrans; }
            set { Set(ref _wlad_NumerTrans, value); }
        }

        private DateTime _wlad_dataTrans;
        public DateTime wlad_dataTrans
        {
            get { return _wlad_dataTrans; }
            set { Set(ref _wlad_dataTrans, value); }
        }

        private string _wlad_TytulTrans;
        public string wlad_TytulTrans
        {
            get { return _wlad_TytulTrans; }
            set { Set(ref _wlad_TytulTrans, value); }
        }
    }
}
