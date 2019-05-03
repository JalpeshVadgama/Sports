using Microsoft.AspNetCore.Identity;

namespace Sports.Models
{
    public class ApplicationRole : IdentityRole
    {
        public  string Description { get; set; }
    }
}