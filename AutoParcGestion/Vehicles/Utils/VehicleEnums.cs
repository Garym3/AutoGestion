using System;

namespace AutoGestion.Vehicles.Utils
{
    public class VehicleEnums
    {
        private readonly Random _randomizer = new Random();

        public Brands GetRandomBrandValue()
        {
            Array brands = Enum.GetValues(typeof(Brands));
            return (Brands)brands.GetValue(_randomizer.Next(1, brands.Length));
        }

        public Colors GetRandomColorValue()
        {
            Array colors = Enum.GetValues(typeof(Colors));
            return (Colors)colors.GetValue(_randomizer.Next(1, colors.Length));
        }

        public enum Brands
        {
            Peugeot,
            Citroen,
            Renault,
            BMW,
            Mercedes,
            Tata,
            Toyota,
            Ferrari
        }

        public enum Colors
        {
            White,
            Blue,
            Green,
            Red,
            Grey,
            Black,
            Yellow,
            Pink,
            Purple
        }
    }
}
