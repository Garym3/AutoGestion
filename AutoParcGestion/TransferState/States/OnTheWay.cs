namespace AutoGestion.TransferState.States
{
    public class OnTheWay : ITransferState
    {
        public void Handle(TransferState transfertState)
        {
            transfertState.State = new Arrived();
        }

        public override string ToString()
        {
            return nameof(OnTheWay);
        }
    }
}
