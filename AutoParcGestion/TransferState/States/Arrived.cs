namespace AutoGestion.TransferState.States
{
    public class Arrived : ITransferState
    {
        public void Handle(TransferState transfertState)
        {
            transfertState.State = new Stored();
        }

        public override string ToString()
        {
            return nameof(Arrived);
        }
    }
}
