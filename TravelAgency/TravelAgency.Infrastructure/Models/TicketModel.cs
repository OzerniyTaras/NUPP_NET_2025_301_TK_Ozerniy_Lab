namespace TravelAgency.Infrastructure.Models;

public class TicketModel
{
    public Guid Id { get; set; }
    public double Price { get; set; }
    public string SerialNumber { get; set; }
    public string Destination { get; set; }
}