namespace TravelAgency.Infrastructure.Models;

public class BusModel : VehicleModel
{
    public int Capacity { get; set; }
    public string Route { get; set; }
    public double FuelConsumption { get; set; }
}