using AutoGestion.Vehicles.Template;
using AutoGestion.Vehicles.Utils;

namespace AutoGestion.Garage.Observer
{
    public interface IObserver
    {
        void Notify(Vehicle vehicle, GarageEnums.Events garageEvent);
    }
}
