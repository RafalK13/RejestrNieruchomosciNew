﻿using GalaSoft.MvvmLight;
using RejestrNieruchomosciNew.Validations;
using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace RejestrNieruchomosciNew.Model
{
    public interface IDzialka : IEquatable<IDzialka>, IDataErrorInfo
    {
        int DzialkaId { get; set; }
        string Numer { get; set; }
        string Kwakt { get; set; }
        string Kwzrob { get; set; }
        double? Pow { get; set; }

        string lokalizacja { get; set; }
        string uzbrojenie { get; set; }
        string ksztalt { get; set; }
        string sasiedztwo { get; set; }
        string dostDoDrogi { get; set; }
        string rodzNaw { get; set; }
        
        //int? KonserwZabytkowSloId { get; set; }
        //int? KonserwPrzyrodySloId { get; set; }

        int ObrebId { get; set; }
        Obreb Obreb { get; set; }

        //int? AdresId { get; set; }
        Adres Adres { get; set; }

        PlatnoscUW PlatnoscUW { get; set; }
        DzialkaOchrona DzialkaOchrona { get; set; }

        //string Error { get; }
        //string this[string columnName] { get; }

        DzialkaValidator _validatorDzialka { get; set; }

        int GetHashCode();

        void clone( IDzialka d);
        object clone();

        void copy( IDzialka dzDest, IDzialka dzSource);

        IDzialka copy(IDzialka dzSource);

        event EventHandler zmiana;
        event EventHandler zmianaObreb;
    }
}
