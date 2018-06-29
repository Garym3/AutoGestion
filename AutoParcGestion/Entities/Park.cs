﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoGestion.Providers.TransferState.States;
using AutoGestion.Vehicles.Prices;

namespace AutoGestion.Entities
{
    public class Park : IBalance
    {
        public List<Vehicle> OwnedVehicles { get; set; } = new List<Vehicle>();

        public Provider Provider { get; set; }

        public double Balance { get; } = 120000.0;

        public Park(Provider provider)
        {
            Provider = provider;
        }

        public void OrderVehicle(Vehicle vehicle)
        {
            OwnedVehicles.Add(vehicle);
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

            OwnedVehicles.Remove(vehicle);
        }

        public void SellVehicles(Type vehicleType, int count)
        {
            if (OwnedVehicles == null || OwnedVehicles.Count <= 0) return;

            var filteredVehicles = OwnedVehicles.Where(v => v.GetType() == vehicleType && v.TransfertState.State is Stored).ToList();

            int filteredVehiclesCount = filteredVehicles.Count;

            if (filteredVehicles.Count <= count)
            {
                OwnedVehicles.Clear();
                return;
            }

            filteredVehicles.RemoveRange(0, count);
        }
    }
}
