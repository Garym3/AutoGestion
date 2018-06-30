using AutoGestion.Entities;
using AutoGestion.Utils;

namespace AutoGestion.Vehicles
{
    public class CarBuilder : ICarBuilder
    {
        private readonly Car _car;

        public CarBuilder()
        {
            _car = new Car();
        }

        public Vehicle Build()
        {
            return _car;
        }

        public ICarBuilder WithBrand(VehicleEnums.Brands brand)
        {
            _car.Brand = brand;

            return this;
        }

        public ICarBuilder WithColor(VehicleEnums.Colors color)
        {
            _car.Color = color;

            return this;
        }

        public ICarBuilder WithEngineCapacity(int engineCapacity)
        {
            _car.EngineCapacity = engineCapacity;

            return this;
        }

        public ICarBuilder WithDoors(int numberOfDoors)
        {
            _car.NumberOfDoors = numberOfDoors;

            return this;
        }

        public ICarBuilder WithSeats(int numberOfSeats)
        {
            _car.NumberOfSeats = numberOfSeats;

            return this;
        }
    }
}
