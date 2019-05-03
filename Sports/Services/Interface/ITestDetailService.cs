using Sports.Models;
using System.Threading.Tasks;

namespace Sports.Services.Interface
{
    public interface ITestDetailService
    {
        Task<bool> Add(TestDetail testDetail);
        Task<bool> Update(TestDetail testDetail);
        Task<bool> Delete(int testDetailId);
        Task<TestDetail> Get(int testDetailId);
    }
}
