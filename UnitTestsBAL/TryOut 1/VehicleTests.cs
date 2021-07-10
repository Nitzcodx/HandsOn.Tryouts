using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessAccessLayer.TryOut_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.TryOut_1.Tests
{
    [TestClass()]
    public class VehicleTests
    {
        Vehicle testVehicle = new TwoWheeler(false, 3, 6);
        [TestMethod()]
        public void VehicleTest()
        {
            short expectedFuelLevel = 3; 
            Assert.AreEqual(expectedFuelLevel, testVehicle.FuelLevel);
            testVehicle.FuelLevel = 15;
            expectedFuelLevel = 10;
            Assert.AreEqual(expectedFuelLevel, testVehicle.FuelLevel);
        }

        [TestMethod()]
        public void FixBrakesTest()
        {
            Assert.IsTrue(testVehicle.FixBrakes());
            testVehicle.AreBrakesWorking = true;
            Assert.IsFalse(testVehicle.FixBrakes());
        }

    }
}