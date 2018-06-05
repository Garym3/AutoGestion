using System.Collections.Generic;
using AutoGestion.Vehicles.Template;
using AutoGestion.Vehicles.Utils;

namespace AutoGestion.Garage.Observer
{
    public abstract class Observable
    {
        protected readonly List<KeyValuePair<IObserver, GarageEnums.Events>> Observers = new List<KeyValuePair<IObserver, GarageEnums.Events>>();

        /// <summary>
        /// Attach an observer
        /// </summary>
        /// <param name="observer"></param>
        /// <param name="garageEvent"></param>
        public void Attach(IObserver observer, GarageEnums.Events garageEvent)
        {
            Observers.Add(new KeyValuePair<IObserver, GarageEnums.Events>(observer, garageEvent));
        }

        /// <summary>
        /// Detach an observer
        /// </summary>
        /// <param name="observer"></param>
        /// <param name="garageEvent"></param>
        public void Detach(IObserver observer, GarageEnums.Events garageEvent)
        {
            Observers.Remove(new KeyValuePair<IObserver, GarageEnums.Events>(observer, garageEvent));
        }

        /// <summary>
        /// Notify an event to registered observers
        /// </summary>
        /// <param name="vehicle"></param>
        /// <param name="garageEvent"></param>
        public void Notify(Vehicle vehicle, GarageEnums.Events garageEvent)
        {
            foreach (var observer in Observers)
            {
                if (observer.Value == garageEvent)
                {
                    observer.Key.Notify(vehicle, garageEvent);
                }
            }
        }
    }
}
