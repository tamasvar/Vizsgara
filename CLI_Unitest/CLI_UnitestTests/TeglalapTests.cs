using Microsoft.VisualStudio.TestTools.UnitTesting;
using CLI_Unitest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI_Unitest.Tests
{
    [TestClass()]
    public class TeglalapTests
    {
        [TestMethod()]
        public void TeruletTest()
        {
            double elvart = 2 * 2;
            Assert.AreEqual(elvart, Teglalap.Terulet(2.1, 2.3), 1);
        }

        [TestMethod()]
        public void KeruletTest()
        {
            double elvart = 2* (2 + 2);
            Assert.AreEqual(elvart, Teglalap.Kerulet(2.1, 2.3), 1.5);
        }
    }
}