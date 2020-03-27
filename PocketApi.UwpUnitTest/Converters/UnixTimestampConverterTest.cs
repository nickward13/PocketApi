using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PocketApi.Converters;

namespace PocketApi.UwpUnitTest.Converters
{
    [TestClass]
    public class UnixTimestampConverterTest
    {
        [TestMethod]
        public void TestToUnixTimestamp()
        {
            double timestamp = UnixTimestampConverter.ToUnixtimestamp(new DateTime(2020, 3, 27, 4, 33, 0));
            Assert.AreEqual(1585283580, timestamp);
        }

        [TestMethod]
        public void TestToDateTime()
        {
            DateTime resultDateTime = UnixTimestampConverter.ToDateTime(1585283580);
            Assert.AreEqual(new DateTime(2020, 3, 27, 4, 33, 0), resultDateTime);
        }
    }
}
