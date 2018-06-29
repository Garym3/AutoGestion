using AutoGestion.Entities;

namespace AutoGestion.Vehicles.Prices
{
    public class PricerProxy : IPricer
    {
        private readonly Pricer _pricer = new Pricer();

        public double SetPrice(Vehicle vehicle, double price)
        {
            return _pricer.SetPrice(vehicle, price);
        }

        public double ComputeTaxe(double basePrice, double taxeValue)
        {
            return _pricer.ComputeTaxe(basePrice, taxeValue);
        }
    }
}
