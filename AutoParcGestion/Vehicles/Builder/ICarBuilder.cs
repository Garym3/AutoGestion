using static AutoGestion.Vehicles.Utils.VehicleEnums;

namespace AutoGestion.Vehicles.Builder
{
    public interface ICarBuilder
    {
        Vehicle Build();

        ICarBuilder WithBrand(Brands brand);

        ICarBuilder WithColor(Colors color);

        ICarBuilder WithEngineCapacity(int engineCapacity);

        ICarBuilder WithDoors(int numberOfDoors);

        ICarBuilder WithSeats(int numberOfSeats);
    }
}
