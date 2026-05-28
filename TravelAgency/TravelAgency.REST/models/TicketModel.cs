namespace TravelAgency.REST.Models
{
    public class TicketModel
    {
        public Guid Id { get; set; }

        public string PassengerName { get; set; }

        public decimal Price { get; set; }
    }
}