using AutoGestion.Vehicles.Entities;

namespace AutoGestion.Vehicles.Prices
{
    public interface IPrice
    {
        double SetPrice(Vehicle vehicle, double price);
        double ComputeTaxe(double basePrice, double taxeValue);
    }
}
