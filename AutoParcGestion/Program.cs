using System;
using System.Linq;
using AutoGestion.Vehicles;
using AutoGestion.Vehicles.Builder;
using AutoGestion.Vehicles.Utils;

namespace AutoGestion
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var carBuilderDirector = new CarBuilderDirector();
            var truckBuilderDirector = new TruckBuilderDirector();
            var car = carBuilderDirector.Build(5, VehicleEnums.Brands.Renault, VehicleEnums.Colors.Black, 2000, 4, 5);
            var truck = truckBuilderDirector.Build(5, VehicleEnums.Brands.Peugeot, VehicleEnums.Colors.White, 8000, 2, 3, 7000);
            var vehicles = car.Concat(truck).OrderBy(x => x.GetType().Name);

            foreach (Vehicle vehicle in vehicles)
            {
                Console.Write($"Vehicle Type: {vehicle.GetType().Name}  | Transfert State: {vehicle.TransfertState} | Brand: {vehicle.Brand} | Color: {vehicle.Color}");

                var truckVehicle = vehicle as Truck;
                if (truckVehicle != null) Console.Write($" | Freight: {truckVehicle.Freight}");

                Console.WriteLine();
            }
            
            Console.ReadLine();
        }
    }
}
