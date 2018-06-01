namespace AutoGestion.Vehicles.State
{
    public class OnTheWay : TransfertState
    {
        public override void ChangeState()
        {
            VVehicle.TransfertState = new Arrived();
        }
        public override string ToString()
        {
            return "On the way";
        }
    }
}
