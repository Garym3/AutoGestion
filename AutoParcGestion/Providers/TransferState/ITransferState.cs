namespace AutoGestion.Providers.TransferState
{
    public interface ITransferState
    {
        ITransferState State { get; }

        void Handle(TransfertState transfertState);
    }
}
