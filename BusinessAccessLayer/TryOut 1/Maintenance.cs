using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.TryOut_1
{
    public class Maintenance
    {
        public double MaintenanceCharges { get; set; }

        public Maintenance()
        {

        }
        public void RefuelVehicle(Vehicle vehicle,float volumeToBeFilled)
        {
            float initialVolume = vehicle.FuelLevel;
            vehicle.RefuelVehicle(volumeToBeFilled);
            if (initialVolume == vehicle.FuelLevel) volumeToBeFilled = 0;
            MaintenanceCharges += volumeToBeFilled * 70;
        }
        public void ServiceVehicle(Vehicle vehicle)
        {
            vehicle.UpdateVehicleStatus();
            if (vehicle.VehicleStatus.Equals("Critical"))
            {
                if (vehicle.FixBrakes()) MaintenanceCharges += 20.5;
                FixVehicle fix = null;
                if(vehicle is TwoWheeler)
                {
                     fix= new FixVehicle(((TwoWheeler)vehicle).FixChainTension);
                }
                if(vehicle is FourWheeler)
                {
                    fix = new FixVehicle(((FourWheeler)vehicle).FixEngineCoolantLevel);
                }
                if (fix())
                    MaintenanceCharges += (vehicle is TwoWheeler) ? 20.5 : 30.75;
                vehicle.VehicleStatus = "OK";
            }
        }
    }
}
