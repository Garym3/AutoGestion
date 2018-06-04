using System.Collections.Generic;
using AutoGestion.Vehicles.Template;
using AutoGestion.Vehicles.Utils;

namespace AutoGestion.Garage.Observer
{
    public abstract class Observable
    {
        protected readonly Dictionary<IObserver, GarageEnums.Events> Observers = new Dictionary<IObserver, GarageEnums.Events>();

        /// <summary>
        /// Attach an observer
        /// </summary>
        /// <param name="observer"></param>
        /// <param name="garageEvent"></param>
        public void Attach(IObserver observer, GarageEnums.Events garageEvent = GarageEnums.Events.Nothing)
        {
            Observers.Add(observer, garageEvent);
        }

        /// <summary>
        /// Detach an observer
        /// </summary>
        /// <param name="observer"></param>
        public void Detach(IObserver observer)
        {
            Observers.Remove(observer);
        }

        /// <summary>
        /// Notify an event to registered observers
        /// </summary>
        /// <param name="vehicle"></param>
        /// <param name="garageEvent"></param>
        public void Notify(Vehicle vehicle, GarageEnums.Events garageEvent)
        {
            foreach (IObserver observer in Observers.Keys)
            {
                if (Observers[observer] == garageEvent)
                {
                    observer.Notify(vehicle, garageEvent);
                }
            }
        }
    }
}
