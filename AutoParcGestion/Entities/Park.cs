using System;
using System.Collections.Generic;
using System.Linq;
using AutoGestion.Network;
using AutoGestion.Prices;
using AutoGestion.TransferState.States;

namespace AutoGestion.Entities
{
    public class Park : IBalance
    {
        public List<Vehicle> OwnedVehicles { get; } = new List<Vehicle>();

        private PricerProxy PricerProxy { get; } = new PricerProxy();

        public double Balance { get; private set; }

        public int ParkCapacity { get; }

        public int NumberOfVehicles => OwnedVehicles.Count;

        public ParkNetwork Network { get; set; }


        public Park()
        {
            Balance = new Random().Next(500000, 1000000);
            ParkCapacity = 5000;
        }

        public void OrderVehicle(Type vehicleType)
        {
            var availableProvider = Network.GetAvailableProvider(this);

            if (NumberOfVehicles + 1 > ParkCapacity) return;

            var orderedVehicle = availableProvider.BuyVehicle(vehicleType);

            orderedVehicle.TransfertState.Update();

            PricerProxy.ComputeTaxe(orderedVehicle.Price, orderedVehicle.GetTvaTax());

            OwnedVehicles.Add(orderedVehicle);
        }

        public void OrderAllVehicles(Type vehicleType)
        {
            var availableProvider = Network.GetAvailableProvider(this);

            if (NumberOfVehicles + availableProvider.AvailableVehicles.Count(v => v.GetType() == vehicleType) > ParkCapacity) return;

            var orderedVehicles = availableProvider.BuyAllVehicles(vehicleType).ToList();

            foreach (Vehicle orderedVehicle in orderedVehicles)
            {
                orderedVehicle.TransfertState.Update();

                Balance -= orderedVehicle.Price;
            }

            OwnedVehicles.AddRange(orderedVehicles);
        }

        public void SellVehicle(Type vehicleType)
        {
            if (vehicleType == null || NumberOfVehicles <= 0) return;

            Vehicle vehicleToRemove = OwnedVehicles.First(v => v.GetType() == vehicleType && v.TransfertState.State is Stored);

            OwnedVehicles.Remove(vehicleToRemove);

            Balance += vehicleToRemove.Price;
        }

        public void SellAllVehicles(Type vehicleType)
        {
            if (OwnedVehicles == null || NumberOfVehicles <= 0) return;

            var vehiclesToSell = OwnedVehicles.Where(v => v.GetType() == vehicleType && v.TransfertState.State is Stored).ToList();

            foreach (Vehicle vehicleToSell in vehiclesToSell)
            {
                OwnedVehicles.Remove(vehicleToSell);

                Balance += vehicleToSell.Price;
            }
        }

        public void AddToBalance(double amount) => Balance += amount;

        public void SubtractFromBalance(double amount) => Balance -= amount;
    }
}
