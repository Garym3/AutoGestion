namespace AutoGestion.Entities
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

        public override double GetTvaTax()
        {
            return 1.20;
        }

        public override string ToString()
        {
            return $"Type: {GetType().Name}  | Transfert State: {TransfertState} | Brand: {Brand} | Color: {Color} | " +
                   $"Engine Capacity: {EngineCapacity} | Doors: {NumberOfDoors} | Seats: {NumberOfSeats} | Engine State: {EngineState} | " +
                   $"Freight: {Freight}";
        }
    }
}
