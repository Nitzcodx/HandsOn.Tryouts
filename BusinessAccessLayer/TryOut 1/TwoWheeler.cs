using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.TryOut_1
{
    public class TwoWheeler:Vehicle
    {
        private short chainTension;

        public short ChainTension {
            get
            {
                return chainTension;
            }
            set
            {
                if (value >= 1 && value <= 9) chainTension = value;
                else chainTension = 7;
            }
        }

        public TwoWheeler()
        {

        }
        public TwoWheeler(bool areBrakesWorking,float fuelLevel,short chainTension):base(areBrakesWorking,fuelLevel)
        {
            ChainTension = chainTension;
        }
        public bool FixChainTension()
        {
            if (ChainTension != 7)
            {
                ChainTension = 7;
                return true;
            }
            return false;
        }

        public override void RefuelVehicle(float fuelVolume)
        {
            try
            {
                if (FuelLevel + fuelVolume > 10)
                    throw new Exceptions.FuelOverflowException();
                else
                    FuelLevel += fuelVolume;

            }
            catch(Exceptions.FuelOverflowException)
            {
                throw;
            }
        }

        public override void UpdateVehicleStatus()
        {
            if (ChainTension > 9 || !(AreBrakesWorking)) VehicleStatus = "Critical";
            else VehicleStatus = "OK";
        }
    }
}