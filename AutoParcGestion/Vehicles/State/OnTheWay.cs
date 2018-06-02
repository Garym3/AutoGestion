namespace AutoGestion.Vehicles.State
{
    public class OnTheWay : ITransfertState
    {
        public void Handle(TransfertState transfertState)
        {
            transfertState.State = new Arrived();
        }

        public override string ToString()
        {
            return nameof(OnTheWay);
        }
    }
}
