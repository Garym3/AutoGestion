namespace AutoGestion.Vehicles.State
{
    public class Ordered : TransfertState
    {
        public override void ChangeState()
        {
            VVehicle.TransfertState = new OnTheWay();
        }
        public override string ToString()
        {
            return "Ordered";
        }
    }
}
