namespace AutoGestion.Providers.TransferState.States
{
    public class Available : ITransferState
    {
        public ITransferState State { get; }

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
