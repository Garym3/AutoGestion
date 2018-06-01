namespace AutoGestion.Vehicles.State
{
    public class Arrived : TransfertState
    {
        public override void ChangeState()
        {
            VVehicle.TransfertState = this;
        }
    }
}
