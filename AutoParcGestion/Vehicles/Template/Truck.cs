using System;

namespace AutoGestion.Vehicles.Template
{
    public class Truck : Vehicle
    {
        public double Freight { get; set; }

        public void LoadFreight(double freight)
        {
            Freight += freight;
        }

        public void UnloadFreight(double freight)
        {
            if (Freight - freight <= 0) Freight = 0;
            Freight -= freight;
        }

        public override void Print()
        {
            Console.WriteLine($"Type: {GetType().Name}  | Transfert State: {TransfertState} | Brand: {Brand} | Color: {Color} | " +
                          $"Engine Capacity: {EngineCapacity} | Doors: {NumberOfDoors} | Seats: {NumberOfSeats} | Engine State: {EngineState} | " +
                          $"Freight: {Freight}");
        }
    }
}
