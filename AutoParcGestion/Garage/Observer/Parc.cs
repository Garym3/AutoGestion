using System.Collections.Generic;
using AutoGestion.Vehicles.Template;
using AutoGestion.Vehicles.Utils;

namespace AutoGestion.Garage.Observer
{
    public class Parc : Observable
    {
        public readonly List<Vehicle> StoredVehicles = new List<Vehicle>();

        public void AddVehicle(Vehicle vehicle)
        {
            StoredVehicles.Add(vehicle);
            Notify(vehicle, GarageEnums.Events.AddVehicle);
        }

        public void AddVehicles(List<Vehicle> vehicles)
        {
            vehicles.ForEach(v => Notify(v, GarageEnums.Events.AddVehicle));
            StoredVehicles.AddRange(vehicles);
        }

        public void RemoveVehicle(Vehicle vehicle)
        {
            StoredVehicles.Remove(vehicle);
            Notify(vehicle, GarageEnums.Events.RemoveVehicle);
        }

        public void RemoveAllVehicles()
        {
            StoredVehicles.ForEach(v => Notify(v, GarageEnums.Events.RemoveVehicle));
            StoredVehicles.Clear();
        }
    }
}
