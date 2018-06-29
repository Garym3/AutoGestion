using System;
using System.Linq;
using AutoGestion.Entities;
using AutoGestion.PaymentObserver;
using AutoGestion.Prices;
using AutoGestion.Utils;
using AutoGestion.Vehicles.Builder;
using static AutoGestion.Utils.VehicleEnums;

namespace AutoGestion
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            // Un parc automobile contient de 0 à plusieurs véhicules. Un véhicule peut-être un camion, une voiture.
            var park = new Park();

            // Notifications lors de l'ajout ou de la suppression de véhicules
            park.Attach(paymentOperation, GarageEnums.Events.AddVehicle);
            park.Attach(paymentOperation, GarageEnums.Events.RemoveVehicle);

            // On prépare les prix des véhicules
            var priceProxy = new PricerProxy();

            // Plusieurs lots de véhicules sont disponibles à la vente
            var carBuilderDirector = new CarBuilderDirector();
            var truckBuilderDirector = new TruckBuilderDirector();
            var cars = carBuilderDirector.Build(3, Brands.Renault, Colors.Black, 2000, 4, 5).ToList();
            cars.AddRange(carBuilderDirector.Build(6, Brands.Tata, Colors.Red, 1500, 4, 5));
            var trucks = truckBuilderDirector.Build(3, Brands.Peugeot, Colors.White, 8000, 2, 3, 7000);

            var vehicles = cars.Concat(trucks).ToList();

            // Le parc automobile réserve des véhicules
            park.UpdateVehiclesTransfertState(vehicles);

            Console.WriteLine();

            park.GetOwnedVehicles().ForEach(v => v.PrintVehicleCharacteristics());

            Console.WriteLine(Environment.NewLine + "How much do they cost?" + Environment.NewLine);

            park.GetOwnedVehicles().ForEach(v =>
            {
                priceProxy.SetPrice(v, priceProxy.ComputeTaxe(v.Price, 1.2));
                Console.WriteLine($"{v.Brand} | {v.GetType().Name} | Pricer: {v.Price}");
            });

            Console.WriteLine(Environment.NewLine + "Ordering these vehicles...");

            // Mise à jour du statut de transfert, selon un schéma précis, de chaque véhicule réservé par le parc
            park.GetOwnedVehicles().ForEach(v => v.UpdateTransfertState());

            Console.WriteLine(Environment.NewLine + "Done!" + Environment.NewLine);

            park.GetOwnedVehicles().ForEach(v => v.PrintVehicleCharacteristics());

            Console.WriteLine();

            // On supprime les véhicules du parc automobile pour déclencher les listeners
            park.SellVehicles(typeof(TruckBuilder), park.GetOwnedVehicles().Count);

            Console.ReadLine();
        }
    }
}
