using System.Collections.Generic;
using AutoGestion.Providers.TransferState.States;
using AutoGestion.Vehicles.Entities;

namespace AutoGestion.Providers.Entities
{
    public class Provider
    {
        private readonly List<Vehicle> _orderedVehicles = new List<Vehicle>();

        public List<Vehicle> UpdateVehiclesTransferState()
        {
            if (_orderedVehicles == null || _orderedVehicles.Count <= 0) return null;

            foreach (Vehicle vehicle in _orderedVehicles)
            {
                vehicle.TransfertState.Update();
            }

            return _orderedVehicles;
        }

        public void OrderVehicles(List<Vehicle> vehicles)
        {
            if (vehicles == null || vehicles.Count <= 0) return;

            if (!vehicles.TrueForAll(v => v.TransfertState.State is Available)) return;

            vehicles.ForEach(v => v.TransfertState.Update());
        }
    }
}
