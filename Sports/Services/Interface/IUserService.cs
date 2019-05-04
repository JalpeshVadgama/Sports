using Sports.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sports.Services.Interface
{
    public interface IUserService
    {
       Task<IList<ApplicationUser>> GetAllAsync();
    }
}
