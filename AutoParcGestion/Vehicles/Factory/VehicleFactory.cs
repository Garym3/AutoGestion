using System;

namespace AutoGestion.Vehicles.Factory
{
    [Obsolete("Ce pattern a été délaissé au profit du Builder.")]
    public static class VehicleFactory
    {
        public static Vehicle MakeVehicle<T>() where T : Vehicle, new()
        {
            return new T();
        }
    }
}
