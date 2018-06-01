using AutoGestion.Vehicles.State;

namespace AutoGestion.Vehicles
{
    public abstract class Vehicle
    {
        public string Brand;

        public string Color;

        public int EngineCapacity;

        public bool EngineState;

        public double TankFuel;

        public int NumberOfDoors;

        public int NumberOfSeats;

        public TransfertState TransfertState = new Available();

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
    }
}
