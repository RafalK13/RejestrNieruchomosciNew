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
               if (Nullable.GetUnderlyingType(prop.PropertyType) != null)
                {
                    prop.SetValue(this, null);
                }
                else
                {
                    TypeCode typeCode = Type.GetTypeCode(prop.PropertyType);
                    switch (typeCode)
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
        }

        private double? _powK;
        public double?  powK
        {
            get { return _powK; }
            set { Set( ref _powK, value); }
        }

        private double?  _powP;
        public double?  powP
        {
            get { return _powP; }
            set { Set( ref _powP , value); }
        }

        private string _kwAkt;              
        public string kwAkt
        {
            get { return _kwAkt; }
            set { Set( ref _kwAkt, value); }
        }

        private string _kwZrob;
        public string kwZrob
        {
            get { return _kwZrob; }
            set { Set( ref _kwZrob ,value); }
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

        private DateTime? _wlad_dataOdb_odP;
        public DateTime? wlad_dataOdb_odP
        {
            get { return _wlad_dataOdb_odP; }
            set { Set(ref _wlad_dataOdb_odP, value); }
        }

        private DateTime? _wlad_dataOdb_odK;
        public DateTime? wlad_dataOdb_odK
        {
            get { return _wlad_dataOdb_odK; }
            set { Set(ref _wlad_dataOdb_odK, value); }
        }

        private DateTime? _wlad_dataOdb_doP;
        public DateTime? wlad_dataOdb_doP
        {
            get { return _wlad_dataOdb_doP; }
            set { Set(ref _wlad_dataOdb_doP, value); }
        }

        private DateTime? _wlad_dataOdb_doK;
        public DateTime? wlad_dataOdb_doK
        {
            get { return _wlad_dataOdb_doK; }
            set { Set(ref _wlad_dataOdb_doK, value); }
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
