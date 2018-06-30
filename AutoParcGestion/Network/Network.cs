using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoGestion.Entities;

namespace AutoGestion.Network
{
    public abstract class Network
    {
        public abstract void AddParkToNetwork(Park park);

        public abstract void AddProviderToNetwork(Park park, Provider provider);

        public abstract void OrderVehicles(Provider from, Park to, Type vehicleType);

        public abstract void ProcessPayment(Park park, Provider provider, double amount);

        public abstract List<Vehicle> GetAvailableVehiclesFromProvider(Park park, Provider from);

        public abstract Provider GetAvailableProvider(Park park);
    }
}
