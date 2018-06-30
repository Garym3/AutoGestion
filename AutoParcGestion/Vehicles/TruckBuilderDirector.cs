using System;
using System.Collections.Generic;
using AutoGestion.Entities;
using AutoGestion.Utils;

namespace AutoGestion.Vehicles
{
    public class TruckBuilderDirector
    {
        private ITruckBuilder _truckBuilder;
        private readonly Random _randomizer = new Random();
        private readonly VehicleEnums _vehicleEnums = new VehicleEnums();

        public TruckBuilderDirector()
        {
            _truckBuilder = new TruckBuilder();
        }

        public TruckBuilderDirector(ITruckBuilder truckBuilder)
        {
            _truckBuilder = truckBuilder;
        }

        /// <summary>
        /// Builds a truck with parameters set by the client
        /// </summary>
        /// <param name="brand">Trucks brand</param>
        /// <param name="color">Color of the trucks</param>
        /// <param name="engineCapacity">Engine capacity of the trucks</param>
        /// <param name="numberOfDoors">Number of doors of the trucks</param>
        /// <param name="numberOfSeats">Number of seats of the trucks</param>
        /// <param name="freight">Freight capacity of the trucks</param>
        /// <returns>The built trucks</returns>
        public Vehicle Build(VehicleEnums.Brands brand, VehicleEnums.Colors color, int engineCapacity, int numberOfDoors, int numberOfSeats, double freight)
        {
            _truckBuilder = new TruckBuilder();

            return _truckBuilder
                .WithBrand(brand)
                .WithColor(color)
                .WithEngineCapacity(engineCapacity)
                .WithDoors(numberOfDoors)
                .WithSeats(numberOfSeats)
                .WithFreight(freight)
                .Build();
        }

        /// <summary>
        /// Builds trucks with parameters set by the client
        /// </summary>
        /// <param name="count">Number of trucks to build</param>
        /// <param name="brand">Trucks brand</param>
        /// <param name="color">Color of the trucks</param>
        /// <param name="engineCapacity">Engine capacity of the trucks</param>
        /// <param name="numberOfDoors">Number of doors of the trucks</param>
        /// <param name="numberOfSeats">Number of seats of the trucks</param>
        /// <param name="freight">Freight capacity of the trucks</param>
        /// <returns>The built trucks</returns>
        public IEnumerable<Vehicle> Build(int count, VehicleEnums.Brands brand, VehicleEnums.Colors color, int engineCapacity, int numberOfDoors, int numberOfSeats, double freight)
        {
            for (int i = 0; i < count; i++)
            {
                _truckBuilder = new TruckBuilder();

                yield return _truckBuilder
                    .WithBrand(brand)
                    .WithColor(color)
                    .WithEngineCapacity(engineCapacity)
                    .WithDoors(numberOfDoors)
                    .WithSeats(numberOfSeats)
                    .WithFreight(freight)
                    .Build();
            }
        }

        /// <summary>
        /// Builds a randomized truck
        /// </summary>
        /// <returns>The built truck</returns>
        public Vehicle Build()
        {
            var randomBrand = _vehicleEnums.GetRandomBrandValue();
            var randomColor = _vehicleEnums.GetRandomColorValue();
            _truckBuilder = new TruckBuilder();

            return _truckBuilder
                .WithBrand(randomBrand)
                .WithColor(randomColor)
                .WithEngineCapacity(_randomizer.Next(1500, 3000))
                .WithDoors(_randomizer.Next(3, 5))
                .WithSeats(_randomizer.Next(2, 6))
                .WithFreight(_randomizer.Next(0, 1000))
                .Build();
        }

        /// <summary>
        /// Builds randomized trucks with a specific count
        /// </summary>
        /// <param name="count">Number of trucks to create</param>
        /// <returns>The built trucks</returns>
        public IEnumerable<Vehicle> Build(int count)
        {
            var randomBrand = _vehicleEnums.GetRandomBrandValue();
            var randomColor = _vehicleEnums.GetRandomColorValue();
            
            for (int i = 0; i < count; i++)
            {
                _truckBuilder = new TruckBuilder();

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
