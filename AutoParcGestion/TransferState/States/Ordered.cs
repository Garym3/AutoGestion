namespace AutoGestion.TransferState.States
{
    public class Ordered : ITransferState
    {
        public void Handle(TransferState transfertState)
        {
            transfertState.State = new OnTheWay();
        }

        public override string ToString()
        {
            return nameof(Ordered);
        }
    }
}
