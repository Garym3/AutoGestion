namespace AutoGestion.Vehicles
{
    public interface ITruckBuilder : IVehicleBuilder<ITruckBuilder>
    {
        ITruckBuilder WithFreight(double freight);
    }
}
