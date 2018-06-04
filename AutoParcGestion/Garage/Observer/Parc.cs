using System;
using System.Collections.Generic;
using AutoGestion.Vehicles;

namespace AutoGestion.Garage.Observer
{
    public class Parc
    {
        private readonly List<Vehicle> _storedVehicles;

        public Parc(List<Vehicle> vehicles)
        {
            _storedVehicles = vehicles;
        }

        public void AddVehicle(Vehicle vehicle)
        {
            _storedVehicles.Add(vehicle);
        }

        public void AddVehicles(IEnumerable<Vehicle> vehicles)
        {
            _storedVehicles.AddRange(vehicles);
        }

        public void RemoveVehicle(Vehicle vehicle)
        {
            _storedVehicles.Remove(vehicle);
        }

        public void RemoveAllVehicles()
        {
            _storedVehicles.Clear();
        }

        public List<Vehicle> GetAllVehicles()
        {
            return _storedVehicles;
        }

        public void Subscribe(Vehicle vehicle)
        {
            throw new System.NotImplementedException();
        }

        public void Unsubscribe(Vehicle vehicle)
        {
            throw new System.NotImplementedException();
        }

        public void Notify()
        {
            throw new System.NotImplementedException();
        }
    }
}
