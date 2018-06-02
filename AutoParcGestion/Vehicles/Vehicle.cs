using System;
using AutoGestion.Vehicles.State;
using static AutoGestion.Vehicles.Utils.VehicleEnums;

namespace AutoGestion.Vehicles
{
    public abstract class Vehicle
    {
        public Brands Brand;

        public Colors Color;

        public int EngineCapacity;

        public bool EngineState;

        public double TankFuel;

        public int NumberOfDoors;

        public int NumberOfSeats;

        public readonly TransfertState TransfertState = new TransfertState();

        public virtual void StartEngine()
        {
            if (EngineState) return;
            EngineState = true;
        }

        public virtual void StopEngine()
        {
            if (!EngineState) return;
            EngineState = false;
        }

        public virtual void FillTank(double fuel)
        {
            if (TankFuel + fuel > 100.0) return;
            TankFuel += fuel;
        }

        public virtual void ConsumeFuel(double fuel)
        {
            if (TankFuel - fuel < 0.0) return;
            TankFuel -= fuel;
        }

        public virtual void EmptyTank()
        {
            if (TankFuel <= 0.0) return;
            TankFuel = 0.0;
        }

        public void UpdateTransfertState()
        {
            TransfertState.Update();
        }

        public void Print()
        {
            Console.Write($"Vehicle Type: {GetType().Name}  | Transfert State: {TransfertState} | Brand: {Brand} | Color: {Color} |" +
                          $" Engine Capacity: {EngineCapacity} | Doors: {NumberOfDoors} | Seats: {NumberOfSeats} | Engine State: {EngineState}");

            if (this is Truck truckVehicle) Console.Write($" | Freight: {truckVehicle.Freight}");

            Console.WriteLine();
        }
    }
}
