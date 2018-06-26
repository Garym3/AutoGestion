namespace AutoGestion.Providers.TransferState.States
{
    public class Arrived : ITransferState
    {
        public ITransferState State { get; }

        public void Handle(TransfertState transfertState)
        {
            transfertState.State = new Stored();
        }

        public override string ToString()
        {
            return nameof(Arrived);
        }
    }
}
