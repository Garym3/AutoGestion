using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoGestion.Vehicles.Template;
using AutoGestion.Vehicles.Utils;

namespace AutoGestion.Vehicles.Builder
{
    public interface IVehicleBuilder<out TIVehicleBuilder>
    {
        Vehicle Build();

        TIVehicleBuilder WithBrand(VehicleEnums.Brands brand);

        TIVehicleBuilder WithColor(VehicleEnums.Colors color);

        TIVehicleBuilder WithEngineCapacity(int engineCapacity);

        TIVehicleBuilder WithDoors(int numberOfDoors);

        TIVehicleBuilder WithSeats(int numberOfSeats);
    }
}
