using Moq;
using NUnit.Framework;
using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.Model.Interfaces;
using RejestrNieruchomosciNew.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Tests
{
    //class UserControl_ZagospViewModelTests
    //{
    //    IZagospList zagospList = Mock.Of<IZagospList>(t => t.listAll == new ObservableCollection<IZagosp> {
    //           Mock.Of<Zagosp>( r=>r.ZagospId==1 && r.DzialkaId == 1),
    //           Mock.Of<Zagosp>( r=>r.ZagospId==2 && r.DzialkaId == 2),
    //           Mock.Of<Zagosp>( r=>r.ZagospId==3 && r.DzialkaId == 3),
    //           Mock.Of<Zagosp>( r=>r.ZagospId==4 && r.DzialkaId == 4),
    //           Mock.Of<Zagosp>( r=>r.ZagospId==5 && r.DzialkaId == 13)
    //        });

    //    [TestCase(21)]
    //    public void testKonstruktora_sprawdzdenieCzyZrobiNowyZagospGdyNieZnajdzieGowTablicy_powinienPrzejsc(int nr)
    //    {
    //        UserControl_PreviewViewModel userControl_prevModel = Mock.Of<UserControl_PreviewViewModel>(
    //         r => r.dzialkaSel == new Dzialka { DzialkaId = nr }
    //        );

    //        UserControl_ZagospViewModel userControl = new UserControl_ZagospViewModel(userControl_prevModel, zagospList, null);

    //        var result = userControl.zagospLok;

    //        Assert.AreEqual(21, result.DzialkaId);
    //    }

    //    [TestCase(13)]
    //    public void testKonstruktora_sprawdzdenieCzyZnajdzieZagospo_powinienPrzejsc( int nr)
    //    {
    //        UserControl_PreviewViewModel userControl_prevModel = Mock.Of<UserControl_PreviewViewModel>(
    //         r => r.dzialkaSel == new Dzialka { DzialkaId = nr }
    //        );

    //        UserControl_ZagospViewModel userControl = new UserControl_ZagospViewModel(userControl_prevModel, zagospList,null);
                    
    //        var result = userControl.zagospLok;

    //        Assert.AreEqual(5, result.ZagospId);
    //    }

    //    [TestCase(17)]
    //    public void testKonstruktora_UserControl_ZagospViewModel_oczekiwaneZero(int nr)
    //    {
    //        UserControl_PreviewViewModel userControl_prevModel = Mock.Of<UserControl_PreviewViewModel>(
    //         r => r.dzialkaSel == new Dzialka { DzialkaId = nr }
    //        );

    //        UserControl_ZagospViewModel userControl = new UserControl_ZagospViewModel(userControl_prevModel, zagospList, null);

    //        var result = userControl.zagospLok;

    //        Assert.AreEqual(0, result.ZagospId);
    //    }
    //}
}

