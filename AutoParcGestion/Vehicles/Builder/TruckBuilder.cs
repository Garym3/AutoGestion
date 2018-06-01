namespace AutoGestion.Vehicles.Builder
{
    public class TruckBuilder : ITruckBuilder
    {
        private readonly Vehicle _truck;

        public TruckBuilder()
        {
            _truck = new Truck();
        }

        public Vehicle Build()
        {
            return _truck;
        }

        public ITruckBuilder WithBrand(string brand)
        {
            _truck.Brand = brand;

            return this;
        }

        public ITruckBuilder WithColor(string color)
        {
            _truck.Color = color;

            return this;
        }

        public ITruckBuilder WithEngineCapacity(int engineCapacity)
        {
            _truck.EngineCapacity = engineCapacity;

            return this;
        }

        public ITruckBuilder WithDoors(int numberOfDoors)
        {
            _truck.NumberOfDoors = numberOfDoors;

            return this;
        }

        public ITruckBuilder WithSeats(int numberOfSeats)
        {
            _truck.NumberOfSeats = numberOfSeats;

            return this;
        }

        public ITruckBuilder WithFreight(double freight)
        {
            ((ITruck)_truck).Freight = freight;

            return this;
        }
    }
}
