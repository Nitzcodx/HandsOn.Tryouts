using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessAccessLayer.Constants;
using BusinessAccessLayer.Enums;

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
                if (
                    value >= TwoWheelerConstants.MinChainTension &&
                    value <= TwoWheelerConstants.MinChainTension
                   )    chainTension = value;
                else chainTension = TwoWheelerConstants.OptimumChainTension;
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
            if (ChainTension != TwoWheelerConstants.OptimumChainTension)
            {
                ChainTension = TwoWheelerConstants.OptimumChainTension;
                return true;
            }
            return false;
        }

        public override void RefuelVehicle(float fuelVolume)
        {
            try
            {
                if (FuelLevel + fuelVolume > VehicleConstants.TwoWheelerMaxFuelLevel)
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
            if (
                ChainTension > TwoWheelerConstants.MaxChainTension ||
                !(AreBrakesWorking)
               )    VehicleStatus = VehicleStatus.Critical;
            else VehicleStatus = VehicleStatus.OK;
        }
    }
}