namespace AutoGestion.TransferState.States
{
    public class Available : ITransferState
    {
        public void Handle(TransferState transfertState)
        {
            transfertState.State = new Ordered();
        }

        public override string ToString()
        {
            return nameof(Available);
        }
    }
}
