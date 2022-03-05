using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BarLauncher.BaseConverter.Lib.Service;

namespace BarLauncher.BaseConverter.Test.NUnit.Service
{
    [TestFixture]
    public class BaseConvertServiceTest
    {
        public IBaseConvertService BaseConvertService { get; set; }

        [SetUp]
        public void SetUp()
        {
            BaseConvertService = new BaseConvertService();
        }

        [TearDown]
        public void TearDown()
        {
            BaseConvertService = null;
        }

        public void ConvertTest(string value, int baseOrigin, int baseResult, string expectedResult)
        {
            string actualResult = BaseConvertService.Convert(value, baseOrigin, baseResult);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("101", "2", "10", "5")]
        [TestCase("15", "7", "3", "110")]
        [TestCase("25", "10", "8", "31")] // Christmas = Halloween (25 dec = 31 oct)
        [TestCase("deadbeef", "16", "10", "3735928559")]
        [TestCase("3735928559", "10", "16", "deadbeef")]
        [TestCase("000110110001", "2", "2", "110110001")]
        [TestCase("0000", "2", "16", "0")]
        [TestCase("0001", "2", "16", "1")]
        [TestCase("0010", "2", "16", "2")]
        [TestCase("0011", "2", "16", "3")]
        [TestCase("0100", "2", "16", "4")]
        [TestCase("0101", "2", "16", "5")]
        [TestCase("0110", "2", "16", "6")]
        [TestCase("0111", "2", "16", "7")]
        [TestCase("1000", "2", "16", "8")]
        [TestCase("1001", "2", "16", "9")]
        [TestCase("1010", "2", "16", "a")]
        [TestCase("1011", "2", "16", "b")]
        [TestCase("1100", "2", "16", "c")]
        [TestCase("1101", "2", "16", "d")]
        [TestCase("1110", "2", "16", "e")]
        [TestCase("1111", "2", "16", "f")]
        [TestCase("10000", "2", "16", "10")]
        [TestCase("deadbeef", "16", "7", "161402603666")]
        public void ConvertTestStrings(string value, string baseOrigin, string baseResult, string expectedResult)
        {
            var baseOriginInt = Convert.ToInt32(baseOrigin);
            var baseResultInt = Convert.ToInt32(baseResult);
            ConvertTest(value, baseOriginInt, baseResultInt, expectedResult);
        }

    }
}
