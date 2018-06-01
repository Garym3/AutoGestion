using System;
using System.Linq;

namespace AutoGestion.Vehicles.Utils
{
    public static class VehicleEnums
    {
        private static readonly Random Randomizer = new Random();

        public static Enum GetRandomBrandValue()
        {
            Array brands = Enum.GetValues(typeof(Brands));
            return (Brands)brands.GetValue(Randomizer.Next(1, brands.Length));
        }

        public static Enum GetRandomColorValue()
        {
            Array colors = Enum.GetValues(typeof(Colors));
            return (Colors)colors.GetValue(Randomizer.Next(1, colors.Length));
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
