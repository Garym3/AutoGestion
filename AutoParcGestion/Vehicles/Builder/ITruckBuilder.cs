using static AutoGestion.Vehicles.Utils.VehicleEnums;

namespace AutoGestion.Vehicles.Builder
{
    public interface ITruckBuilder
    {
        Vehicle Build();

        ITruckBuilder WithBrand(Brands brand);

        ITruckBuilder WithColor(Colors color);

        ITruckBuilder WithEngineCapacity(int engineCapacity);

        ITruckBuilder WithDoors(int numberOfDoors);

        ITruckBuilder WithSeats(int numberOfSeats);

        ITruckBuilder WithFreight(double freight);
    }
}
