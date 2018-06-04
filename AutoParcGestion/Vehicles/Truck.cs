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

        public override void Print()
        {
            Console.Write($"Type: {GetType().Name}  | Transfert State: {TransfertState} | Brand: {Brand} | Color: {Color} |" +
                          $" Engine Capacity: {EngineCapacity} | Doors: {NumberOfDoors} | Seats: {NumberOfSeats} | Engine State: {EngineState} |" +
                          $" Freight: {Freight}");

            Console.WriteLine();
        }
    }
}
