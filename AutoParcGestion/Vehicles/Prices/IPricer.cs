using AutoGestion.Entities;

namespace AutoGestion.Vehicles.Prices
{
    public interface IPricer
    {
        double SetPrice(Vehicle vehicle, double price);
        double ComputeTaxe(double basePrice, double taxeValue);
    }
}
