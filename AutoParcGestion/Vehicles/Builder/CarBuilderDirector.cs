using System;
using System.Collections.Generic;
using AutoGestion.Vehicles.Utils;

namespace AutoGestion.Vehicles.Builder
{
    public class CarBuilderDirector
    {
        private readonly ICarBuilder _carBuilder;
        private readonly Random _randomizer = new Random();

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
            return _carBuilder
                .WithBrand(brand.ToString())
                .WithColor(color.ToString())
                .WithEngineCapacity(engineCapacity)
                .WithDoors(numberOfDoors)
                .WithSeats(numberOfSeats)
                .Build();
        }

        public Vehicle Build()
        {
            var randomBrand = VehicleEnums.GetRandomBrandValue().ToString();
            var randomColor = VehicleEnums.GetRandomColorValue().ToString();

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
                yield return _carBuilder
                    .WithBrand(brand.ToString())
                    .WithColor(color.ToString())
                    .WithEngineCapacity(engineCapacity)
                    .WithDoors(numberOfDoors)
                    .WithSeats(numberOfSeats)
                    .Build();
            }
        }

        public IEnumerable<Vehicle> Build(int count)
        {
            var randomBrand = VehicleEnums.GetRandomBrandValue().ToString();
            var randomColor = VehicleEnums.GetRandomColorValue().ToString();

            for (int i = 0; i < count; i++)
            {
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
