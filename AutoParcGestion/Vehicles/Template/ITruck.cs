namespace AutoGestion.Vehicles.Template
{
    public interface ITruck
    {
        double Freight { get; set; }

        void LoadFreight(double freight);

        void UnloadFreight(double freight);
    }
}
