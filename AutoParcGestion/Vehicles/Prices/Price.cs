using AutoGestion.Vehicles.Entities;

namespace AutoGestion.Vehicles.Prices
{
    public class Price : IPrice
    {
        public double SetPrice(Vehicle vehicle, double price)
        {
            return vehicle.Price = price;
        }

        public double ComputeTaxe(double basePrice, double taxeValue)
        {
            return basePrice * taxeValue;
        }
    }
}
