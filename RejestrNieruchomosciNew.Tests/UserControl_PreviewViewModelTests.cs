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
    public class UserControl_PreviewViewModelTests
    {
        [TestCase(null, null, null, false)]
        [TestCase(13, null, null, false)]
        [TestCase(null, 13, null, false)]
        [TestCase(null, null, 13, true)]
        [TestCase(1, 2, 13, false)]
        [TestCase(1, 15, 13, true)]
        [TestCase(2, 15, 1, false)]
        [TestCase(2, 15, null, false)]

        public void testPow(double? p1, double? p2, double? p, bool result)
        {
            IDzialkaList dzMock = Mock.Of<IDzialkaList>();

            var c = new UserControl_PreviewViewModel(dzMock);

            var w = c.testPow(p1, p2, p);

            Assert.That(w, Is.EqualTo(result));
        }


        public class TestData2
        {
            public DateTime data1 { get; set; }
            public DateTime data2 { get; set; }
            public bool result { get; set; }
        }

        private static TestData2[] testData2 = new TestData2[]{ new TestData2 { data1 = new DateTime(2020, 01, 13), data2 = new DateTime(2020, 01, 13), result = true }
                                                              , new TestData2 { data1 = new DateTime(2020, 01, 13), data2 = new DateTime(2020, 02, 13), result = true }
                                                              , new TestData2 { data1 = new DateTime(2020, 02, 13), data2 = new DateTime(2020, 01, 13), result = false }
                                                              , new TestData2 { data2 = new DateTime(2020, 01, 13), result = true }
                                                              , new TestData2 { data1 = new DateTime(2020, 01, 13), result = false }
                                                              , new TestData2 { result = true }
                                                              };

        [TestCaseSource("testData2")]
        public void CompareRaf_sprawdzenieCzydziala_dlaDateTime(TestData2 dane)
        {
            IDzialkaList dzMock = Mock.Of<IDzialkaList>();

            var c = new UserControl_PreviewViewModel(dzMock);

            var w = c.CompareRaf(dane.data1, dane.data2);

            Assert.That(w, Is.EqualTo(dane.result));
        }

        public class TestData
        {
            public DateTime data1 { get; set; }
            public DateTime data2 { get; set; }
            public bool result { get; set; }
        }

        private static TestData[] testData = new TestData[] { new TestData { data1 = new DateTime(2020, 01, 13), data2 = new DateTime(2020, 01, 13), result=true } };

        [Test]
        public void CompareRaf_sprawdzenieCzydziala_dlaDateTime([ValueSource("testData")] TestData dataRaf )
        {
            IDzialkaList dzMock = Mock.Of<IDzialkaList>();

            var c = new UserControl_PreviewViewModel(dzMock);

            var w = c.CompareRaf(dataRaf.data1, dataRaf.data2);

            Assert.That(w, Is.EqualTo(dataRaf.result));
        }

        [TestCase("s1", "s2", true)]
        [TestCase("s2", "s1", false)]
        public void CompareRaf_sprawdzenieCzydziala_dlastring(string wartoscMniejsz, string wartoscWieksza, bool result)
        {
            IDzialkaList dzMock = Mock.Of<IDzialkaList>();

            var c = new UserControl_PreviewViewModel(dzMock);

            var w = c.CompareRaf(wartoscMniejsz, wartoscWieksza);

            Assert.That(w, Is.EqualTo(result));
        }

        [TestCase(1, 13, true)]
        [TestCase(113, 13, false)]
        [TestCase(113, 113, true)]
        public void CompareRaf_sprawdzenieCzydziala_dlaInt(int wartoscMniejsz, int wartoscWieksza, bool result)
        {
            IDzialkaList dzMock = Mock.Of<IDzialkaList>();

            var c = new UserControl_PreviewViewModel(dzMock);

            var w = c.CompareRaf(wartoscMniejsz, wartoscWieksza);

            Assert.That(w, Is.EqualTo(result));
        }
    }
}
