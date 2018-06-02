namespace AutoGestion.Vehicles.State
{
    public class Available : ITransfertState
    {
        public void Handle(TransfertState transfertState)
        {
            transfertState.State = new Ordered();
        }

        public override string ToString()
        {
            return nameof(Available);
        }
    }
}
