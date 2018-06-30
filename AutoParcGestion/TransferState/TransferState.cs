using AutoGestion.TransferState.States;

namespace AutoGestion.TransferState
{
    public class TransferState
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
