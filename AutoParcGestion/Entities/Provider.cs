using System;
using System.Collections.Generic;
using System.Linq;
using AutoGestion.Prices;
using AutoGestion.TransferState.States;
using AutoGestion.Utils;
using AutoGestion.Vehicles;

namespace AutoGestion.Entities
{
    public class Provider : IBalance
    {
        private PricerProxy PricerProxy { get; } = new PricerProxy();

        public List<Vehicle> AvailableVehicles { get; set; } = new List<Vehicle>();

        public List<Vehicle> OrderedVehicles { get; } = new List<Vehicle>();

        public double Balance { get; private set; } = 152000.0;

        public double ParkBalance { get; private set; }


        public Provider(double parkBalance)
        {
            ParkBalance = parkBalance;

            RenewStock();
        }

        public Vehicle BuyVehicle(Type vehicleType)
        {
            PrepareVehicle(vehicleType);
            RouteVehicle(vehicleType);
            DeliverVehicle(vehicleType);

            var boughtVehicle = OrderedVehicles.First();

            OrderedVehicles.Clear();

            return boughtVehicle;
        }

        public IEnumerable<Vehicle> BuyAllVehicles(Type vehicleType)
        {
            PrepareVehicles(vehicleType);
            RouteVehicles(vehicleType);
            DeliverVehicles(vehicleType);

            var boughtVehicles = OrderedVehicles.ToList();

            OrderedVehicles.Clear();

            return boughtVehicles;
        }

        private void PrepareVehicle(Type vehicleType)
        {
            if (AvailableVehicles == null || AvailableVehicles.Count <= 0) return;

            var orderedVehicle = AvailableVehicles.First(v =>
                vehicleType == v.GetType() && v.TransfertState.State is Available);

            orderedVehicle.TransfertState.Update();

            OrderedVehicles.Add(orderedVehicle);
        }

        private void PrepareVehicles(Type vehicleType)
        {
            if (AvailableVehicles == null || AvailableVehicles.Count <= 0) return;

            var orderedVehicle = AvailableVehicles.Where(v =>
                vehicleType == v.GetType() && v.TransfertState.State is Available).ToList();

            orderedVehicle.ForEach(v => v.TransfertState.Update());

            OrderedVehicles.AddRange(orderedVehicle);
        }

        private void RouteVehicle(Type vehicleType)
        {
            if (OrderedVehicles == null || OrderedVehicles.Count <= 0) return;

            OrderedVehicles.First(v => vehicleType == v.GetType() && v.TransfertState.State is Ordered).TransfertState.Update();
        }

        private void RouteVehicles(Type vehicleType)
        {
            if (OrderedVehicles == null || OrderedVehicles.Count <= 0) return;

            OrderedVehicles.Where(v => vehicleType == v.GetType() && v.TransfertState.State is Ordered).ToList().ForEach(v => v.TransfertState.Update());
        }

        private void DeliverVehicle(Type vehicleType)
        {
            if (OrderedVehicles == null || OrderedVehicles.Count <= 0) return;

            OrderedVehicles.First(v => vehicleType == v.GetType() && v.TransfertState.State is OnTheWay).TransfertState.Update();

            ProcessToPayment(vehicleType);
        }

        private void DeliverVehicles(Type vehicleType)
        {
            if (OrderedVehicles == null || OrderedVehicles.Count <= 0) return;

            OrderedVehicles.Where(v => vehicleType == v.GetType() && v.TransfertState.State is OnTheWay).ToList().ForEach(v => v.TransfertState.Update());

            OrderedVehicles.ForEach(v => v.TransfertState.Update());

            ProcessToPayment(vehicleType);
        }

        private void ProcessToPayment(Type vehicleType)
        {
            double totalPrice = GetVehiclesPrice(vehicleType);

            CashPaiement(totalPrice);
        }

        private void CashPaiement(double totalPrice)
        {
            Balance += totalPrice;

            ParkBalance -= totalPrice;
        }

        private double GetVehiclesPrice(Type vehicleType)
        {
            double totalPrice = 0.0;

            foreach (Vehicle vehicle in OrderedVehicles)
            {
                if (vehicle.GetType() != vehicleType) continue;

                totalPrice += PricerProxy.ComputeTaxe(vehicle.Price, vehicle.GetTvaTax());
            }

            return totalPrice;
        }

        private void RenewStock()
        {
            AvailableVehicles.AddRange(new CarBuilderDirector().Build(40, VehicleEnums.Brands.Renault, VehicleEnums.Colors.Black, 2000, 4, 5).ToList());

            AvailableVehicles.AddRange(new TruckBuilderDirector().Build(70, VehicleEnums.Brands.Peugeot, VehicleEnums.Colors.White, 8000, 2, 3, 7000).ToList());
        }
    }
}
