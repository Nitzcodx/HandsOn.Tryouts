using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessAccessLayer.TryOut_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessAccessLayer.Enums;

namespace BusinessAccessLayer.TryOut_1.Tests
{
    [TestClass()]
    public class TwoWheelerTests
    {
        TwoWheeler testBike = new TwoWheeler(false, 6, 8);
        [TestMethod()]
        public void TwoWheelerTest()
        {
            short expectedChainTension = 8;
            Assert.AreEqual(expectedChainTension, testBike.ChainTension);
            testBike.ChainTension = 10;
            expectedChainTension = 7;
            Assert.AreEqual(expectedChainTension, testBike.ChainTension);
        }

        [TestMethod()]
        public void FixChainTensionTest()
        {
            Assert.IsTrue(testBike.FixChainTension());
            testBike.ChainTension = 7;
            Assert.IsFalse(testBike.FixChainTension());
        }

        [TestMethod()]
        public void RefuelVehicleTest()
        {
            try
            {
                testBike.RefuelVehicle(5);
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
            testBike.RefuelVehicle(4);
            float expectedFuelLevel = 10;
            Assert.AreEqual(expectedFuelLevel, testBike.FuelLevel);
        }

        [TestMethod()]
        public void UpdateVehicleStatusTest()
        {
            VehicleStatus expectedStatus = VehicleStatus.Critical;
            testBike.UpdateVehicleStatus();
            Assert.AreEqual(expectedStatus, testBike.VehicleStatus);
            testBike.FixBrakes();
            testBike.UpdateVehicleStatus();
            expectedStatus = VehicleStatus.OK;
            Assert.AreEqual(expectedStatus, testBike.VehicleStatus);
        }

       
    }
}