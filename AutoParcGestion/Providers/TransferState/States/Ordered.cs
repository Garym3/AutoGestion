namespace AutoGestion.Providers.TransferState.States
{
    public class Ordered : ITransferState
    {
        public ITransferState State { get; }

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
