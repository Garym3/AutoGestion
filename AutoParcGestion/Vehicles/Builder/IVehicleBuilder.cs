using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoGestion.Utils;
using AutoGestion.Vehicles.Entities;

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
