using System.Collections.Generic;
using AutoGestion.Entities;

namespace AutoGestion.PaymentObserver
{
    public abstract class Observable
    {
        protected readonly List<IPaymentOperation> Observers = new List<IPaymentOperation>();

        /// <summary>
        /// Attach a paymentOperation
        /// </summary>
        /// <param name="paymentOperation"></param>
        public void Attach(IPaymentOperation paymentOperation)
        {
            Observers.Add(paymentOperation);
        }

        /// <summary>
        /// Detach a paymentOperation
        /// </summary>
        /// <param name="paymentOperation"></param>
        public void Detach(IPaymentOperation paymentOperation)
        {
            Observers.Remove(paymentOperation);
        }

        /// <summary>
        /// ProcessPayment to registered observers
        /// </summary>
        /// <param name="park"></param>
        /// <param name="amount"></param>
        public void ProcessPayment()
        {
            foreach (var observer in Observers)
            {
                observer.ProcessPayment(this);
            }
        }
    }
}
