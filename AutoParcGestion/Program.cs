using System;
using System.Linq;
using AutoGestion.Vehicles.Builder;
using static AutoGestion.Vehicles.Utils.VehicleEnums;

namespace AutoGestion
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var carBuilderDirector = new CarBuilderDirector();
            var truckBuilderDirector = new TruckBuilderDirector();
            
            var car = carBuilderDirector.Build(3, Brands.Renault, Colors.Black, 2000, 4, 5);
            var truck = truckBuilderDirector.Build(3, Brands.Peugeot, Colors.White, 8000, 2, 3, 7000);

            var vehicles = car.Concat(truck).ToList();
            
            vehicles.ForEach(v => v.Print());

            Console.WriteLine(Environment.NewLine + "Updating vehicles' state..." + Environment.NewLine);

            vehicles.ForEach(v => v.UpdateTransfertState());

            Console.WriteLine(Environment.NewLine + "Done!" + Environment.NewLine);

            vehicles.ForEach(v => v.Print());

            Console.ReadLine();
        }
    }
}
