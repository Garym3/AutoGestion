namespace AutoGestion.Vehicles.State
{
    public abstract class TransfertState
    {
        protected Vehicle VVehicle;
        
        public abstract void ChangeState();
    }
}
