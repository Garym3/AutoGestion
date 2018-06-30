namespace AutoGestion.TransferState.States
{
    public class Stored : ITransferState
    {
        public void Handle(TransferState transfertState)
        {

        }

        public override string ToString()
        {
            return nameof(Stored);
        }
    }
}
