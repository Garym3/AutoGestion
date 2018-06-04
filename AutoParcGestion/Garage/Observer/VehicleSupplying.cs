using System;
using AutoGestion.Vehicles.Template;
using AutoGestion.Vehicles.Utils;

namespace AutoGestion.Garage.Observer
{
    public class VehicleSupplying : IObserver
    {
        public void Notify(Vehicle vehicle, GarageEnums.Events garageEvent)
        {
            switch (garageEvent)
            {
                case GarageEnums.Events.AddVehicle:
                    Console.WriteLine($"A new {vehicle.GetType().Name.ToLower()} has been added to the parc.");
                    break;
                case GarageEnums.Events.RemoveVehicle:
                    Console.WriteLine($"A {vehicle.GetType().Name.ToLower()} has been removed from the parc.");
                    break;
                case GarageEnums.Events.Nothing:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(garageEvent), garageEvent, null);
            }
        }
    }
}
