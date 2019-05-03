using Sports.Models;
using System.Threading.Tasks;

namespace Sports.Services.Interface
{
    public interface ITestService
    {
        Task<bool> Add(Test test);
    }
}
