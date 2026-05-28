using Microsoft.AspNetCore.Identity;

namespace TravelAgency.REST.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = "";
    }
}