using AutoGestion.Entities;

namespace AutoGestion.PaymentObserver
{
    public interface IPaymentOperation
    {
        void ProcessPayment(Observable observable);
    }
}
