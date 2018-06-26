namespace AutoGestion.Providers.TransferState.States
{
    public class Stored : ITransferState
    {
        public ITransferState State { get; }

        public void Handle(TransfertState transfertState)
        {

        }

        public override string ToString()
        {
            return nameof(Arrived);
        }
    }
}
