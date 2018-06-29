using System.Collections.Generic;
using AutoGestion.PaymentObserver;
using AutoGestion.Prices;
using AutoGestion.Providers.TransferState.States;

namespace AutoGestion.Entities
{
    public class Provider : Observable, IBalance
    {
        public PricerProxy PricerProxy { get; } = new PricerProxy();

        public List<Vehicle> VehiclesToDeliver { get; } = new List<Vehicle>();

        public double Balance { get; set; } = 152000.0;


        public void DeliverVehicles(List<Vehicle> vehicles)
        {
            if (vehicles == null || vehicles.Count <= 0) return;

            if (!vehicles.TrueForAll(v => v.TransfertState.State is OnTheWay)) return;

            vehicles.ForEach(v => v.TransfertState.Update());
        }

        public void RouteVehicles(Park park)
        {
            if (VehiclesToDeliver == null || VehiclesToDeliver.Count <= 0) return;

            if (!VehiclesToDeliver.TrueForAll(v => v.TransfertState.State is Ordered)) return;

            VehiclesToDeliver.ForEach(v => v.TransfertState.Update());
        }

        public void DeliverVehicles()
        {
            if (VehiclesToDeliver == null || VehiclesToDeliver.Count <= 0) return;

            if (!VehiclesToDeliver.TrueForAll(v => v.TransfertState.State is OnTheWay)) return;

            VehiclesToDeliver.ForEach(v => v.TransfertState.Update());

            double totalPrice = GetVehiclesPrice();

            VehiclesToDeliver.Clear();

            CashPaiement(totalPrice);
        }

        private void CashPaiement(double totalPrice)
        {
            Balance += totalPrice;


        }

        private double GetVehiclesPrice()
        {
            double totalPrice = 0.0;

            foreach (Vehicle vehicle in VehiclesToDeliver)
            {
                totalPrice = PricerProxy.ComputeTaxe(vehicle.Price, 1.2);
            }

            return totalPrice;
        }
    }
}
