using AutoGestion.Providers.TransferState.States;

namespace AutoGestion.Providers.TransferState
{
    public class TransfertState
    {
        public ITransferState State { get; set; } = new Available();

        public void Update()
        {
            State.Handle(this);
        }

        public override string ToString()
        {
            return State.ToString();
        }
    }
}
