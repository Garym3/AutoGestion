using System.Collections.Generic;
using System.Linq;
using AutoGestion.Vehicles.State;
using AutoGestion.Vehicles.Template;
using AutoGestion.Vehicles.Utils;

namespace AutoGestion.Garage.Observer
{
    public class Parc : Observable
    {
        private readonly List<Vehicle> _storedVehicles = new List<Vehicle>();

        public void OrderVehicle(Vehicle vehicle)
        {
            _storedVehicles.Add(vehicle);
            Notify(vehicle, GarageEnums.Events.AddVehicle);
        }

        public void OrderVehicles(List<Vehicle> vehicles)
        {
            vehicles.ForEach(v => Notify(v, GarageEnums.Events.AddVehicle));
            _storedVehicles.AddRange(vehicles);
        }

        public void CancelVehicleOrder(Vehicle vehicle)
        {
            _storedVehicles.Remove(vehicle);
            Notify(vehicle, GarageEnums.Events.RemoveVehicle);
        }

        public void CancelVehiclesOrder()
        {
            _storedVehicles.ForEach(v => Notify(v, GarageEnums.Events.RemoveVehicle));
            _storedVehicles.Clear();
        }

        public List<Vehicle> GetStoredVehicles()
        {
            return _storedVehicles.Where(v => v.TransfertState.State is Arrived) as List<Vehicle>;
        }
    }
}
