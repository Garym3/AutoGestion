using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoGestion.Vehicles;

namespace AutoGestion.Garage.Observer
{
    public abstract class Observable
    {
        protected readonly List<IObserver> Observers = new List<IObserver>();

        /// <summary>
        /// Attach an observer
        /// </summary>
        /// <param name="observer"></param>
        public void Attach(IObserver observer)
        {
            Observers.Add(observer);
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
        public void Notify(Vehicle vehicle)
        {
            foreach (IObserver observer in Observers)
            {
                observer.Notify(vehicle);
            }
        }
    }
}
