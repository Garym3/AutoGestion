using AutoGestion.Entities;
using AutoGestion.Utils;

namespace AutoGestion.Vehicles
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
