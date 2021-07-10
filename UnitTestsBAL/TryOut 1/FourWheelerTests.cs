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
    public class FourWheelerTests
    {
        FourWheeler testCar = new FourWheeler(false, 40, 'M');
        [TestMethod()]
        public void FourWheelerTest()
        {
            char expectedCoolantLevel = 'M';
            Assert.AreEqual(expectedCoolantLevel, testCar.EngineCoolantLevel);
            testCar.EngineCoolantLevel = 'A';
            expectedCoolantLevel = 'H';
            Assert.AreEqual(expectedCoolantLevel, testCar.EngineCoolantLevel);
        }

        [TestMethod()]
        public void FixEngineCoolantLevelTest()
        {
            Assert.IsTrue(testCar.FixEngineCoolantLevel());
            Assert.IsFalse(testCar.FixEngineCoolantLevel());
        }

        [TestMethod()]
        public void RefuelVehicleTest()
        {
            try
            {
                testCar.RefuelVehicle(11);
            }
            catch (Exceptions.FuelOverflowException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void RefuelVehicleTest1()
        {
            testCar.RefuelVehicle(10);
            float expectedFuelLevel = 50;
            Assert.AreEqual(expectedFuelLevel, testCar.FuelLevel);
        }

        [TestMethod()]
        public void UpdateVehicleStatusTest()
        {
            testCar.UpdateVehicleStatus();
            string expectedStatus = "Critical";
            Assert.AreEqual(expectedStatus, testCar.VehicleStatus);
            testCar.FixBrakes();
            testCar.FixEngineCoolantLevel();
            testCar.UpdateVehicleStatus();
            expectedStatus = "OK";
            Assert.AreEqual(expectedStatus, testCar.VehicleStatus);
        }


    }
}