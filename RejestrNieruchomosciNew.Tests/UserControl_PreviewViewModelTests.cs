using Moq;
using NUnit.Framework;
using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Tests
{
    //public class UserControl_PreviewViewModelTests
    //{
    //    public class TestData3
    //    {
    //        public DateTime? data1 { get; set; }
    //        public DateTime? data2 { get; set; }
    //        public DateTime? data3 { get; set; }
    //        public bool result { get; set; }
    //    }

    //    private static TestData3[] testData3 = new TestData3[]
    //    {
    //          new TestData3 { data1 = new DateTime(2001, 10, 10),
    //                          data2 = new DateTime(2020, 02, 11),
    //                          data3 = new DateTime(2010, 02, 13),
    //                          result = true},

    //         new TestData3 { data1 = new DateTime(2020, 01, 13),
    //                         data3 = new DateTime(2020, 02, 13),
    //                         result = true },

    //         new TestData3 { data2 = new DateTime(2020, 03, 13),
    //                         data3 = new DateTime(2020, 04, 13),
    //                         result = false },

    //        new TestData3 { data1 = new DateTime(2020, 01, 13),
    //                        data2 = new DateTime(2020, 03, 13),
    //                        data3 = new DateTime(2020, 02, 13),
    //                        result = true },

    //        new TestData3 { data1 = new DateTime(2020, 01, 13),
    //                        data2 = new DateTime(2020, 02, 13),
    //                        data3 = new DateTime(2020, 03, 13),
    //                        result = false },

    //        new TestData3 { data1 = new DateTime(2020, 03, 13),
    //                        data2 = new DateTime(2020, 02, 13),
    //                        data3 = new DateTime(2020, 01, 13),
    //                        result = false },

    //        new TestData3 { data1 = new DateTime(2020, 03, 13),
    //                        data2 = new DateTime(2020, 02, 13),
    //                        result = false },

    //        new TestData3 { data1 = new DateTime(2020, 03, 13),
    //                        data2 = new DateTime(2020, 02, 13),
    //                        result = false }
    //        //new TestData3 { result = true }
    //    };
       
    //    [TestCaseSource("testData3")]
    //    //[Ignore("testRange_forDateTime1")]
    //    public void testRange_forDateTime1(TestData3 data3)
    //    {
    //        IDzialkaList dzMock = Mock.Of<IDzialkaList>();

    //        var c = new UserControl_PreviewViewModel(dzMock);
    //        var w = c.testRange<DateTime>(data3.data1, data3.data2, data3.data3);

    //        Assert.That(w, Is.EqualTo(data3.result));
    //    }

    //    [TestCase(null, null, null, true)]
    //    [TestCase("Raf", null, null, false)]
    //    [TestCase(null, "Raf", null, false)]
    //    [TestCase(null, null, "Raf", true)]
    //    [TestCase("Raf1", "Raf2", "Raf", false)]
    //    [TestCase("Raf1", "Raf3", "Raf2", true)]
    //    [TestCase("Raf1", "Raf3", null, false)]
    //    [TestCase("Raf2", "Raf3", "Raf1", false)]
    //    [TestCase("Raf1", "Raf2", "Raf3", false)]
    //    //[Ignore("testRange_forString")]
    //    public void testRange_forString(string p1, string p2, string p, bool result)
    //    {
    //        IDzialkaList dzMock = Mock.Of<IDzialkaList>();

    //        var c = new UserControl_PreviewViewModel(dzMock);
    //        var w = c.testRange<string>(p1, p2, p);

    //        Assert.That(w, Is.EqualTo(result));
    //    }

    //    [TestCase(null, null, null, true)]
    //    [TestCase(13, null, null, false)]
    //    [TestCase(null, 13, null, false)]
    //    [TestCase(null, null, 13, true)]
    //    [TestCase(1, 2, 13, false)]
    //    [TestCase(1, 15, 13, true)]
    //    [TestCase(2, 15, 1, false)]
    //    [TestCase(2, 15, null, false)]
    //    //[Ignore("testRange_forDouble")]
    //    public void testRange_forDouble(double? p1, double? p2, double? p, bool result)
    //    {
    //        IDzialkaList dzMock = Mock.Of<IDzialkaList>();

    //        var c = new UserControl_PreviewViewModel(dzMock);
    //        var w = c.testRange<double>(p1, p2, p);

    //        Assert.That(w, Is.EqualTo(result));
    //    }

    //    #region compareRaf
    //    public class TestData2
    //    {
    //        public DateTime data1 { get; set; }
    //        public DateTime data2 { get; set; }
    //        public bool result { get; set; }
    //    }

    //    private static TestData2[] testData2 = new TestData2[]{ new TestData2 { data1 = new DateTime(2020, 01, 13), data2 = new DateTime(2020, 01, 13), result = true }
    //                                                          , new TestData2 { data1 = new DateTime(2020, 01, 13), data2 = new DateTime(2020, 02, 13), result = true }
    //                                                          , new TestData2 { data1 = new DateTime(2020, 02, 13), data2 = new DateTime(2020, 01, 13), result = false }
    //                                                          , new TestData2 { data2 = new DateTime(2020, 01, 13), result = true }
    //                                                          , new TestData2 { data1 = new DateTime(2020, 01, 13), result = false }
    //                                                          , new TestData2 { result = true }
    //                                                          };

    //    [TestCaseSource("testData2")]
    //    public void CompareRaf_sprawdzenieCzydziala_dlaDateTime(TestData2 dane)
    //    {
    //        IDzialkaList dzMock = Mock.Of<IDzialkaList>();

    //        var c = new UserControl_PreviewViewModel(dzMock);

    //        var w = c.CompareRaf(dane.data1, dane.data2);

    //        Assert.That(w, Is.EqualTo(dane.result));
    //    }

    //    public class TestData
    //    {
    //        public DateTime data1 { get; set; }
    //        public DateTime data2 { get; set; }
    //        public bool result { get; set; }
    //    }

    //    private static TestData[] testData = new TestData[] { new TestData { data1 = new DateTime(2020, 01, 13), data2 = new DateTime(2020, 01, 13), result=true } };

    //    [Test]
    //    public void CompareRaf_sprawdzenieCzydziala_dlaDateTime([ValueSource("testData")] TestData dataRaf )
    //    {
    //        IDzialkaList dzMock = Mock.Of<IDzialkaList>();

    //        var c = new UserControl_PreviewViewModel(dzMock);

    //        var w = c.CompareRaf(dataRaf.data1, dataRaf.data2);

    //        Assert.That(w, Is.EqualTo(dataRaf.result));
    //    }

    //    [TestCase("s1", "s2", true)]
    //    [TestCase("s2", "s1", false)]
    //    public void CompareRaf_sprawdzenieCzydziala_dlastring(string wartoscMniejsz, string wartoscWieksza, bool result)
    //    {
    //        IDzialkaList dzMock = Mock.Of<IDzialkaList>();

    //        var c = new UserControl_PreviewViewModel(dzMock);

    //        var w = c.CompareRaf(wartoscMniejsz, wartoscWieksza);

    //        Assert.That(w, Is.EqualTo(result));
    //    }

    //    [TestCase(1, 13, true)]
    //    [TestCase(113, 13, false)]
    //    [TestCase(113, 113, true)]
    //    public void CompareRaf_sprawdzenieCzydziala_dlaInt(int wartoscMniejsz, int wartoscWieksza, bool result)
    //    {
    //        IDzialkaList dzMock = Mock.Of<IDzialkaList>();

    //        var c = new UserControl_PreviewViewModel(dzMock);

    //        var w = c.CompareRaf(wartoscMniejsz, wartoscWieksza);

    //        Assert.That(w, Is.EqualTo(result));
    //    }
    //    #endregion
    //}
}
