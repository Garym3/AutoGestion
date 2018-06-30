using AutoGestion.Entities;
using AutoGestion.Utils;

namespace AutoGestion.Vehicles
{
    /// <summary>
    /// Base builder for vehicles
    /// </summary>
    /// <typeparam name="TIVehicleBuilder">Base builder contract</typeparam>
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
