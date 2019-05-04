using Sports.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sports.Services.Interface
{
    public interface ITestService
    {
        Task<bool> Add(Test test);
        List<TestViewModel> GetAll();
        DetailTestViewModel GetDetailsOfTest(int testId);
        bool Delete(int testId);

    }
}
