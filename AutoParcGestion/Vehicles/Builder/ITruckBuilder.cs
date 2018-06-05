namespace AutoGestion.Vehicles.Builder
{
    public interface ITruckBuilder : IVehicleBuilder<ITruckBuilder>
    {
        ITruckBuilder WithFreight(double freight);
    }
}
