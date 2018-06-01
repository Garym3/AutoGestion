namespace AutoGestion.Vehicles.Builder
{
    public interface ICarBuilder
    {
        Vehicle Build();

        ICarBuilder WithColor(string color);

        ICarBuilder WithEngineCapacity(int engineCapacity);

        ICarBuilder WithBrand(string brand);

        ICarBuilder WithDoors(int numberOfDoors);

        ICarBuilder WithSeats(int numberOfSeats);
    }
}
