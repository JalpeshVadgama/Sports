﻿using Sports.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sports.Services.Interface
{
    public interface ITestService
    {
        Task<bool> Add(Test test);
        List<Test> GetAll();
    }
}
