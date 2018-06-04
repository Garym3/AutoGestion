using System;
using System.Linq;
using AutoGestion.Garage.Observer;
using AutoGestion.Vehicles.Builder;
using AutoGestion.Vehicles.Proxy;
using AutoGestion.Vehicles.Utils;
using static AutoGestion.Vehicles.Utils.VehicleEnums;

namespace AutoGestion
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            // Un parc automobile contient de 0 à plusieurs véhicules. Un véhicule peut-être un camion, une voiture, ou autre (Template).
            var parc = new Parc();

            // Pattern Observer avec application des listeners pour l'ajout et la suppression de véhicules
            parc.Attach(new VehicleSupplying(), GarageEnums.Events.AddVehicle);
            parc.Attach(new VehicleSupplying(), GarageEnums.Events.RemoveVehicle);

            // Pattern Builder avec des directeurs
            var carBuilderDirector = new CarBuilderDirector();
            var truckBuilderDirector = new TruckBuilderDirector();
            
            // On construit 3 véhicules identiques de chaque type...
            var car = carBuilderDirector.Build(3, Brands.Renault, Colors.Black, 2000, 4, 5);
            var truck = truckBuilderDirector.Build(3, Brands.Peugeot, Colors.White, 8000, 2, 3, 7000);

            var vehicles = car.Concat(truck).ToList();

            var priceProxy = new PriceProxy();

            // On ajoute les véhicules dans le parc automobile pour déclencher les listeners
            parc.AddVehicles(vehicles);

            Console.WriteLine();

            parc.StoredVehicles.ForEach(v => v.Print());

            Console.WriteLine(Environment.NewLine + "How much do they cost?" + Environment.NewLine);

            parc.StoredVehicles.ForEach(v =>
            {
                priceProxy.SetPrice(v, priceProxy.ComputeTaxe(v.Price, 1.2));
                Console.WriteLine($"{v.Brand} | {v.GetType().Name} | Price: {v.Price}");
            });

            Console.WriteLine(Environment.NewLine + "Ordering these vehicles...");

            // Pattern State pour mettre à jour le statut de transfert des véhicules selon un schéma précis
            parc.StoredVehicles.ForEach(v => v.UpdateTransfertState());

            Console.WriteLine(Environment.NewLine + "Done!" + Environment.NewLine);

            parc.StoredVehicles.ForEach(v => v.Print());

            Console.WriteLine();

            // On supprime les véhicules du parc automobile pour déclencher les listeners
            parc.RemoveAllVehicles();

            Console.ReadLine();
        }
    }
}
