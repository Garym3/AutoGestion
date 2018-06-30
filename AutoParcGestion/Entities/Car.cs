namespace AutoGestion.Entities
{
    public class Car : Vehicle
    {
        public override double GetTvaTax()
        {
            return 1.15;
        }
    }
}
