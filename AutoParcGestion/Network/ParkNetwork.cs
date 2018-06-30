using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoGestion.Entities;

namespace AutoGestion.Network
{
    public class ParkNetwork : Network
    {
        private readonly Dictionary<Park, List<Provider>> _collaborators = new Dictionary<Park, List<Provider>>();

        /// <summary>
        /// Adds a Park to the network
        /// </summary>
        /// <param name="park">A Park</param>
        public override void AddParkToNetwork(Park park)
        {
            if (!_collaborators.ContainsKey(park))
            {
                _collaborators.Add(park, new List<Provider>());
            }

            park.Network = this;
        }

        /// <summary>
        /// Adds a provider to the park network
        /// </summary>
        /// <param name="park">A Park</param>
        /// <param name="provider">A Provider</param>
        public override void AddProviderToNetwork(Park park, Provider provider)
        {
            if (_collaborators.ContainsKey(park))
            {
                _collaborators[park].Add(provider);
            }

            provider.Network = this;
        }

        public override void OrderVehicles(Provider from, Park to, Type vehicleType)
        {
            to.OwnedVehicles.AddRange(from.BuyAllVehicles(vehicleType));
        }

        public override void ProcessPayment(Park park, Provider provider, double amount)
        {
            park.SubtractFromBalance(amount);

            provider.AddToBalance(amount);
        }

        public override List<Vehicle> GetAvailableVehiclesFromProvider(Park park, Provider from)
        {
            return _collaborators[park].Contains(from) ? from.AvailableVehicles : null;
        }

        public override Provider GetAvailableProvider(Park park)
        {
            return _collaborators[park].Count == 0 ? null : _collaborators[park].FirstOrDefault(p => p.AvailableVehicles.Count > 0);
        }
    }
}
