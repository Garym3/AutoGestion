using System;
using System.Collections.Generic;
using AutoGestion.Utils;
using AutoGestion.Vehicles.Entities;

namespace AutoGestion.Vehicles.Builder
{
    public class CarBuilderDirector
    {
        private ICarBuilder _carBuilder;
        private readonly Random _randomizer = new Random();
        private readonly VehicleEnums _vehicleEnums = new VehicleEnums();

        public CarBuilderDirector()
        {
            _carBuilder = new CarBuilder();
        }

        public CarBuilderDirector(ICarBuilder carBuilder)
        {
            _carBuilder = carBuilder;
        }

        public Vehicle Build(VehicleEnums.Brands brand, VehicleEnums.Colors color, int engineCapacity, int numberOfDoors, int numberOfSeats)
        {
            _carBuilder = new CarBuilder();

            return _carBuilder
                .WithBrand(brand)
                .WithColor(color)
                .WithEngineCapacity(engineCapacity)
                .WithDoors(numberOfDoors)
                .WithSeats(numberOfSeats)
                .Build();
        }

        public Vehicle Build()
        {
            var randomBrand = _vehicleEnums.GetRandomBrandValue();
            var randomColor = _vehicleEnums.GetRandomColorValue();
            _carBuilder = new CarBuilder();

            return _carBuilder
                .WithBrand(randomBrand)
                .WithColor(randomColor)
                .WithEngineCapacity(_randomizer.Next(1500, 3000))
                .WithDoors(_randomizer.Next(3, 5))
                .WithSeats(_randomizer.Next(2, 6))
                .Build();
        }

        public IEnumerable<Vehicle> Build(int count, VehicleEnums.Brands brand, VehicleEnums.Colors color, int engineCapacity, int numberOfDoors, int numberOfSeats)
        {
            for (int i = 0; i < count; i++)
            {
                _carBuilder = new CarBuilder();

                yield return _carBuilder
                    .WithBrand(brand)
                    .WithColor(color)
                    .WithEngineCapacity(engineCapacity)
                    .WithDoors(numberOfDoors)
                    .WithSeats(numberOfSeats)
                    .Build();
            }
        }

        public IEnumerable<Vehicle> Build(int count)
        {
            var randomBrand = _vehicleEnums.GetRandomBrandValue();
            var randomColor = _vehicleEnums.GetRandomColorValue();
            
            for (int i = 0; i < count; i++)
            {
                _carBuilder = new CarBuilder();

                yield return _carBuilder
                    .WithBrand(randomBrand)
                    .WithColor(randomColor)
                    .WithEngineCapacity(_randomizer.Next(1500, 3000))
                    .WithDoors(_randomizer.Next(3, 5))
                    .WithSeats(_randomizer.Next(2, 6))
                    .Build();
            }
        }
    }
}
