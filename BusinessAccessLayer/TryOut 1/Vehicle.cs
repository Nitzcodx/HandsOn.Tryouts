using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessAccessLayer.Constants;

namespace BusinessAccessLayer.TryOut_1
{
    public delegate bool FixVehicle();
    public abstract class Vehicle
    {
        private float fuelLevel;

        public bool AreBrakesWorking { get; set; }
        public float FuelLevel 
        {
            get
            {
                return fuelLevel;
            }
            set
            {
                if(this is FourWheeler)
                {
                    fuelLevel = value > VehicleConstants.FourWheelerMaxFuelLevel ? VehicleConstants.FourWheelerMaxFuelLevel : value;
                }
                if(this is TwoWheeler)
                {
                    fuelLevel = value > VehicleConstants.TwoWheelerMaxFuelLevel ? VehicleConstants.TwoWheelerMaxFuelLevel : value;
                }
            }
        }
        public Enums.VehicleStatus VehicleStatus { get; set; }

        public Vehicle()
        {

        }
        public Vehicle(bool areBrakesWorking,float fuelLevel)
        {
            AreBrakesWorking = areBrakesWorking;
            FuelLevel = fuelLevel;
        }

        public bool FixBrakes()
        {
            if (!AreBrakesWorking)
            {
                AreBrakesWorking = true;
                return true;
            }
            return false;
        }
        public virtual void RefuelVehicle(float fuelVolume) { }
        public virtual void UpdateVehicleStatus() { }

    }
}
