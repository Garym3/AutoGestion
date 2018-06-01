namespace AutoGestion.Vehicles.Builder
{
    public interface ITruckBuilder
    {
        Vehicle Build();

        ITruckBuilder WithColor(string color);

        ITruckBuilder WithEngineCapacity(int engineCapacity);

        ITruckBuilder WithBrand(string brand);

        ITruckBuilder WithDoors(int numberOfDoors);

        ITruckBuilder WithSeats(int numberOfSeats);
        
        ITruckBuilder WithFreight(double freight);
    }
}
