using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                if (value.Equals('H') || value.Equals('M') || value.Equals('L')) engineCoolantLevel = value;
                else engineCoolantLevel = 'H';
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
            if (!(EngineCoolantLevel.Equals('H'))){
                EngineCoolantLevel = 'H';
                return true;
            }
            return false;
        }

        public override void RefuelVehicle(float fuelVolume)
        {
            try
            {
                if (FuelLevel + fuelVolume > 50)
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
            if (!(AreBrakesWorking) || EngineCoolantLevel.Equals('L')) VehicleStatus = "Critical";
            else VehicleStatus = "OK";
        }
    }
}
