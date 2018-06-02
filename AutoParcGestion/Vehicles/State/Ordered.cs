namespace AutoGestion.Vehicles.State
{
    public class Ordered : ITransfertState
    {
        public void Handle(TransfertState transfertState)
        {
            transfertState.State = new OnTheWay();
        }

        public override string ToString()
        {
            return nameof(Ordered);
        }
    }
}
