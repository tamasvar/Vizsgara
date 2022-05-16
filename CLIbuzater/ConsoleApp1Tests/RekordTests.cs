using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Tests
{
    [TestClass()]
    public class RekordTests
    {
        [TestMethod()]
        public void RekordTest()
        {
            bool expected = true;
            bool actual = Program.Hatarertek(20,21);
            Assert.AreEqual(expected, actual);
        }
    }
}