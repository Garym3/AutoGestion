using System;
using System.Collections.Generic;
using System.Linq;
using AutoGestion.Prices;
using AutoGestion.TransferState.States;

namespace AutoGestion.Entities
{
    public class Park : IBalance
    {
        public List<Vehicle> OwnedVehicles { get; } = new List<Vehicle>();

        private PricerProxy PricerProxy { get; } = new PricerProxy();

        public double Balance { get; private set; }

        public Provider OfficialProvider { get; }


        public Park()
        {
            Balance = new Random().Next(500000, 1000000);
            OfficialProvider = new Provider(Balance);
        }

        public void OrderVehicle(Type vehicleType)
        {
            var orderedVehicle = OfficialProvider.BuyVehicle(vehicleType);

            orderedVehicle.TransfertState.Update();

            PricerProxy.ComputeTaxe(orderedVehicle.Price, orderedVehicle.GetTvaTax());

            OwnedVehicles.Add(orderedVehicle);
        }

        public void OrderAllVehicles(Type vehicleType)
        {
            var orderedVehicles = OfficialProvider.BuyAllVehicles(vehicleType).ToList();

            foreach (Vehicle orderedVehicle in orderedVehicles)
            {
                orderedVehicle.TransfertState.Update();

                Balance -= orderedVehicle.Price;
            }

            OwnedVehicles.AddRange(orderedVehicles);
        }

        public void SellVehicle(Type vehicleType)
        {
            if (vehicleType == null) return;

            Vehicle vehicleToRemove = OwnedVehicles.First(v => v.GetType() == vehicleType && v.TransfertState.State is Stored);

            OwnedVehicles.Remove(vehicleToRemove);

            Balance += vehicleToRemove.Price;
        }

        public void SellAllVehicles(Type vehicleType)
        {
            if (OwnedVehicles == null || OwnedVehicles.Count <= 0) return;

            var vehiclesToSell = OwnedVehicles.Where(v => v.GetType() == vehicleType && v.TransfertState.State is Stored).ToList();

            foreach (Vehicle vehicleToSell in vehiclesToSell)
            {
                OwnedVehicles.Remove(vehicleToSell);

                Balance += vehicleToSell.Price;
            }
        }
    }
}
