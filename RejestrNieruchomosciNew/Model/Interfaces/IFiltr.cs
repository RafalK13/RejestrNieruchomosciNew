﻿using System;

namespace RejestrNieruchomosciNew.Model.Interfaces
{
    public interface IFiltr
    {
        void czysc();

        int wlad_podmiot { get; set; }
        int wlad_formaWladId { get; set; }
        string wlad_udzial { get; set; }
        DateTime? wlad_dataOdb_odP { get; set; }
        DateTime? wlad_dataOdb_odK { get; set; }
        DateTime? wlad_dataOdb_doP { get; set; }
        DateTime? wlad_dataOdb_doK { get; set; }

        DateTime? wlad_NrProtPrzej { get; set; }
        int wlad_celNadId { get; set; }
        int wlad_RodzajTransakcjiSloId { get; set; }
        int wlad_NazwaCzynnosciSloId { get; set; }
        int wlad_RodzajDokumentuSloId { get; set; }
        string wlad_NumerTrans { get; set; }
        DateTime wlad_dataTrans { get; set; }
        string wlad_TytulTrans { get; set; }

        string kwAkt { get; set; }
        string kwZrob { get; set; }

        double? powP { get; set; }
        double? powK { get; set; }
    }
}