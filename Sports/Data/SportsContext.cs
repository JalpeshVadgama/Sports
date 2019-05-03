using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sports.Models;

namespace Sports.Data
{
    public class SportsContext :IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public SportsContext
           (DbContextOptions<SportsContext> options)
            : base(options)
        {
            //nothing here
        }
    }
}
