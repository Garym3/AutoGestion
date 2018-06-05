using System.Collections.Generic;
using AutoGestion.Vehicles.Template;
using AutoGestion.Vehicles.Utils;

namespace AutoGestion.Garage.Observer
{
    public class Parc : Observable
    {
        private readonly List<Vehicle> _storedVehicles = new List<Vehicle>();

        public void AddVehicle(Vehicle vehicle)
        {
            _storedVehicles.Add(vehicle);
            Notify(vehicle, GarageEnums.Events.AddVehicle);
        }

        public void AddVehicles(List<Vehicle> vehicles)
        {
            vehicles.ForEach(v => Notify(v, GarageEnums.Events.AddVehicle));
            _storedVehicles.AddRange(vehicles);
        }

        public void RemoveVehicle(Vehicle vehicle)
        {
            _storedVehicles.Remove(vehicle);
            Notify(vehicle, GarageEnums.Events.RemoveVehicle);
        }

        public void RemoveAllVehicles()
        {
            _storedVehicles.ForEach(v => Notify(v, GarageEnums.Events.RemoveVehicle));
            _storedVehicles.Clear();
        }

        public List<Vehicle> GetStoredVehicles()
        {
            return _storedVehicles;
        }
    }
}
