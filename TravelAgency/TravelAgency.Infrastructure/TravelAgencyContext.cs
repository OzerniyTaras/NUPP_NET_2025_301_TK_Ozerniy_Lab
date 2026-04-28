using Microsoft.EntityFrameworkCore;
using TravelAgency.Infrastructure.Models;

namespace TravelAgency.Infrastructure;

public class TravelAgencyContext : DbContext
{
    public DbSet<BusModel> Buses { get; set; }
    public DbSet<CarModel> Cars { get; set; }
    public DbSet<TicketModel> Tickets { get; set; }

    public TravelAgencyContext(DbContextOptions<TravelAgencyContext> options)
        : base(options)
    {
    }
}