namespace AutoGestion.Vehicles
{
    public interface ITruck
    {
        double Freight { get; set; }

        void LoadFreight(double fret);

        void UnloadFreight(double fret);
    }
}
