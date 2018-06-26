using AutoGestion.Vehicles.Entities;
using static AutoGestion.Utils.VehicleEnums;

namespace AutoGestion.Vehicles.Builder
{
    public class TruckBuilder : ITruckBuilder
    {
        private readonly Truck _truck;

        public TruckBuilder()
        {
            _truck = new Truck();
        }

        public Vehicle Build()
        {
            return _truck;
        }

        public ITruckBuilder WithBrand(Brands brand)
        {
            _truck.Brand = brand;

            return this;
        }

        public ITruckBuilder WithColor(Colors color)
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
            _truck.Freight = freight;

            return this;
        }
    }
}
