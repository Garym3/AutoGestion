using System;

namespace AutoGestion.Vehicles
{
    public class Truck : Vehicle, ITruck
    {
        public double Freight { get; set; }

        public void LoadFreight(double fret)
        {
            throw new NotImplementedException();
        }

        public void UnloadFreight(double fret)
        {
            throw new NotImplementedException();
        }
    }
}
