using System.Collections.Generic;
using AutoGestion.Providers.Entities;
using AutoGestion.Providers.TransferState.States;
using AutoGestion.Vehicles.Entities;

namespace AutoGestion.Parks.Entities
{
    public class Parc
    {
        private readonly List<Vehicle> _ownedVehicles = new List<Vehicle>();
        private readonly Provider _provider = new Provider();

        public void OrderVehicle(Vehicle vehicle)
        {
            _ownedVehicles.Add(vehicle);
        }

        public void OrderVehicles(List<Vehicle> vehicles)
        {
            if (vehicles == null || vehicles.Count <= 0) return;

            foreach (Vehicle vehicle in vehicles)
            {
                OrderVehicle(vehicle);
            }
        }

        public void SellVehicle(Vehicle vehicle)
        {
            if (vehicle == null) return;

            _ownedVehicles.Remove(vehicle);
        }

        public void SellVehicles(List<Vehicle> vehicles)
        {
            if (vehicles == null || vehicles.Count <= 0) return;

            if (!_ownedVehicles.TrueForAll(vehicles.Contains)) return;

            foreach (Vehicle vehicle in vehicles)
            {
                SellVehicle(vehicle);
            }
        }

        public List<Vehicle> GetOwnedVehicles() => _ownedVehicles;
    }
}
