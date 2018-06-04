using AutoGestion.Vehicles.Template;

namespace AutoGestion.Vehicles.Proxy
{
    public interface IPrice
    {
        double SetPrice(Vehicle vehicle, double price);
        double ComputeTaxe(double basePrice, double taxeValue);
    }
}
