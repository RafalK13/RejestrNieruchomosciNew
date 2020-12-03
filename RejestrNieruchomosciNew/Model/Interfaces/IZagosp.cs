using System;

namespace RejestrNieruchomosciNew.Model.Interfaces
{
    public interface IZagosp : ICloneable
    {
        int ZagospId { get; set; }
        int? DzialkaId { get; set; }
        int? ZagospStatusId { get; set; }

        int? istObiektySloId { get; set; }       //1
        int? zadInwestSloId { get; set; }        //2
        string PlanowaneZagosp { get; set; }     //3
        string DodatkoweZagosp { get; set; }     //4
        string DoWylaczenia { get; set; }        //5

        string WylaczenieProt { get; set; }      //6
        string WylacznieProtokolPath { get; }    //7
        string WylacznieInfo { get; set; }       //8
        string WylacznieInfoPath { get; }        //9

        event EventHandler zmiana;
    }
}
