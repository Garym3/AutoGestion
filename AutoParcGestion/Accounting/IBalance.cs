namespace AutoGestion.Prices
{
    public interface IBalance
    {
        double Balance { get; }

        void AddToBalance(double amount);

        void SubtractFromBalance(double amount);
    }
}
