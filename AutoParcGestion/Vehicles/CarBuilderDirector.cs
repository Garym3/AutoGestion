using System;
using System.Collections.Generic;
using AutoGestion.Entities;
using AutoGestion.Utils;

namespace AutoGestion.Vehicles
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

        /// <summary>
        /// Builds a car with parameters set by the client
        /// </summary>
        /// <param name="brand">Car brand</param>
        /// <param name="color">Color of the car</param>
        /// <param name="engineCapacity">Engine capacity of the car</param>
        /// <param name="numberOfDoors">Number of doors of the car</param>
        /// <param name="numberOfSeats">Number of seats of the car</param>
        /// <returns>The built car</returns>
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

        /// <summary>
        /// Builds a car with randomized parameters
        /// </summary>
        /// <returns>The built car</returns>
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

        /// <summary>
        /// Builds cars with parameters set by the client
        /// </summary>
        /// <param name="count">Number of cars to build</param>
        /// <param name="brand">Cars brand</param>
        /// <param name="color">Color of the cars</param>
        /// <param name="engineCapacity">Engine capacity of the cars</param>
        /// <param name="numberOfDoors">Number of doors of the cars</param>
        /// <param name="numberOfSeats">Number of seats of the cars</param>
        /// <returns>The built cars</returns>
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

        /// <summary>
        /// Builds cars with randomized parameters
        /// </summary>
        /// <param name="count">Number of cars to build</param>
        /// <returns>The built cars</returns>
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
