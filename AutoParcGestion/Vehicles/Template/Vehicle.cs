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
            if (TankFuel + fuel > 100.0) TankFuel = 100;
            TankFuel += fuel;
        }

        public virtual void ConsumeFuel(double fuel)
        {
            if (TankFuel - fuel < 0.0) TankFuel = 0;
            TankFuel -= fuel;
        }

        public virtual void EmptyTank()
        {
            if (TankFuel <= 0.0) return;
            TankFuel = 0.0;
        }

        public virtual void Print()
        {
            Console.WriteLine($"Type: {GetType().Name}  | Transfert State: {TransfertState} | Brand: {Brand} | Color: {Color} |" +
                          $" Engine Capacity: {EngineCapacity} | Doors: {NumberOfDoors} | Seats: {NumberOfSeats} | Engine State: {EngineState}");
        }

        public void UpdateTransfertState()
        {
            TransfertState.Update();
        }
    }
}
