namespace AutoGestion.Providers.TransferState.States
{
    public class OnTheWay : ITransferState
    {
        public ITransferState State { get; }

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
