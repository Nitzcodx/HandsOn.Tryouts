using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessAccessLayer.Constants;
using BusinessAccessLayer.Enums;

namespace BusinessAccessLayer.TryOut_1
{
    public class FourWheeler:Vehicle
    {
        private char engineCoolantLevel;
        public char EngineCoolantLevel {
            get
            {
                return engineCoolantLevel;
            }
            set
            {
                if (
                    value.Equals(FourWheelerConstants.HighEngineCoolentLevel) ||
                    value.Equals(FourWheelerConstants.MediumEngineCoolentLevel) ||
                    value.Equals(FourWheelerConstants.LowEngineCoolentLevel)
                   )    engineCoolantLevel = value;
                else engineCoolantLevel = FourWheelerConstants.HighEngineCoolentLevel;
            }
        }
        public FourWheeler()
        {

        }
        public FourWheeler(bool areBrakesWorking,float fuelLevel, char engineCoolantLevel):base(areBrakesWorking,fuelLevel)
        {
            EngineCoolantLevel = engineCoolantLevel;
        }
        public bool FixEngineCoolantLevel()
        {
            if (!(EngineCoolantLevel.Equals(FourWheelerConstants.HighEngineCoolentLevel))){
                EngineCoolantLevel = FourWheelerConstants.HighEngineCoolentLevel;
                return true;
            }
            return false;
        }

        public override void RefuelVehicle(float fuelVolume)
        {
            try
            {
                if (FuelLevel + fuelVolume > VehicleConstants.FourWheelerMaxFuelLevel)
                    throw new Exceptions.FuelOverflowException();
                else FuelLevel += fuelVolume;
            }
            catch (Exceptions.FuelOverflowException ex)
            {
                Console.WriteLine(ex.Message);
                FuelLevel = 0;
            }
        }

        public override void UpdateVehicleStatus()
        {
            if (
                !(AreBrakesWorking) ||
                EngineCoolantLevel.Equals(FourWheelerConstants.LowEngineCoolentLevel)
               )    VehicleStatus = VehicleStatus.Critical;
            else VehicleStatus = VehicleStatus.OK;
        }
    }
}
