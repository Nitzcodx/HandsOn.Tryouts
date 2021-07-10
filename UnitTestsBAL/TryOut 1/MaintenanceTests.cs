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
    public class MaintenanceTests
    {
        Vehicle testBike = new TwoWheeler(false, 0, 10);
        Vehicle testCar = new FourWheeler(true, 0, 'L');
        Maintenance maintainBike = new Maintenance
        {
            MaintenanceCharges = 0
        };
        Maintenance maintainCar = new Maintenance
        {
            MaintenanceCharges = 0
        };

        [TestMethod()]
        public void RefuelVehicleTest()
        {
            maintainBike.RefuelVehicle(testBike, 10);
            float expectedCharge = 10 * 70;
            Assert.AreEqual(expectedCharge, maintainBike.MaintenanceCharges);
            maintainBike.RefuelVehicle(testBike, 0);
            Assert.AreEqual(expectedCharge, maintainBike.MaintenanceCharges);
            maintainCar.RefuelVehicle(testCar, 10);
            Assert.AreEqual(expectedCharge, maintainCar.MaintenanceCharges);
        }

        [TestMethod()]
        public void ServiceVehicleTest()
        {
            (testBike as TwoWheeler).ChainTension = 9;
            maintainBike.ServiceVehicle(testBike);
            float expectedCharge = (float)20.5 * 2;
            Assert.AreEqual(expectedCharge, maintainBike.MaintenanceCharges);
            maintainCar.ServiceVehicle(testCar);
            expectedCharge = (float)30.75;
            Assert.AreEqual(expectedCharge, maintainCar.MaintenanceCharges);
        }
    }
}