using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessAccessLayer.TryOut_3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessAccessLayer.Constants;

namespace BusinessAccessLayer.TryOut_3.Tests
{
    [TestClass()]
    public class AddressTests
    {
        [TestMethod()]
        public void AddressTest()
        {
            Address testAddress = new Address("Line 1", "Line 2", "California", 12389);
            int expectedPinCode = 12389;
            Assert.AreEqual(expectedPinCode, testAddress.PinCode);
            testAddress.PinCode = -1;
            expectedPinCode = AddressConstants.defaultPinCode;
            Assert.AreEqual(expectedPinCode, testAddress.PinCode);
        }
    }
}