using System;
using System.Collections.Generic;
using AutoGestion.Vehicles.Utils;

namespace AutoGestion.Vehicles.Builder
{
    public class TruckBuilderDirector
    {
        private readonly ITruckBuilder _truckBuilder;
        private readonly Random _randomizer = new Random();

        public TruckBuilderDirector()
        {
            _truckBuilder = new TruckBuilder();
        }

        public TruckBuilderDirector(ITruckBuilder truckBuilder)
        {
            _truckBuilder = truckBuilder;
        }

        public Vehicle Build(VehicleEnums.Brands brand, VehicleEnums.Colors color, int engineCapacity, int numberOfDoors, int numberOfSeats, double freight)
        {
            return _truckBuilder
                .WithBrand(brand.ToString())
                .WithColor(color.ToString())
                .WithEngineCapacity(engineCapacity)
                .WithDoors(numberOfDoors)
                .WithSeats(numberOfSeats)
                .WithFreight(freight)
                .Build();
        }

        public IEnumerable<Vehicle> Build(int count, VehicleEnums.Brands brand, VehicleEnums.Colors color, int engineCapacity, int numberOfDoors, int numberOfSeats, double freight)
        {
            for (int i = 0; i < count; i++)
            {
                yield return _truckBuilder
                    .WithBrand(brand.ToString())
                    .WithColor(color.ToString())
                    .WithEngineCapacity(engineCapacity)
                    .WithDoors(numberOfDoors)
                    .WithSeats(numberOfSeats)
                    .WithFreight(freight)
                    .Build();
            }
        }
        
        public Vehicle Build()
        {
            var randomBrand = VehicleEnums.GetRandomBrandValue().ToString();
            var randomColor = VehicleEnums.GetRandomColorValue().ToString();

            return _truckBuilder
                .WithBrand(randomBrand)
                .WithColor(randomColor)
                .WithEngineCapacity(_randomizer.Next(1500, 3000))
                .WithDoors(_randomizer.Next(3, 5))
                .WithSeats(_randomizer.Next(2, 6))
                .WithFreight(_randomizer.Next(0, 1000))
                .Build();
        }

        [Obsolete("Pas si Random que ça")]
        public IEnumerable<Vehicle> Build(int count)
        {
            var randomBrand = VehicleEnums.GetRandomBrandValue().ToString();
            var randomColor = VehicleEnums.GetRandomColorValue().ToString();

            for (int i = 0; i < count; i++)
            {
                yield return _truckBuilder
                    .WithBrand(randomBrand)
                    .WithColor(randomColor)
                    .WithEngineCapacity(_randomizer.Next(1500, 3000))
                    .WithDoors(_randomizer.Next(3, 5))
                    .WithSeats(_randomizer.Next(2, 6))
                    .WithFreight(_randomizer.Next(0, 1000))
                    .Build();
            }
        }
    }
}
