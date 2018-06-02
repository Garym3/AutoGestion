namespace AutoGestion.Vehicles.State
{
    public class Arrived : ITransfertState
    {
        public void Handle(TransfertState transfertState)
        {
            
        }

        public override string ToString()
        {
            return nameof(Arrived);
        }
    }
}
