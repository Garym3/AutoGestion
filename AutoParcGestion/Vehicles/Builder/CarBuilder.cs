using AutoGestion.Vehicles.State;

namespace AutoGestion.Vehicles.Builder
{
    public class CarBuilder : ICarBuilder
    {
        private readonly Vehicle _car;

        public CarBuilder()
        {
            _car = new Car();
        }

        public Vehicle Build()
        {
            return _car;
        }

        public ICarBuilder WithBrand(string brand)
        {
            _car.Brand = brand;

            return this;
        }

        public ICarBuilder WithColor(string color)
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
