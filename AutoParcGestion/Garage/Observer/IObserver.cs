using AutoGestion.Vehicles;

namespace AutoGestion.Garage.Observer
{
    public interface IObserver
    {
        void Notify(Vehicle vehicle);
    }
}
