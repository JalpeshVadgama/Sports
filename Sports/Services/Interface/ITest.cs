using Sports.Models;
using System.Threading.Tasks;

namespace Sports.Services.Interface
{
    public interface ITestService
    {
        Task<bool> AddTest(Test test);
    }
}
