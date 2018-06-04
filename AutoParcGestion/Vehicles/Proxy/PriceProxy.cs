using AutoGestion.Vehicles.Template;

namespace AutoGestion.Vehicles.Proxy
{
    public class PriceProxy : IPrice
    {
        private readonly Price _price = new Price();

        public double SetPrice(Vehicle vehicle, double price)
        {
            return _price.SetPrice(vehicle, price);
        }

        public double ComputeTaxe(double basePrice, double taxeValue)
        {
            return _price.ComputeTaxe(basePrice, taxeValue);
        }
    }
}
